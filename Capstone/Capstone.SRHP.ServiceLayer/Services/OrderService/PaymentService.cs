using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Net.payOS.Types;
using Net.payOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Microsoft.Extensions.Logging;

using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.DTOs.Payments.Admin;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using System.Net.WebSockets;
using Capstone.HPTY.ServiceLayer.Interfaces.BackgroundService;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentService> _logger;
        private readonly IDiscountService _discountService;
        private readonly IIngredientService _ingredientService;
        private readonly IUtensilService _utensilService;
        private readonly IComboService _comboService;
        private readonly ICustomizationService _customizationService;
        private readonly INotificationService _notificationService;
        private readonly ILockService _lockService;


        public PaymentService(
            PayOS payOS,
            IUnitOfWork unitOfWork,
            ILogger<PaymentService> logger,
            IDiscountService discountService,
            IIngredientService ingredientService,
            IUtensilService utensilService,
            IComboService comboService,
            INotificationService notificationService,
            ILockService lockService,
            ICustomizationService customizationService)
        {
            _payOS = payOS;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _discountService = discountService;
            _ingredientService = ingredientService;
            _utensilService = utensilService;
            _comboService = comboService;
            _notificationService = notificationService;
            _lockService = lockService;
            _customizationService = customizationService;
        }

        public async Task<Response> ProcessOnlinePayment(int orderId, string address, string notes, int? discountId,
            DateTime? expectedReturnDate, DateTime? deliveryTime, CreatePaymentLinkRequest paymentRequest, int userId)
        {
            try
            {
                // 1. Get the order with all details (read operation, can be outside transaction)
                var order = await GetOrderByIdAsync(orderId);

                // 2. Verify inventory availability (read operation, can be outside transaction)
                var verificationResults = await VerifyCartItemsAvailabilityAsync(order);
                if (!verificationResults.AllItemsAvailable)
                {
                    return new Response(-1, $"Một số mặt hàng trong giỏ hàng của bạn hiện không còn: {string.Join(", ", verificationResults.UnavailableItems)}", null);
                }

                DateTime currentTime = DateTime.UtcNow.AddHours(7);
                int rentalDays = 1;

                // Calculate rental duration and adjust hotpot prices if needed
                decimal originalTotalPrice = order.TotalPrice;
                decimal calculatedPrice = originalTotalPrice;

                if (order.HasRentItems)
                {
                    // Check if provided date is valid (future compared to current time)
                    if (!expectedReturnDate.HasValue || expectedReturnDate.Value <= currentTime)
                    {
                        throw new ValidationException("Ngày trả dự kiến phải là một thời điểm trong tương lai");
                    }

                    // Calculate rental duration in days (round up to next day)
                    rentalDays = (int)Math.Ceiling((expectedReturnDate.Value - deliveryTime.Value).TotalDays);
                    if (rentalDays < 1) rentalDays = 1;

                    // Get all hotpot items from the order
                    decimal hotpotTotalOriginal = 0;
                    decimal hotpotTotalAdjusted = 0;

                    foreach (var orderItem in order.RentOrder.RentOrderDetails)
                    {
                        if (IsHotpotItem(orderItem))
                        {
                            hotpotTotalOriginal += orderItem.RentalPrice;

                            // Calculate adjusted price based on rental days
                            decimal adjustedItemPrice = orderItem.RentalPrice * rentalDays;
                            hotpotTotalAdjusted += adjustedItemPrice;
                        }
                        // Update the total price by replacing the original hotpot prices with the adjusted ones
                        calculatedPrice = originalTotalPrice - hotpotTotalOriginal + hotpotTotalAdjusted;
                    }
                }

                if (discountId.HasValue)
                {
                    var discount = await _discountService.GetByIdAsync(discountId.Value);
                    if (discount == null)
                    {
                        throw new ValidationException($"Không tìm thấy khuyến mãi với ID {discountId}");
                    }

                    // Validate discount is still valid
                    if (!await _discountService.IsDiscountValidAsync(discountId.Value))
                    {
                        throw new ValidationException("Khuyến mãi đã chọn không hợp lệ hoặc đã hết hạn");
                    }

                    // Apply discount to the calculated price
                    decimal discountAmount = calculatedPrice * (decimal)(discount.DiscountPercentage / 100);
                    calculatedPrice = calculatedPrice - discountAmount;
                }

                // Update the payment request price
                paymentRequest = paymentRequest with { price = (int)calculatedPrice };


                // 3. Get user information (read operation, can be outside transaction)
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == paymentRequest.buyerPhone);
                if (user == null)
                {
                    return new Response(-1, "Không tìm thấy user", null);
                }

                if (discountId != null)
                {
                    if (!await _discountService.HasSufficientPointsAsync((int)discountId, user.LoyatyPoint))
                    {
                        return new Response(-1, "Không đủ điểm để sử dụng mã giảm giá", null);
                    }
                }

                // 4. Generate transaction code
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                // 5. Create payment data
                ItemData item = new ItemData(paymentRequest.productName, 1, paymentRequest.price);
                List<ItemData> items = new List<ItemData> { item };

                if (paymentRequest.cancelUrl == null || paymentRequest.returnUrl == null)
                {
                    paymentRequest = paymentRequest with
                    {
                        cancelUrl = paymentRequest.cancelUrl ?? "",
                        returnUrl = paymentRequest.returnUrl ?? ""
                    };
                }

                string buyerName = !string.IsNullOrEmpty(paymentRequest.buyerName) ? paymentRequest.buyerName : user.Name;
                string? buyerPhone = !string.IsNullOrEmpty(paymentRequest.buyerPhone) ? paymentRequest.buyerPhone : user.PhoneNumber;

                PaymentData paymentData = new PaymentData(
                    orderCode,
                    paymentRequest.price,
                    paymentRequest.description,
                    items,
                    paymentRequest.cancelUrl,
                    paymentRequest.returnUrl,
                    buyerName,
                    buyerPhone
                );

                // 6. Create payment link (external API call, can be outside transaction)
                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                // 7. Execute all database operations in a transaction
                return await _unitOfWork.ExecuteInTransactionAsync<Response>(async () =>
                {
                    if (user.Address == null)
                    {
                        user.Address = address;
                        await _unitOfWork.Repository<User>().Update(user, user.UserId);
                    }

                    // Update the order details
                    var updateRequest = new UpdateOrderRequest
                    {
                        Address = address,
                        Notes = notes,
                        DiscountId = discountId,
                        ExpectedReturnDate = expectedReturnDate,
                        DeliveryTime = deliveryTime
                    };



                    // This will throw ValidationException if validation fails
                    await OrderUpdateAsync(orderId, updateRequest);

                    // Create payment record
                    var paymentTransaction = new Payment
                    {
                        TransactionCode = orderCode,
                        UserId = userId,
                        OrderId = orderId,
                        Price = paymentRequest.price,
                        Type = PaymentType.Online,
                        Status = PaymentStatus.Pending,
                        Purpose = PaymentPurpose.OrderPayment
                    };

                    await _unitOfWork.Repository<Payment>().InsertAsync(paymentTransaction);
                    await _unitOfWork.CommitAsync();

                    var currentUserInfo = new
                    {
                        user.UserId,
                        user.Name,
                        user.PhoneNumber,
                    };

                    return new Response(0, "success", new
                    {
                        paymentInfo = createPayment,
                        userInfo = currentUserInfo
                    });
                },
                ex =>
                {
                    if (!(ex is ValidationException))
                    {
                        _logger.LogError(ex, "Error processing online payment for order {OrderId}", orderId);
                    }
                });
            }
            catch (ValidationException ex)
            {
                // Handle validation exceptions
                return new Response(-1, ex.Message, null);
            }
            catch (Exception exception)
            {
                // Handle all other exceptions
                _logger.LogError(exception, "Error processing online payment for order {OrderId}", orderId);
                return new Response(-1, $"{exception.Message}", null);
            }
        }
        private bool IsHotpotItem(RentOrderDetail product)
        {
            return product.HotpotInventoryId.HasValue;
        }

        public async Task<Payment> ProcessCashPayment(int orderId, string address, string notes, int? discountId,
      DateTime? expectedReturnDate, DateTime? deliveryTime, int userId)
        {
            try
            {
                // 1. Get the order with all details
                var order = await GetOrderByIdAsync(orderId);

                // Validate order is in Cart status
                if (order.Status != OrderStatus.Cart)
                {
                    throw new ValidationException("Chỉ đơn hàng ở trạng thái Giỏ hàng mới có thể được xử lý thanh toán");
                }

                // 2. Verify inventory availability
                var verificationResults = await VerifyCartItemsAvailabilityAsync(order);
                if (!verificationResults.AllItemsAvailable)
                {
                    throw new ValidationException($"Một số mặt hàng trong giỏ hàng của bạn không còn sẵn có: {string.Join(", ", verificationResults.UnavailableItems)}");
                }

                // 3. Validate delivery time
                if (!deliveryTime.HasValue || deliveryTime.Value <= DateTime.UtcNow.AddHours(7))
                {
                    throw new ValidationException("Thời gian giao hàng phải được đặt và phải là thời gian trong tương lai");
                }

                // 4. Validate expected return date for rental orders
                if (order.HasRentItems)
                {
                    // Get current time with offset (local current time)
                    DateTime currentTime = DateTime.UtcNow.AddHours(7);

                    // Check if provided date is valid (future compared to current time)
                    if (!expectedReturnDate.HasValue || expectedReturnDate.Value <= currentTime)
                    {
                        throw new ValidationException("Ngày trả dự kiến phải được đặt và nằm trong tương lai");
                    }
                }

                // 5. Update the order details
                var updateRequest = new SpecialUpdateOrderRequest
                {
                    Address = address,
                    Notes = notes,
                    DiscountId = discountId,
                    ExpectedReturnDate = expectedReturnDate,
                    DeliveryTime = deliveryTime
                };

                order = await OrderUpdateAsync(orderId, updateRequest);

                // 6. Create payment record
                var payment = new Payment
                {
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                    UserId = userId,
                    OrderId = orderId,
                    Price = order.TotalPrice,
                    Type = PaymentType.Cash,
                    Status = PaymentStatus.Success, // Cash payments are immediately successful
                    Purpose = PaymentPurpose.OrderPayment
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(payment);

                // 7. Finalize inventory deduction for cash payments
                await FinalizeInventoryDeduction(order);

                // 8. Update order status to Processing
                order.Status = OrderStatus.Pending;
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, orderId);

                await _unitOfWork.CommitAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing cash payment for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<Response> GetOrder(int orderCode)
        {
            try
            {
                var transaction = await _unitOfWork.Repository<Payment>()
                    .AsQueryable(p => p.TransactionCode == orderCode)
                    .Include(u => u.User)
                    .Include(u => u.Order)
                    .FirstOrDefaultAsync();

                if (transaction == null)
                {
                    return new Response(-1, "Không tìm thấy giao dịch", null);
                }

                // Fetch payment link information
                PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInformation(orderCode);

                // Create a strongly-typed result
                var result = new PaymentOrderResult
                {
                    Transaction = transaction,
                    PaymentLinkInformation = paymentLinkInformation
                };

                return new Response(0, "Ok", result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error getting order {OrderCode}", orderCode);
                return new Response(-1, "Fail", null);
            }
        }

        public async Task<Response> CancelOrder(int orderCode, string reason)
        {
            try
            {
                var paymentTransaction = await _unitOfWork.Repository<Payment>()
                    .FindAsync(pt => pt.TransactionCode == orderCode);

                if (paymentTransaction == null)
                {
                    return new Response(-1, "Không tìm thấy giao dịch", null);
                }

                // Get the order
                var order = await GetOrderByIdAsync(paymentTransaction.OrderId.Value);

                // Update payment status
                paymentTransaction.Status = PaymentStatus.Cancelled;
                paymentTransaction.UpdatedAt = DateTime.UtcNow.AddHours(7);
                await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);

                // Release inventory reservations
                await ReleaseInventoryReservation(order);

                await _unitOfWork.CommitAsync();

                // Cancel the payment link in PayOS
                PaymentLinkInformation paymentLinkInformation = null;
                if (paymentTransaction.Type == PaymentType.Online)
                {
                    paymentLinkInformation = await _payOS.cancelPaymentLink(orderCode, reason);
                }

                return new Response(0, "Ok", paymentLinkInformation);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error cancelling order {OrderCode}", orderCode);
                return new Response(-1, "fail", null);
            }
        }

        public async Task<Response> ConfirmWebhook(ConfirmWebhook body)
        {
            try
            {
                await _payOS.confirmWebhook(body.webhook_url);
                return new Response(0, "Ok", null);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error confirming webhook");
                return new Response(-1, "fail", null);
            }
        }

        public async Task<Response> CheckOrder(CheckOrderRequest request, string userPhone)
        {
            // Create a unique lock key for this transaction
            string processLockKey = $"process_payment_{request.OrderCode}";

            try
            {

                using (await _lockService.AcquireLockAsync(processLockKey, TimeSpan.FromSeconds(10)))
                {
                    // Get user information
                    var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == userPhone);
                    if (user == null)
                    {
                        return new Response(-1, "Không tìm thấy người dùng", null);
                    }

                    // Get payment information from PayOS
                    PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInformation(request.OrderCode);
                    if (paymentLinkInformation == null)
                    {
                        return new Response(-1, "Thông tin thanh toán không tìm thấy", null);
                    }

                    // Get payment transaction
                    var paymentTransaction = await _unitOfWork.Repository<Payment>()
                        .FindAsync(pt => pt.TransactionCode == request.OrderCode);
                    if (paymentTransaction == null)
                    {
                        return new Response(-1, "Không tìm thấy giao dịch", null);
                    }

                    // Get the order
                    var order = await GetOrderByIdAsync(paymentTransaction.OrderId.Value);
                    if (order == null)
                    {
                        return new Response(-1, "Không tìm thấy đơn hàng", null);
                    }

                    // Prepare user info for response
                    var userInfo = new
                    {
                        user.UserId,
                        user.Name,
                        user.PhoneNumber,
                    };

                    // Return appropriate response based on current payment status in our system
                    if (paymentTransaction.Status == PaymentStatus.Success)
                    {
                        return new Response(0, "Hoàn thành giao dịch",
                            new { paymentInfo = paymentLinkInformation, userInfo });
                    }
                    else if (paymentTransaction.Status == PaymentStatus.Cancelled)
                    {
                        return new Response(0, "Huỷ giao dịch",
                            new { paymentInfo = paymentLinkInformation, userInfo });
                    }
                    else if (paymentTransaction.Status == PaymentStatus.Pending)
                    {
                        // If PayOS shows PAID or CANCELLED but our system still shows PENDING,
                        // trigger the background service to process it immediately
                        if (paymentLinkInformation.status == "PAID" || paymentLinkInformation.status == "CANCELLED")
                        {
                            // Log this situation
                            _logger.LogInformation("Payment {TransactionCode} is {Status} in PayOS but still PENDING in our system. Background service will process it.",
                                request.OrderCode, paymentLinkInformation.status);


                            // paymentLinkInformation = paymentLinkInformation with { status = "PENDING" };

                            // Return a message indicating the payment is being processed
                            string message = paymentLinkInformation.status == "PAID"
                                ? "Thanh toán đang được xử lý, vui lòng đợi trong giây lát"
                                : "Giao dịch đang được hủy, vui lòng đợi trong giây lát";

                            return new Response(0, message, new { paymentInfo = paymentLinkInformation, userInfo });
                        }

                        // For other statuses, just return the current status
                        return new Response(0, "Giao dịch chưa hoàn thành",
                            new { paymentInfo = paymentLinkInformation, userInfo });
                    }

                    // Fallback for any other payment status
                    return new Response(0, $"Trạng thái giao dịch: {paymentTransaction.Status}",
                        new { paymentInfo = paymentLinkInformation, userInfo });

                }
            }
            catch (TimeoutException)
            {
                return new Response(0, "Hệ thống đang bận", null);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error checking order {OrderCode}: {Message}", request.OrderCode, exception.Message);
                return new Response(-1, "Lỗi khi kiểm tra đơn hàng", null);
            }

        }



        public async Task<Response> ProcessOrder(CheckOrderRequest request, string userPhone)
        {
            string processLockKey = $"process_payment_{request.OrderCode}";
            _logger.LogInformation("ProcessOrder called for {TransactionCode}", request.OrderCode);
            try
            {
                using (await _lockService.AcquireLockAsync(processLockKey, TimeSpan.FromSeconds(10)))
                {
                    try
                    {
                        // Get user information
                        var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == userPhone);
                        if (user == null)
                        {
                            return new Response(-1, "Không tìm thấy người dùng", null);
                        }

                        // Get payment information from PayOS
                        PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInformation(request.OrderCode);
                        if (paymentLinkInformation == null)
                        {
                            return new Response(-1, "thông tin thanh toán không thấy", null);
                        }

                        // Get payment transaction
                        var paymentTransaction = await _unitOfWork.Repository<Payment>()
                            .FindAsync(pt => pt.TransactionCode == request.OrderCode);
                        if (paymentTransaction == null)
                        {
                            return new Response(-1, "Không tìm thấy giao dịch", null);
                        }

                        // Get the order
                        var order = await GetOrderByIdAsync(paymentTransaction.OrderId.Value);
                        if (order == null)
                        {
                            return new Response(-1, "Không tìm thấy đơn hàng", null);
                        }

                        var userInfo = new
                        {
                            user.UserId,
                            user.Name,
                            user.PhoneNumber,
                        };

                        // If payment is already processed, return appropriate response
                        if (paymentTransaction.Status == PaymentStatus.Success)
                        {
                            return new Response(0, "Hoàn thành giao dịch",
                                new { paymentInfo = paymentLinkInformation, userInfo });
                        }
                        else if (paymentTransaction.Status == PaymentStatus.Cancelled)
                        {
                            return new Response(0, "Huỷ giao dịch",
                                new { paymentInfo = paymentLinkInformation, userInfo });
                        }

                        // If order is no longer in Cart status, it means it's already been processed
                        if (order.Status != OrderStatus.Cart)
                        {
                            return new Response(0, "Đơn hàng đã được xử lý",
                                new { paymentInfo = paymentLinkInformation, userInfo });
                        }

                        // Process based on payment status from PayOS
                        if (paymentLinkInformation.status == "PAID")
                        {
                            // Execute all database operations in a single transaction
                            var result = await _unitOfWork.ExecuteInTransactionAsync(async () =>
                            {
                                // Get fresh copies of the entities within the transaction
                                var freshPayment = await _unitOfWork.Repository<Payment>().GetById(paymentTransaction.PaymentId);
                                if (freshPayment == null)
                                {
                                    return new { Success = false, Message = "Không tìm thấy giao dịch" };
                                }

                                // If payment is already successful, don't process again
                                if (freshPayment.Status == PaymentStatus.Success)
                                {
                                    return new { Success = true, Message = "Giao dịch đã được xử lý trước đó" };
                                }

                                var freshOrder = await GetOrderByIdAsync(order.OrderId);
                                if (freshOrder == null)
                                {
                                    return new { Success = false, Message = "Không tìm thấy đơn hàng" };
                                }

                                // If order is no longer in Cart status, it means it's already been processed
                                if (freshOrder.Status != OrderStatus.Cart)
                                {
                                    return new { Success = true, Message = "Đơn hàng đã được xử lý trước đó" };
                                }

                                freshOrder.TotalPrice = paymentLinkInformation.amount;
                                await _unitOfWork.Repository<Order>().Update(freshOrder, freshOrder.OrderId);

                                // Process loyalty points
                                if (freshOrder.DiscountId != null)
                                {
                                    if (await _discountService.HasSufficientPointsAsync((int)freshOrder.DiscountId, user.LoyatyPoint))
                                    {
                                        user.LoyatyPoint = user.LoyatyPoint - (await _discountService.GetByIdAsync((int)freshOrder.DiscountId)).PointCost;
                                        await _unitOfWork.Repository<User>().Update(user, user.UserId);
                                    }
                                }
                                else
                                {
                                    user.LoyatyPoint += Math.Round((double)freshOrder.TotalPrice / 10000, 2);
                                    await _unitOfWork.Repository<User>().Update(user, user.UserId);
                                }

                                // Update transaction
                                freshPayment.Status = PaymentStatus.Success;
                                freshPayment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                                await _unitOfWork.Repository<Payment>().Update(freshPayment, freshPayment.PaymentId);

                                // Finalize inventory deduction
                                await FinalizeInventoryDeduction(freshOrder);

                                // Update order status to Pending
                                freshOrder.Status = OrderStatus.Pending;
                                freshOrder.SetUpdateDate();
                                await _unitOfWork.Repository<Order>().Update(freshOrder, freshOrder.OrderId);

                                return new { Success = true, Message = "Hoàn thành giao dịch" };
                            },
                            ex =>
                            {
                                _logger.LogError(ex, "Error in transaction while processing successful payment for order {OrderCode}", request.OrderCode);
                            });

                            // If transaction was successful or payment was already processed, send notifications
                            if (result != null && result.Success)
                            {
                                var updatedUserInfo = new
                                {
                                    user.UserId,
                                    user.Name,
                                    user.PhoneNumber,
                                };

                                // Only send notifications if this is the first time we're processing this payment
                                if (result.Message == "Hoàn thành giao dịch")
                                {
                                    try
                                    {
                                        await _notificationService.NotifyUserAsync(
                                            user.UserId,
                                            "Order",
                                            "Thanh Toán Thành Công",
                                            $"Đơn hàng #{order.OrderId} của bạn đã được thanh toán thành công",
                                            new Dictionary<string, object>
                                            {
                                { "OrderId", order.OrderId },
                                { "Amount", paymentLinkInformation.amount },
                                { "PaymentTime", DateTime.Parse(paymentLinkInformation.createdAt) },
                                { "Status", "Đang xử lý" },
                                { "NextSteps", "Đơn hàng của bạn đang được xử lý. Chúng tôi sẽ thông báo khi đơn hàng được giao." }
                                            });

                                        string orderType = order.HasRentItems && order.HasSellItems
                                           ? "Thuê và Mua"
                                           : (order.HasRentItems ? "Thuê" : "Mua");

                                        // Format the amount as currency
                                        var formattedAmount = string.Format("{0:N0} VND", paymentLinkInformation.amount);

                                        // Send notification to managers
                                        await _notificationService.NotifyRoleAsync(
                                            "Manager",
                                            "Order",
                                            "Thanh Toán Thành Công",
                                            $"Khách hàng {user.Name} đã thanh toán thành công đơn hàng #{order.OrderCode}",
                                            new Dictionary<string, object>
                                            {
                                { "OrderId", order.OrderId },
                                { "Amount", formattedAmount },
                                { "CustomerName", user.Name },
                                { "CustomerPhone", user.PhoneNumber },
                                { "PaymentTime", DateTime.Parse(paymentLinkInformation.createdAt) },
                                { "OrderType", orderType },
                                { "TransactionId", paymentLinkInformation.id }
                                            });
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log notification errors but don't fail the operation
                                        _logger.LogError(ex, "Error sending notifications for successful payment {OrderCode}", request.OrderCode);
                                    }
                                }

                                return new Response(0, "Hoàn thành giao dịch",
                                    new { paymentInfo = paymentLinkInformation, userInfo = updatedUserInfo });
                            }
                            else
                            {
                                // Transaction failed
                                return new Response(-1, result?.Message ?? "Lỗi xử lý giao dịch", null);
                            }
                        }
                        else if (paymentLinkInformation.status == "CANCELLED")
                        {
                            // Execute all database operations in a single transaction
                            var result = await _unitOfWork.ExecuteInTransactionAsync(async () =>
                            {
                                // Get fresh copies of the entities within the transaction
                                var freshPayment = await _unitOfWork.Repository<Payment>().GetById(paymentTransaction.PaymentId);
                                if (freshPayment == null)
                                {
                                    return new { Success = false, Message = "Không tìm thấy giao dịch" };
                                }

                                // If payment is already cancelled, don't process again
                                if (freshPayment.Status == PaymentStatus.Cancelled)
                                {
                                    return new { Success = true, Message = "Giao dịch đã được hủy trước đó" };
                                }

                                var freshOrder = await _unitOfWork.Repository<Order>().GetById(order.OrderId);
                                if (freshOrder == null)
                                {
                                    return new { Success = false, Message = "Không tìm thấy đơn hàng" };
                                }

                                // If order is no longer in Cart status, it means it's already been processed
                                if (freshOrder.Status != OrderStatus.Cart)
                                {
                                    return new { Success = true, Message = "Đơn hàng đã được xử lý trước đó" };
                                }

                                // Update transaction
                                freshPayment.Status = PaymentStatus.Cancelled;
                                freshPayment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                                await _unitOfWork.Repository<Payment>().Update(freshPayment, freshPayment.PaymentId);

                                // Release inventory reservations
                                await ReleaseInventoryReservation(freshOrder);

                                return new { Success = true, Message = "Huỷ giao dịch" };
                            },
                            ex =>
                            {
                                _logger.LogError(ex, "Error in transaction while processing cancelled payment for order {OrderCode}", request.OrderCode);
                            });

                            if (result != null && result.Success)
                            {
                                var updatedUserInfo = new
                                {
                                    user.UserId,
                                    user.Name,
                                    user.PhoneNumber,
                                };

                                return new Response(0, "Huỷ giao dịch",
                                    new { paymentInfo = paymentLinkInformation, userInfo = updatedUserInfo });
                            }
                            else
                            {
                                // Transaction failed
                                return new Response(-1, result?.Message ?? "Lỗi xử lý giao dịch", null);
                            }
                        }
                        else
                        {
                            return new Response(0, "Giao dịch chưa hoàn thành",
                                new { paymentInfo = paymentLinkInformation });
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, "Error processing order {OrderCode}: {Message}", request.OrderCode, exception.Message);
                        return new Response(-1, "Lỗi khi xử lý đơn hàng", null);
                    }
                    finally
                    {
                        _logger.LogInformation("ProcessOrder releasing lock for {TransactionCode}", request.OrderCode);
                    }
                }
            }
            catch (TimeoutException)
            {
                // Lock acquisition timed out, which means ProcessOrder is already running for this transaction
                return new Response(0, "Đơn hàng đang được xử lý, vui lòng đợi trong giây lát", null);
            }
        }

        public async Task<Payment> UpdatePaymentStatusAsync(int paymentId, PaymentStatus status)
        {
            try
            {
                var payment = await _unitOfWork.Repository<Payment>().FindAsync(p => p.PaymentId == paymentId);
                if (payment == null)
                {
                    throw new NotFoundException($"Không tìm thấy thanh toán với ID {paymentId}");
                }

                payment.Status = status;
                payment.UpdatedAt = DateTime.UtcNow.AddHours(7);

                await _unitOfWork.Repository<Payment>().Update(payment, paymentId);
                await _unitOfWork.CommitAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating payment status for payment {PaymentId}", paymentId);
                throw;
            }
        }

        /// <summary>
        /// Process additional fee payment (late fee or damage fee)
        /// </summary>
        public async Task<Payment> ProcessAdditionalFeePaymentAsync(
            int orderId,
            PaymentPurpose feeType,
            decimal amount,
            PaymentType paymentType,
            string notes = null)
        {
            try
            {
                // Validate the fee type
                if (feeType != PaymentPurpose.LateFee && feeType != PaymentPurpose.DamageFee)
                {
                    throw new ArgumentException("Loại phí phải là phí trễ hạn hoặc phí hư hỏng");
                }

                // Get the order
                var order = await GetOrderByIdAsync(orderId);

                // Validate order status - only allow additional fees for orders that are not in Cart status
                if (order.Status == OrderStatus.Cart)
                {
                    throw new ValidationException("Không thể thêm phụ phí vào đơn hàng trong giỏ hàng");
                }

                // Validate that the order has a rent order
                if (order.RentOrder == null)
                {
                    throw new ValidationException("Không thể thêm phụ phí vào đơn hàng không có sản phẩm thuê");
                }


                // Create payment record
                var payment = new Payment
                {
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                    UserId = order.UserId,
                    OrderId = orderId,
                    Price = amount,
                    Type = paymentType,
                    Status = paymentType == PaymentType.Cash ? PaymentStatus.Success : PaymentStatus.Pending,
                    Purpose = feeType
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(payment);

                // Update the RentOrder with the fee amount
                if (feeType == PaymentPurpose.LateFee)
                {
                    order.RentOrder.LateFee = (order.RentOrder.LateFee ?? 0) + amount;
                    if (!string.IsNullOrWhiteSpace(notes))
                    {
                        order.RentOrder.RentalNotes = string.IsNullOrWhiteSpace(order.RentOrder.RentalNotes)
                            ? $"Phí trễ hạn: {notes}"
                            : $"{order.RentOrder.RentalNotes}\nPhí trễ hạn: {notes}";
                    }
                }
                else if (feeType == PaymentPurpose.DamageFee)
                {
                    order.RentOrder.DamageFee = (order.RentOrder.DamageFee ?? 0) + amount;
                    if (!string.IsNullOrWhiteSpace(notes))
                    {
                        order.RentOrder.ReturnCondition = string.IsNullOrWhiteSpace(order.RentOrder.ReturnCondition)
                            ? $"Phí hư hỏng: {notes}"
                            : $"{order.RentOrder.ReturnCondition}\nPhí hư hỏng: {notes}";
                    }
                }


                // Update the order
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, orderId);

                await _unitOfWork.CommitAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing {FeeType} payment for order {OrderId}", feeType, orderId);
                throw;
            }
        }

        public async Task<Payment> ProcessLateFeePaymentAsync(
               int orderId,
               decimal amount,
               PaymentType paymentType,
               string notes = null)
        {
            return await ProcessAdditionalFeePaymentAsync(orderId, PaymentPurpose.LateFee, amount, paymentType, notes);
        }

        public async Task<Payment> ProcessDamageFeePaymentAsync(
            int orderId,
            decimal amount,
            PaymentType paymentType,
            string notes = null)
        {
            return await ProcessAdditionalFeePaymentAsync(orderId, PaymentPurpose.DamageFee, amount, paymentType, notes);
        }

        public async Task<Order> RecordHotpotReturnAsync(int orderId, string returnCondition, decimal? damageFee = null)
        {
            try
            {
                var order = await GetOrderByIdAsync(orderId);

                // Validate that the order has a rent order with hotpot
                if (order.RentOrder == null)
                {
                    throw new ValidationException("Đơn hàng không có sản phẩm thuê");
                }

                bool hasHotpot = order.RentOrder.RentOrderDetails.Any(d => d.HotpotInventoryId.HasValue);
                if (!hasHotpot)
                {
                    throw new ValidationException("Đơn hàng không có sản phẩm lẩu");
                }

                // Track which hotpot types need quantity updates
                var hotpotIdsToUpdate = new HashSet<int>();

                // Update hotpot inventory status to Available
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                {
                    var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                        .IncludeNested(query => query.Include(h => h.Hotpot))
                        .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                    if (hotpotInventory != null)
                    {
                        hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);
                        hotpotInventory.Status = HotpotStatus.Available;
                        await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                    }
                }

                // Set the actual return date
                order.RentOrder.ActualReturnDate = DateTime.UtcNow.AddHours(7);

                // Set the return condition
                if (!string.IsNullOrEmpty(returnCondition))
                {
                    order.RentOrder.ReturnCondition = returnCondition;
                }

                decimal totalFee = 0;
                string feeDescription = "";

                // Calculate late fee if returned after expected date
                if (order.RentOrder.ExpectedReturnDate < DateTime.UtcNow.AddHours(7))
                {
                    // Calculate days late
                    int daysLate = (int)Math.Ceiling((DateTime.UtcNow.AddHours(7) - order.RentOrder.ExpectedReturnDate).TotalDays);

                    // Calculate late fee (example: $5 per day late)
                    decimal lateFee = daysLate * 5.0m; // You might want to make this configurable

                    // Set the late fee
                    order.RentOrder.LateFee = lateFee;

                    totalFee += lateFee;
                    feeDescription += $"Phí trả trễ {daysLate} ngày: ${lateFee}";
                }

                // Add damage fee if provided
                if (damageFee.HasValue && damageFee.Value > 0)
                {
                    order.RentOrder.DamageFee = damageFee.Value;

                    totalFee += damageFee.Value;
                    feeDescription += (feeDescription.Length > 0 ? "\n" : "") + $"Phí hư hỏng: ${damageFee.Value} - {returnCondition}";
                }

                // Create a single payment record for all fees if there are any
                if (totalFee > 0)
                {
                    var payment = new Payment
                    {
                        TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                        UserId = order.UserId,
                        OrderId = orderId,
                        Price = totalFee,
                        Type = PaymentType.Cash, // Default to cash, can be changed later
                        Status = PaymentStatus.Pending,
                        Purpose = PaymentPurpose.LateFee, // Use LateFee as the primary purpose
                    };

                    await _unitOfWork.Repository<Payment>().InsertAsync(payment);
                }

                // Update the order status if all items are returned
                if (order.Status == OrderStatus.Returning)
                {
                    order.Status = OrderStatus.Completed;
                }

                // Update the order
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, orderId);

                // Update the quantity for each affected hotpot type
                //foreach (var hotpotId in hotpotIdsToUpdate)
                //{
                //    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                //}

                await _unitOfWork.CommitAsync();

                return await GetOrderByIdAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording hotpot return for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<Payment> GetPaymentByUserIdAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAll(p => p.UserId == userId)
                    .Include(p => p.Order)
                    .OrderByDescending(p => p.CreatedAt)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments for user {UserId}", userId);
                throw;
            }
        }

        public async Task<Payment> GetPaymentByOrderIdAsync(int orderId)
        {
            try
            {
                return await GetMainPaymentForOrderAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<IEnumerable<Payment>> GetListPaymentByOrderIdAsync(int orderId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAll(p => p.OrderId == orderId)
                    .OrderByDescending(p => p.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<Payment> GetMainPaymentForOrderAsync(int orderId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAll(p => p.OrderId == orderId && p.Purpose == PaymentPurpose.OrderPayment)
                    .OrderByDescending(p => p.CreatedAt)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting main payment for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<Response> VerifyCartBeforePaymentAsync(int orderId)
        {
            try
            {
                var order = await GetOrderByIdAsync(orderId);

                // Verify inventory availability
                var verificationResults = await VerifyCartItemsAvailabilityAsync(order);
                if (!verificationResults.AllItemsAvailable)
                {
                    return new Response(-1, "Một số mặt hàng trong giỏ hàng không còn khả dụng",
                        new { UnavailableItems = verificationResults.UnavailableItems });
                }

                return new Response(0, "Giỏ hàng hợp lệ để thanh toán", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying cart before payment for order {OrderId}", orderId);
                return new Response(-1, "Error verifying cart", null);
            }
        }


        //fix before use, questionale logic
        public async Task<Response> ProcessRefundAsync(int paymentId, decimal refundAmount, string reason)
        {
            try
            {
                var payment = await _unitOfWork.Repository<Payment>().FindAsync(p => p.PaymentId == paymentId);
                if (payment == null)
                {
                    return new Response(-1, "Thanh toán không được tìm thấy", null);
                }

                // Validate refund amount
                if (refundAmount <= 0 || refundAmount > payment.Price)
                {
                    return new Response(-1, "Số tiền hoàn trả không hợp lệ", null);
                }

                // Create refund record
                var refund = new Payment
                {
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                    UserId = payment.UserId,
                    OrderId = payment.OrderId,
                    Price = -refundAmount, // Negative amount for refunds
                    Type = payment.Type,
                    Status = PaymentStatus.Refunded, // Assume refund is processed immediately
                    Purpose = PaymentPurpose.DepositRefund,
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(refund);

                // If this is a full refund and it's for the main order payment
                if (refundAmount == payment.Price && payment.Purpose == PaymentPurpose.OrderPayment)
                {
                    // Get the order
                    var order = await GetOrderByIdAsync(payment.OrderId.Value);

                    // Only allow refunds for certain order statuses
                    if (order.Status != OrderStatus.Cancelled && order.Status != OrderStatus.Completed &&
                        order.Status != OrderStatus.Returning)
                    {
                        // Update order status to Cancelled
                        order.Status = OrderStatus.Cancelled;
                        order.SetUpdateDate();
                        await _unitOfWork.Repository<Order>().Update(order, order.OrderId);

                        if (order.Status == OrderStatus.Pending)
                        {
                            // Return inventory for sell items
                            if (order.SellOrder != null)
                            {
                                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                                {
                                    if (detail.IngredientId.HasValue)
                                    {
                                        await _ingredientService.UpdateIngredientQuantityAsync(
                                            detail.IngredientId.Value, detail.Quantity);
                                    }
                                    else if (detail.UtensilId.HasValue)
                                    {
                                        await _utensilService.UpdateUtensilQuantityAsync(
                                            detail.UtensilId.Value, detail.Quantity);
                                    }
                                }
                            }

                            // Return hotpots to available
                            if (order.HasRentItems)
                            {
                                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                                {
                                    if (detail.HotpotInventoryId.HasValue)
                                    {
                                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                            .GetById(detail.HotpotInventoryId.Value);

                                        if (hotpotInventory != null)
                                        {
                                            hotpotInventory.Status = HotpotStatus.Available;
                                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                await _unitOfWork.CommitAsync();

                // If it's an online payment, we might need to process the refund through PayOS
                if (payment.Type == PaymentType.Online)
                {
                    // This would depend on PayOS's refund API
                    // await _payOS.processRefund(payment.TransactionCode, refundAmount, reason);
                }

                return new Response(0, "Hoàn tiền thành công", refund);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing refund for payment {PaymentId}", paymentId);
                return new Response(-1, "Error processing refund", null);
            }
        }




        /// <summary>
        /// Unified method to verify cart items availability
        /// </summary>
        private async Task<CartVerificationResult> VerifyCartItemsAvailabilityAsync(Order order)
        {
            var result = new CartVerificationResult
            {
                AllItemsAvailable = true,
                UnavailableItems = new List<string>()
            };

            // Check sell items
            if (order.SellOrder != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.IngredientId.HasValue)
                    {
                        var ingredient = await _ingredientService.GetIngredientByIdAsync(detail.IngredientId.Value);
                        if (ingredient == null)
                        {
                            result.AllItemsAvailable = false;
                            result.UnavailableItems.Add($"Nguyên liệu ID {detail.IngredientId.Value} không được tìm thấy");
                            continue;
                        }

                        if (ingredient.Quantity < detail.Quantity)
                        {
                            result.AllItemsAvailable = false;
                            result.UnavailableItems.Add($"{ingredient.Name} (chỉ còn {ingredient.Quantity} sẵn có)");
                        }
                    }
                    else if (detail.UtensilId.HasValue)
                    {
                        var utensil = await _utensilService.GetUtensilByIdAsync(detail.UtensilId.Value);
                        if (utensil == null)
                        {
                            result.AllItemsAvailable = false;
                            result.UnavailableItems.Add($"Dụng cụ ID {detail.UtensilId.Value} không được tìm thấy");
                            continue;
                        }

                        if (utensil.Quantity < detail.Quantity)
                        {
                            result.AllItemsAvailable = false;
                            result.UnavailableItems.Add($"{utensil.Name} (chỉ còn {utensil.Quantity} sẵn có)");
                        }
                    }
                }
            }

            // Check rent items (hotpots)
            if (order.HasRentItems)
            {
                // Extract hotpot inventory IDs from the order
                var hotpotInventoryIds = order.RentOrder.RentOrderDetails
                    .Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue)
                    .Select(d => d.HotpotInventoryId.Value)
                    .ToList();

                // Fetch all relevant hotpot inventories in a single query
                var hotpotInventories = await _unitOfWork.Repository<HotPotInventory>()
                    .IncludeNested(query => query.Include(h => h.Hotpot))
                    .Where(h => hotpotInventoryIds.Contains(h.HotPotInventoryId)).ToListAsync();

                // Group hotpots by type to check total availability
                var hotpotCounts = new Dictionary<int, int>(); // HotpotId -> Count

                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                {
                    var hotpotInventory = hotpotInventories.FirstOrDefault(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                    if (hotpotInventory?.Hotpot != null)
                    {
                        int hotpotId = hotpotInventory.Hotpot.HotpotId;

                        if (!hotpotCounts.ContainsKey(hotpotId))
                        {
                            hotpotCounts[hotpotId] = 0;
                        }

                        hotpotCounts[hotpotId]++;
                    }
                }

                // Check availability for each hotpot type
                foreach (var kvp in hotpotCounts)
                {
                    int hotpotId = kvp.Key;
                    int requiredCount = kvp.Value;

                    // Get the hotpot
                    var hotpot = await _unitOfWork.Repository<Hotpot>().GetById(hotpotId);
                    if (hotpot == null)
                    {
                        result.AllItemsAvailable = false;
                        result.UnavailableItems.Add($"Nồi lẩu ID {hotpotId} không còn khả dụng");
                        continue;
                    }

                    // Count available hotpots of this type
                    var availableCount = await CountHotpotInventoryByStatusAsync(hotpotId,
                        new List<HotpotStatus> { HotpotStatus.Available, HotpotStatus.Reserved });

                    if (availableCount < requiredCount)
                    {
                        result.AllItemsAvailable = false;
                        result.UnavailableItems.Add($"{hotpot.Name} (chỉ còn {availableCount} sẵn có)");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Unified method to finalize inventory deduction after payment
        /// </summary>
        private async Task FinalizeInventoryDeduction(Order order)
        {
            // This method actually deducts inventory quantities after payment is confirmed
            if (order.HasSellItems != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.IngredientId.HasValue)
                    {
                        try
                        {
                            // Use the updated ConsumeIngredientAsync method
                            int consumed = await _ingredientService.ConsumeIngredientAsync(
                                detail.IngredientId.Value,
                                detail.Quantity,
                                order.OrderId,
                                detail.SellOrderDetailId);

                            if (consumed < detail.Quantity)
                            {
                                // Log a warning if we couldn't consume the full amount
                                _logger.LogWarning(
                                    "Could not consume full quantity for ingredient ID {IngredientId}. Requested: {Requested}, Consumed: {Consumed}",
                                    detail.IngredientId.Value,
                                    detail.Quantity,
                                    consumed);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log the error but continue processing other items
                            _logger.LogError(ex,
                                "Error consuming ingredient ID {IngredientId} with quantity {Quantity}",
                                detail.IngredientId.Value,
                                detail.Quantity);
                        }
                    }
                    else if (detail.ComboId.HasValue)
                    {
                        // For combos, we need to get the ingredients and consume them
                        var combo = await _comboService.GetByIdAsync(detail.ComboId.Value);
                        if (combo != null && combo.ComboIngredients != null)
                        {
                            foreach (var comboIngredient in combo.ComboIngredients.Where(ci => !ci.IsDelete))
                            {
                                try
                                {
                                    // Calculate quantity needed based on order size
                                    int quantityNeeded = comboIngredient.Quantity * detail.Quantity;

                                    // Consume the ingredient
                                    int consumed = await _ingredientService.ConsumeIngredientAsync(
                                        comboIngredient.IngredientId,
                                        quantityNeeded,
                                        order.OrderId,
                                        detail.SellOrderDetailId,
                                        detail.ComboId);

                                    if (consumed < quantityNeeded)
                                    {
                                        _logger.LogWarning(
                                            "Could not consume full quantity for ingredient ID {IngredientId} in combo {ComboId}. Requested: {Requested}, Consumed: {Consumed}",
                                            comboIngredient.IngredientId,
                                            detail.ComboId.Value,
                                            quantityNeeded,
                                            consumed);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex,
                                        "Error consuming ingredient ID {IngredientId} for combo {ComboId}",
                                        comboIngredient.IngredientId,
                                        detail.ComboId.Value);
                                }
                            }
                        }
                    }
                    else if (detail.CustomizationId.HasValue)
                    {
                        // For customizations, we need to get the ingredients and consume them
                        var customization = await _customizationService.GetByIdAsync(detail.CustomizationId.Value);
                        if (customization != null && customization.CustomizationIngredients != null)
                        {
                            foreach (var customizationIngredient in customization.CustomizationIngredients.Where(ci => !ci.IsDelete))
                            {
                                try
                                {
                                    // Calculate quantity needed based on order size
                                    int quantityNeeded = customizationIngredient.Quantity * detail.Quantity;

                                    // Consume the ingredient
                                    int consumed = await _ingredientService.ConsumeIngredientAsync(
                                        customizationIngredient.IngredientId,
                                        quantityNeeded,
                                        order.OrderId,
                                        detail.SellOrderDetailId,
                                        null,
                                        detail.CustomizationId);

                                    if (consumed < quantityNeeded)
                                    {
                                        _logger.LogWarning(
                                            "Could not consume full quantity for ingredient ID {IngredientId} in customization {CustomizationId}. Requested: {Requested}, Consumed: {Consumed}",
                                            customizationIngredient.IngredientId,
                                            detail.CustomizationId.Value,
                                            quantityNeeded,
                                            consumed);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex,
                                        "Error consuming ingredient ID {IngredientId} for customization {CustomizationId}",
                                        customizationIngredient.IngredientId,
                                        detail.CustomizationId.Value);
                                }
                            }
                        }
                    }
                    else if (detail.UtensilId.HasValue)
                    {
                        var utensil = await _utensilService.GetUtensilByIdAsync(detail.UtensilId.Value);
                        if (utensil != null)
                        {
                            // Deduct from inventory
                            utensil.Quantity -= detail.Quantity;
                            await _unitOfWork.Repository<Utensil>().Update(utensil, utensil.UtensilId);
                        }
                    }
                }
            }

            // For hotpots, we update their status to Rented
            if (order.HasRentItems)
            {
                // Track which hotpot types need quantity updates
                var hotpotIdsToUpdate = new HashSet<int>();

                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.HotpotInventoryId.HasValue)
                    {
                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .IncludeNested(query => query.Include(h => h.Hotpot))
                            .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                        if (hotpotInventory != null)
                        {
                            // Add the hotpot ID to the set of IDs to update
                            hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);

                            // Update the inventory status
                            hotpotInventory.Status = HotpotStatus.Rented;
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }

                // Update the quantity for each affected hotpot type
                //foreach (var hotpotId in hotpotIdsToUpdate)
                //{
                //    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                //}
            }
        }

        public async Task<bool> UpdateHotpotQuantityFromInventoryAsync(int hotpotId)
        {
            try
            {
                // Get the hotpot
                var hotpot = await _unitOfWork.Repository<Hotpot>().GetById(hotpotId);
                if (hotpot == null)
                {
                    _logger.LogWarning("Cannot update quantity for non-existent hotpot ID {HotpotId}", hotpotId);
                    return false;
                }

                // Count available inventory
                int availableCount = await CountHotpotInventoryByStatusAsync(hotpotId,
                    new List<HotpotStatus> { HotpotStatus.Available, HotpotStatus.Reserved });

                // Update hotpot quantity
                // hotpot.Quantity = availableCount;
                hotpot.SetUpdateDate();

                await _unitOfWork.Repository<Hotpot>().Update(hotpot, hotpotId);

                _logger.LogInformation("Updated hotpot {HotpotId} quantity to {Quantity} based on inventory count",
                    hotpotId, availableCount);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot quantity from inventory for hotpot ID {HotpotId}", hotpotId);
                return false;
            }
        }

        /// <summary>
        /// Count hotpot inventory by status
        /// </summary>
        private async Task<int> CountHotpotInventoryByStatusAsync(int hotpotId, List<HotpotStatus> statuses)
        {
            try
            {
                // Query for the specific hotpot type with the given statuses
                var count = await _unitOfWork.Repository<HotPotInventory>()
                    .CountAsync(h => h.HotpotId == hotpotId &&
                                   statuses.Contains(h.Status) &&
                                   !h.IsDelete);

                return count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error counting hotpot inventory for hotpot ID {HotpotId}", hotpotId);
                return 0; // Return 0 on error to be safe
            }
        }

        /// <summary>
        /// Release inventory reservations when cancelling an order
        /// </summary>
        private async Task ReleaseInventoryReservation(Order order)
        {
            // For hotpots, we need to update their status back to Available
            if (order.HasRentItems)
            {
                // Track which hotpot types need quantity updates
                var hotpotIdsToUpdate = new HashSet<int>();

                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.HotpotInventoryId.HasValue)
                    {
                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .IncludeNested(query => query.Include(h => h.Hotpot))
                            .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                        if (hotpotInventory != null &&
                            (hotpotInventory.Status == HotpotStatus.Reserved || hotpotInventory.Status == HotpotStatus.Rented))
                        {
                            // Add the hotpot ID to the set of IDs to update
                            hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);

                            // Update the inventory status
                            hotpotInventory.Status = HotpotStatus.Available;


                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }

                // Update the quantity for each affected hotpot type
                //foreach (var hotpotId in hotpotIdsToUpdate)
                //{
                //    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                //}
            }

            // For ingredients and utensils, we don't need to do anything since we didn't deduct them yet
        }

        public async Task<Response> ProcessDepositRefundAsync(int orderId, decimal refundAmount, string notes)
        {
            try
            {
                var order = await GetOrderByIdAsync(orderId);

                // Validate order has rental items
                if (order.RentOrder == null)
                {
                    return new Response(-1, "Đơn hàng không có sản phẩm cho thuê", null);
                }

                // Validate order status
                if (order.Status != OrderStatus.Completed && order.Status != OrderStatus.Returning)
                {
                    return new Response(-1, "Không thể xử lý hoàn tiền cọc cho đơn hàng không phải đã hoàn thành hoặc đang trả hàng", null);
                }

                // Calculate the deposit amount (70% of rental price)
                decimal totalRentalPrice = order.RentOrder.SubTotal;
                decimal depositAmount = totalRentalPrice * 0.7m;

                // Validate refund amount
                if (refundAmount <= 0 || refundAmount > depositAmount)
                {
                    return new Response(-1, $"Số tiền hoàn trả không hợp lệ. Số tiền cọc tối đa có thể hoàn là ${depositAmount}", null);
                }

                // Get the main payment
                var mainPayment = await GetMainPaymentForOrderAsync(orderId);
                if (mainPayment == null)
                {
                    return new Response(-1, "Không tìm thấy thanh toán chính", null);
                }

                // Create refund record
                var refund = new Payment
                {
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                    UserId = order.UserId,
                    OrderId = orderId,
                    Price = -refundAmount, // Negative amount for refunds
                    Type = mainPayment.Type,
                    Status = PaymentStatus.Success, // Assume refund is processed immediately
                    Purpose = PaymentPurpose.DepositRefund,
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(refund);
                await _unitOfWork.CommitAsync();

                // If it's an online payment, we might need to process the refund through PayOS
                if (mainPayment.Type == PaymentType.Online)
                {
                    // This would depend on PayOS's refund API
                    // await _payOS.processRefund(mainPayment.TransactionCode, refundAmount, notes);
                }

                return new Response(0, "Hoàn tiền cọc đã được xử lý thành công", refund);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xử lý hoàn tiền cọc cho đơn hàng {OrderId}", orderId);
                return new Response(-1, "Lỗi khi xử lý hoàn tiền cọc", null);
            }
        }

        public async Task<Response> GetPaymentSummaryAsync(int orderId)
        {
            try
            {
                var order = await GetOrderByIdAsync(orderId);
                var payments = await GetListPaymentByOrderIdAsync(orderId);

                // Calculate totals
                decimal totalPaid = payments
                    .Where(p => p.Status == PaymentStatus.Success && p.Price > 0)
                    .Sum(p => p.Price);

                decimal totalRefunded = payments
                    .Where(p => p.Status == PaymentStatus.Success && p.Price < 0)
                    .Sum(p => -p.Price);

                decimal totalFees = payments
                    .Where(p => p.Status == PaymentStatus.Success &&
                           (p.Purpose == PaymentPurpose.LateFee || p.Purpose == PaymentPurpose.DamageFee))
                    .Sum(p => p.Price);

                // Calculate deposit amount if rental
                decimal depositAmount = 0;
                decimal depositRefunded = 0;

                if (order.HasRentItems)
                {
                    depositAmount = order.RentOrder.SubTotal * 0.7m;

                    depositRefunded = payments
                     .Where(p => p.Status == PaymentStatus.Success && p.Purpose == PaymentPurpose.DepositRefund)
                     .Sum(p => -p.Price);
                }

                // Create summary
                var summary = new PaymentSummary
                {
                    OrderId = orderId,
                    OrderStatus = order.Status,
                    TotalOrderAmount = order.TotalPrice,
                    TotalPaid = totalPaid,
                    TotalRefunded = totalRefunded,
                    TotalFees = totalFees,
                    DepositAmount = depositAmount,
                    DepositRefunded = depositRefunded,
                    RemainingDepositToRefund = depositAmount - depositRefunded,
                    Payments = payments.ToList()
                };

                return new Response(0, "Tổng kết thanh toán đã được lấy thành công", summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy tổng kết thanh toán cho đơn hàng {OrderId}", orderId);
                return new Response(-1, "Lỗi khi lấy tổng kết thanh toán", null);
            }
        }

        /// <summary>
        /// Update order details
        /// </summary>
        private async Task<Order> OrderUpdateAsync(int id, UpdateOrderRequest request)
        {
            try
            {
                var order = await GetOrderByIdAsync(id);

                // Only allow updates for cart or pending orders
                if (order.Status != OrderStatus.Cart && order.Status != OrderStatus.Pending)
                    throw new ValidationException("Chỉ có thể cập nhật đơn hàng trong giỏ hàng hoặc đang chờ xử lý");

                // Update order properties
                if (!string.IsNullOrWhiteSpace(request.Address))
                    order.Address = request.Address;

                if (!string.IsNullOrWhiteSpace(request.Notes))
                    order.Notes = request.Notes;

                //// With this safer logic:
                //var totalPriceProp = request.GetType().GetProperty(nameof(request.TotalPrice));
                //if (totalPriceProp != null)
                //{
                //    var providedValue = totalPriceProp.GetValue(request);
                //    // Only update if the property is set and not null
                //    if (providedValue != null)
                //    {
                //        var price = (decimal)providedValue;
                //        if (price <= 0)
                //        {
                //            throw new ValidationException("Tổng tiền không hợp lệ (không thể là 0 hoặc nhỏ hơn 0). Vui lòng kiểm tra lại giá trị tổng tiền.");
                //        }
                //        order.TotalPrice = price;
                //    }
                //}

                // Update delivery time if provided
                if (request.DeliveryTime.HasValue)
                {
                    // Get current time in UTC+7
                    DateTime currentTimeUtc7 = DateTime.UtcNow.AddHours(7);

                    // Add buffer time
                    DateTime minimumDeliveryTimeUtc7 = currentTimeUtc7.AddMinutes(30);

                    // Normalize the delivery time to UTC+7 if it's in UTC
                    DateTime deliveryTimeUtc7;
                    if (request.DeliveryTime.Value.Kind == DateTimeKind.Utc)
                    {
                        // Convert from UTC to UTC+7
                        deliveryTimeUtc7 = request.DeliveryTime.Value.AddHours(7);
                    }
                    else
                    {
                        // If it's not explicitly UTC, assume it's already in UTC+7 or local time
                        deliveryTimeUtc7 = request.DeliveryTime.Value;
                    }

                    // Log values for debugging if needed
                    Console.WriteLine($"Current time (UTC+7): {currentTimeUtc7:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"Minimum delivery time (UTC+7): {minimumDeliveryTimeUtc7:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"Requested delivery time (normalized to UTC+7): {deliveryTimeUtc7:yyyy-MM-dd HH:mm:ss}");

                    // Compare times in the same time zone
                    if (deliveryTimeUtc7 <= minimumDeliveryTimeUtc7)
                    {
                        throw new ValidationException($"Thời gian giao hàng phải ít nhất là {minimumDeliveryTimeUtc7.ToString("HH:mm dd/MM/yyyy")}");
                    }

                    // Store the delivery time in the database
                    // You might want to standardize on UTC for storage
                    order.DeliveryTime = deliveryTimeUtc7;
                }

                // Update rental dates if provided and order has rental items
                if (order.HasRentItems && request.ExpectedReturnDate.HasValue)
                {
                    DateTime today = DateTime.UtcNow.AddHours(7);
                    order.RentOrder.RentalStartDate = today;
                    DateTime expectedReturnDate = request.ExpectedReturnDate.Value.AddHours(7);

                    // Validate expected return date is after rental start date
                    if (expectedReturnDate <= today)
                    {
                        throw new ValidationException("Ngày trả dự kiến phải là ngày trong tương lai");
                    }

                    if (request.ExpectedReturnDate.HasValue &&
                        request.ExpectedReturnDate.Value <= order.RentOrder.RentalStartDate)
                    {
                        throw new ValidationException("Ngày trả dự kiến phải là ít nhất một ngày sau ngày bắt đầu cho thuê");
                    }
                    order.RentOrder.ExpectedReturnDate = expectedReturnDate;
                    await _unitOfWork.Repository<RentOrder>().Update(order.RentOrder, order.RentOrder.OrderId);
                }

                // Update discount if provided
                if (request.DiscountId.HasValue && request.DiscountId != order.DiscountId)
                {
                    var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
                    if (discount == null)
                        throw new ValidationException($"Không tìm thấy khuyến mãi với ID {request.DiscountId}");

                    // Validate discount is still valid
                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                        throw new ValidationException("Khuyến mãi đã chọn không hợp lệ hoặc đã hết hạn");

                    // Only update the discount ID, not the price
                    order.DiscountId = request.DiscountId;
                }
                else if (request.DiscountId == null && order.DiscountId.HasValue)
                {
                    // Remove discount ID, but don't change the price
                    order.DiscountId = null;
                }



                // Update order
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, id);
                await _unitOfWork.CommitAsync();

                return await GetOrderByIdAsync(id);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order {OrderId}", id);
                throw;
            }
        }


        /// <summary>
        /// Get order by ID with all related entities
        /// </summary>
        private async Task<Order> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payments)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Ingredient)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Customization)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Combo)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Utensil)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                            .ThenInclude(od => od.HotpotInventory)
                                .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Không tìm thấy đơn hàng với ID {id}");

                return order;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order {OrderId}", id);
                throw;
            }
        }
    }
}
