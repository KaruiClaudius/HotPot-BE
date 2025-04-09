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

        public PaymentService(
            PayOS payOS,
            IUnitOfWork unitOfWork,
            ILogger<PaymentService> logger,
            IDiscountService discountService,
            IIngredientService ingredientService,
            IUtensilService utensilService)
        {
            _payOS = payOS;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _discountService = discountService;
            _ingredientService = ingredientService;
            _utensilService = utensilService;
        }

        public async Task<Response> ProcessOnlinePayment(int orderId, string address, string notes, int? discountId, DateTime? expectedReturnDate, CreatePaymentLinkRequest paymentRequest, int userId)
        {
            try
            {
                // 1. Get the order with all details
                var order = await GetOrderByIdAsync(orderId);

                // 2. Verify inventory availability
                var verificationResults = await VerifyCartItemsAvailabilityAsync(order);
                if (!verificationResults.AllItemsAvailable)
                {
                    return new Response(-1, $"Some items in your cart are no longer available: {string.Join(", ", verificationResults.UnavailableItems)}", null);
                }

                if (order.HasRentItems)
                {
                    // Get current time with offset (local current time)
                    DateTime currentTime = DateTime.UtcNow.AddHours(7);

                    // Check if provided date is valid (future compared to current time)
                    if (!expectedReturnDate.HasValue || expectedReturnDate.Value <= currentTime)
                    {
                        throw new ValidationException("Expected return date must be in the future");
                    }
                }
                // 3. Update the order details
                var updateRequest = new UpdateOrderRequest
                {
                    Address = address,
                    Notes = notes,
                    DiscountId = discountId,
                    ExpectedReturnDate = expectedReturnDate
                };

                try
                {
                    await OrderUpdateAsync(orderId, updateRequest);
                }
                catch (ValidationException ex)
                {
                    return new Response(-1, ex.Message, null);
                }

                // 4. Get user information
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == paymentRequest.buyerPhone);
                if (user == null)
                {
                    return new Response(-1, "User not found", null);
                }

                // 5. Generate transaction code
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                // 6. Create payment data
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

                // 7. Create payment link
                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                // 8. Create payment record
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
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error processing online payment for order {OrderId}", orderId);
                return new Response(-1, $"{exception.Message}", null);
            }
        }

        public async Task<Payment> ProcessCashPayment(int orderId, string address, string notes, int? discountId, DateTime? expectedReturnDate, int userId)
        {
            try
            {
                // 1. Get the order with all details
                var order = await GetOrderByIdAsync(orderId);

                // 2. Verify inventory availability
                var verificationResults = await VerifyCartItemsAvailabilityAsync(order);
                if (!verificationResults.AllItemsAvailable)
                {
                    throw new ValidationException($"Some items in your cart are no longer available: {string.Join(", ", verificationResults.UnavailableItems)}");
                }

                // 3. Update the order details
                var updateRequest = new UpdateOrderRequest
                {
                    Address = address,
                    Notes = notes,
                    DiscountId = discountId,
                    ExpectedReturnDate = expectedReturnDate
                };

                order = await OrderUpdateAsync(orderId, updateRequest);

                // 4. Create payment record
                var payment = new Payment
                {
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                    UserId = userId,
                    OrderId = orderId,
                    Price = order.TotalPrice,
                    Type = PaymentType.Cash,
                    Status = PaymentStatus.Pending,
                    Purpose = PaymentPurpose.OrderPayment
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(payment);

                // 5. Finalize inventory deduction for cash payments
                await FinalizeInventoryDeduction(order);

                // 6. Update order status to Processing
                order.Status = OrderStatus.Processing;
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
                    return new Response(-1, "Transaction not found", null);
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
                var paymentTransaction = (await _unitOfWork.Repository<Payment>()
                    .GetWhere(pt => pt.TransactionCode == orderCode)).SingleOrDefault();

                if (paymentTransaction == null)
                {
                    return new Response(-1, "Transaction not found", null);
                }

                // Get the order
                var order = await GetOrderByIdAsync(paymentTransaction.OrderId.Value);

                // Update payment status
                paymentTransaction.Status = PaymentStatus.Cancelled;
                paymentTransaction.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);

                // Release inventory reservations
                await ReleaseInventoryReservation(order);

                await _unitOfWork.CommitAsync();

                // Cancel the payment link in PayOS
                PaymentLinkInformation paymentLinkInformation = await _payOS.cancelPaymentLink(orderCode, reason);

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
            try
            {
                // Use AsNoTracking for the initial query if you're going to update later
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == userPhone);
                if (user == null)
                {
                    return new Response(-1, "User not found", null);
                }


                PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInformation(request.OrderCode);
                if (paymentLinkInformation == null)
                {
                    return new Response(-1, "Payment information not found", null);
                }


                var paymentTransaction = (await _unitOfWork.Repository<Payment>()
                    .GetWhere(pt => pt.TransactionCode == request.OrderCode)).SingleOrDefault();
                if (paymentTransaction == null)
                {
                    return new Response(-1, "Transaction not found", null);
                }

                // Get the order
                var order = await GetOrderByIdAsync(paymentTransaction.OrderId.Value);


                if (paymentLinkInformation.status == "PAID" && paymentTransaction.Status == PaymentStatus.Pending)
                {
                    // Update transaction
                    paymentTransaction.Status = PaymentStatus.Success;
                    paymentTransaction.UpdatedAt = DateTime.UtcNow;
                    await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);

                    // Finalize inventory deduction
                    await FinalizeInventoryDeduction(order);

                    // Update order status to Processing
                    order.Status = OrderStatus.Processing;
                    order.SetUpdateDate();
                    await _unitOfWork.Repository<Order>().Update(order, order.OrderId);

                    await _unitOfWork.CommitAsync();

                    var updatedUserInfo = new
                    {
                        user.UserId,
                        user.Name,
                        user.PhoneNumber,
                    };

                    return new Response(0, "Transaction Complete",
                        new { paymentInfo = paymentLinkInformation, userInfo = updatedUserInfo });
                }
                else if (paymentLinkInformation.status == "CANCELLED")
                {
                    // Update transaction
                    paymentTransaction.Status = PaymentStatus.Cancelled;
                    paymentTransaction.UpdatedAt = DateTime.UtcNow;
                    await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);

                    // Release inventory reservations
                    await ReleaseInventoryReservation(order);

                    await _unitOfWork.CommitAsync();

                    var updatedUserInfo = new
                    {
                        user.UserId,
                        user.Name,
                        user.PhoneNumber,
                    };

                    return new Response(0, "Transaction Cancelled",
                        new { paymentInfo = paymentLinkInformation, userInfo = updatedUserInfo });
                }
                else
                {
                    return new Response(0, "Payment not completed yet",
                        new { paymentInfo = paymentLinkInformation });
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error checking order {OrderCode}", request.OrderCode);
                return new Response(-1, "fail", null);
            }
        }

        public async Task<Payment> UpdatePaymentStatusAsync(int paymentId, PaymentStatus status)
        {
            try
            {
                var payment = await _unitOfWork.Repository<Payment>().FindAsync(p => p.PaymentId == paymentId);
                if (payment == null)
                {
                    throw new NotFoundException($"Payment with ID {paymentId} not found");
                }

                payment.Status = status;
                payment.UpdatedAt = DateTime.UtcNow;

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
                    throw new ArgumentException("Fee type must be either LateFee or DamageFee");
                }

                // Get the order
                var order = await GetOrderByIdAsync(orderId);

                // Validate order status - only allow additional fees for orders that are not pending
                if (order.Status == OrderStatus.Pending)
                {
                    throw new ValidationException("Cannot add additional fees to pending orders");
                }

                // Validate that the order has a rent order
                if (order.RentOrder == null)
                {
                    throw new ValidationException("Cannot add additional fees to orders without rental items");
                }

                // Create payment record
                var payment = new Payment
                {
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
                    UserId = order.UserId,
                    OrderId = orderId,
                    Price = amount,
                    Type = paymentType,
                    Status = PaymentStatus.Pending,
                    Purpose = feeType
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(payment);

                // Update the RentOrder with the fee amount
                if (feeType == PaymentPurpose.LateFee)
                {
                    order.RentOrder.LateFee = (order.RentOrder.LateFee ?? 0) + amount;
                    if (!string.IsNullOrEmpty(notes))
                    {
                        order.RentOrder.RentalNotes = string.IsNullOrEmpty(order.RentOrder.RentalNotes)
                            ? $"Late Fee: {notes}"
                            : $"{order.RentOrder.RentalNotes}\nLate Fee: {notes}";
                    }
                }
                else if (feeType == PaymentPurpose.DamageFee)
                {
                    order.RentOrder.DamageFee = (order.RentOrder.DamageFee ?? 0) + amount;
                    if (!string.IsNullOrEmpty(notes))
                    {
                        order.RentOrder.ReturnCondition = string.IsNullOrEmpty(order.RentOrder.ReturnCondition)
                            ? $"Damage Fee: {notes}"
                            : $"{order.RentOrder.ReturnCondition}\nDamage Fee: {notes}";
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
                    throw new ValidationException("Order does not have rental items");
                }

                // Check if any hotpot items exist in the order
                bool hasHotpot = order.RentOrder.RentOrderDetails.Any(d => d.HotpotInventoryId.HasValue);
                if (!hasHotpot)
                {
                    throw new ValidationException("Order does not have any hotpot items");
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
                order.RentOrder.ActualReturnDate = DateTime.UtcNow;

                // Set the return condition
                if (!string.IsNullOrEmpty(returnCondition))
                {
                    order.RentOrder.ReturnCondition = returnCondition;
                }

                decimal totalFee = 0;
                string feeDescription = "";

                // Calculate late fee if returned after expected date
                if (order.RentOrder.ExpectedReturnDate < DateTime.UtcNow)
                {
                    // Calculate days late
                    int daysLate = (int)Math.Ceiling((DateTime.UtcNow - order.RentOrder.ExpectedReturnDate).TotalDays);

                    // Calculate late fee (example: $5 per day late)
                    decimal lateFee = daysLate * 5.0m; // You might want to make this configurable

                    // Set the late fee
                    order.RentOrder.LateFee = lateFee;

                    totalFee += lateFee;
                    feeDescription += $"Late return fee for {daysLate} days: ${lateFee}";
                }

                // Add damage fee if provided
                if (damageFee.HasValue && damageFee.Value > 0)
                {
                    order.RentOrder.DamageFee = damageFee.Value;

                    totalFee += damageFee.Value;
                    feeDescription += (feeDescription.Length > 0 ? "\n" : "") + $"Damage fee: ${damageFee.Value} - {returnCondition}";
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
                foreach (var hotpotId in hotpotIdsToUpdate)
                {
                    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                }

                await _unitOfWork.CommitAsync();

                return await GetOrderByIdAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording hotpot return for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAll(p => p.UserId == userId)
                    .Include(p => p.Order)
                    .ToListAsync();
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
                    return new Response(-1, "Some items in your cart are no longer available",
                        new { UnavailableItems = verificationResults.UnavailableItems });
                }

                return new Response(0, "Cart is valid for payment", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying cart before payment for order {OrderId}", orderId);
                return new Response(-1, "Error verifying cart", null);
            }
        }


        public async Task<Response> ProcessRefundAsync(int paymentId, decimal refundAmount, string reason)
        {
            try
            {
                var payment = await _unitOfWork.Repository<Payment>().FindAsync(p => p.PaymentId == paymentId);
                if (payment == null)
                {
                    return new Response(-1, "Payment not found", null);
                }

                // Validate refund amount
                if (refundAmount <= 0 || refundAmount > payment.Price)
                {
                    return new Response(-1, "Invalid refund amount", null);
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

                        // If the order has already been processed (items shipped), we can't return inventory
                        if (order.Status == OrderStatus.Processing)
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
                            if (order.RentOrder != null)
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

                return new Response(0, "Refund processed successfully", refund);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing refund for payment {PaymentId}", paymentId);
                return new Response(-1, "Error processing refund", null);
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
                    new List<HotpotStatus> { HotpotStatus.Available });

                // Update hotpot quantity
                hotpot.Quantity = availableCount;
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
                        if (ingredient.Quantity < detail.Quantity)
                        {
                            result.AllItemsAvailable = false;
                            result.UnavailableItems.Add($"{ingredient.Name} (only {ingredient.Quantity} available)");
                        }
                    }
                    else if (detail.UtensilId.HasValue)
                    {
                        var utensil = await _utensilService.GetUtensilByIdAsync(detail.UtensilId.Value);
                        if (utensil.Quantity < detail.Quantity)
                        {
                            result.AllItemsAvailable = false;
                            result.UnavailableItems.Add($"{utensil.Name} (only {utensil.Quantity} available)");
                        }
                    }
                }
            }

            // Check rent items (hotpots)
            if (order.RentOrder != null)
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
                        result.UnavailableItems.Add($"Hotpot ID {hotpotId} is no longer available");
                        continue;
                    }

                    // Count available hotpots of this type
                    var availableCount = await CountHotpotInventoryByStatusAsync(hotpotId,
                        new List<HotpotStatus> { HotpotStatus.Available });

                    if (availableCount < requiredCount)
                    {
                        result.AllItemsAvailable = false;
                        result.UnavailableItems.Add($"{hotpot.Name} (only {availableCount} available)");
                    }
                }
            }

            return result;
        }

        private async Task FinalizeInventoryDeduction(Order order)
        {
            // This method actually deducts inventory quantities after payment is confirmed
            if (order.SellOrder != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.IngredientId.HasValue)
                    {
                        await _ingredientService.UpdateIngredientQuantityAsync(
                            detail.IngredientId.Value, -detail.Quantity);
                    }
                    else if (detail.UtensilId.HasValue)
                    {
                        await _utensilService.UpdateUtensilQuantityAsync(
                            detail.UtensilId.Value, -detail.Quantity);
                    }
                }
            }

            // For hotpots, we just need to update their status to Rented
            if (order.RentOrder != null)
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
                foreach (var hotpotId in hotpotIdsToUpdate)
                {
                    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                }
            }
        }

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

        private async Task ReleaseInventoryReservation(Order order)
        {
            // This method releases all reservations for an order
            // For hotpots, we need to update their status back to Available
            if (order.RentOrder != null)
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
                foreach (var hotpotId in hotpotIdsToUpdate)
                {
                    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                }
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
                    return new Response(-1, "Order does not have rental items", null);
                }

                // Validate order status
                if (order.Status != OrderStatus.Completed && order.Status != OrderStatus.Returning)
                {
                    return new Response(-1, "Cannot process deposit refund for orders that are not completed or returned", null);
                }

                // Calculate the deposit amount (70% of rental price)
                decimal totalRentalPrice = order.RentOrder.SubTotal;
                decimal depositAmount = totalRentalPrice * 0.7m;

                // Validate refund amount
                if (refundAmount <= 0 || refundAmount > depositAmount)
                {
                    return new Response(-1, $"Invalid refund amount. Maximum refundable deposit is ${depositAmount}", null);
                }

                // Get the main payment
                var mainPayment = await GetMainPaymentForOrderAsync(orderId);
                if (mainPayment == null)
                {
                    return new Response(-1, "Main payment not found", null);
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

                return new Response(0, "Deposit refund processed successfully", refund);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing deposit refund for order {OrderId}", orderId);
                return new Response(-1, "Error processing deposit refund", null);
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

                if (order.RentOrder != null)
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

                return new Response(0, "Payment summary retrieved successfully", summary);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment summary for order {OrderId}", orderId);
                return new Response(-1, "Error getting payment summary", null);
            }
        }

        public async Task<Response> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            try
            {
                var order = await GetOrderByIdAsync(orderId);

                // Validate status transition
                if (!IsValidStatusTransition(order.Status, newStatus))
                {
                    return new Response(-1, $"Invalid status transition from {order.Status} to {newStatus}", null);
                }

                // Track which hotpot types need quantity updates
                var hotpotIdsToUpdate = new HashSet<int>();

                // Handle inventory based on status change
                if (newStatus == OrderStatus.Delivered && order.RentOrder != null)
                {
                    // Update hotpot inventory status to Rented
                    foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                    {
                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .IncludeNested(query => query.Include(h => h.Hotpot))
                            .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                        if (hotpotInventory != null)
                        {
                            hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);
                            hotpotInventory.Status = HotpotStatus.Rented;
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }
                else if (newStatus == OrderStatus.Returning && order.RentOrder != null)
                {
                    // Update hotpot inventory status to Preparing
                    foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                    {
                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .IncludeNested(query => query.Include(h => h.Hotpot))
                            .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                        if (hotpotInventory != null)
                        {
                            hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);
                            hotpotInventory.Status = HotpotStatus.Preparing;
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }
                else if (newStatus == OrderStatus.Completed && order.RentOrder != null)
                {
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

                            // Update last maintain date on the hotpot itself
                            if (hotpotInventory.Hotpot != null)
                            {
                                hotpotInventory.Hotpot.LastMaintainDate = DateTime.Now;
                                await _unitOfWork.Repository<Hotpot>().Update(hotpotInventory.Hotpot, hotpotInventory.Hotpot.HotpotId);
                            }

                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }
                else if (newStatus == OrderStatus.Cancelled)
                {
                    // Get the main payment
                    var mainPayment = await GetMainPaymentForOrderAsync(orderId);

                    // If payment was successful, we need to handle refunds and inventory
                    if (mainPayment != null && mainPayment.Status == PaymentStatus.Success)
                    {
                        // For now, just update the order status
                        // In a real system, you might want to create a refund record
                    }
                    else
                    {
                        // Release inventory reservations
                        await ReleaseInventoryReservation(order);

                        // We don't need to update hotpot quantities here since ReleaseInventoryReservation already does it

                        // Cancel any pending payments
                        var pendingPayments = (await GetListPaymentByOrderIdAsync(orderId))
                            .Where(p => p.Status == PaymentStatus.Pending)
                            .ToList();

                        foreach (var payment in pendingPayments)
                        {
                            payment.Status = PaymentStatus.Cancelled;
                            payment.UpdatedAt = DateTime.UtcNow;
                            await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);

                            // If it's an online payment, cancel in PayOS
                            if (payment.Type == PaymentType.Online)
                            {
                                await _payOS.cancelPaymentLink(payment.TransactionCode, "Order cancelled");
                            }
                        }
                    }
                }

                // Update order status
                order.Status = newStatus;
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, orderId);

                // Update the quantity for each affected hotpot type
                foreach (var hotpotId in hotpotIdsToUpdate)
                {
                    await UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                }

                await _unitOfWork.CommitAsync();

                return new Response(0, "Order status updated successfully", order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order status for order {OrderId}", orderId);
                return new Response(-1, "Error updating order status", null);
            }
        }

        private bool IsValidStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            switch (currentStatus)
            {
                case OrderStatus.Pending:
                    return newStatus == OrderStatus.Processing || newStatus == OrderStatus.Cancelled;
                case OrderStatus.Processing:
                    return newStatus == OrderStatus.Shipping || newStatus == OrderStatus.Cancelled;
                case OrderStatus.Shipping:
                    return newStatus == OrderStatus.Delivered || newStatus == OrderStatus.Cancelled;
                case OrderStatus.Delivered:
                    return newStatus == OrderStatus.Returning || newStatus == OrderStatus.Completed;
                case OrderStatus.Returning:
                    return newStatus == OrderStatus.Completed;
                case OrderStatus.Completed:
                    return false; 
                case OrderStatus.Cancelled:
                    return false; 
                default:
                    return false;
            }
        }


        private async Task<Order> OrderUpdateAsync(int id, UpdateOrderRequest request)
        {
            try
            {
                var order = await GetOrderByIdAsync(id);

                // Only allow updates for pending orders
                if (order.Status != OrderStatus.Pending)
                    throw new ValidationException("Only pending orders can be updated");

                // Update order properties
                if (!string.IsNullOrWhiteSpace(request.Address))
                    order.Address = request.Address;

                if (!string.IsNullOrWhiteSpace(request.Notes))
                    order.Notes = request.Notes;

                // Update rental dates if provided and order has rental items
                if (order.RentOrder != null && request.ExpectedReturnDate.HasValue)
                {

                    DateTime today = DateTime.UtcNow.AddHours(7);
                    order.RentOrder.RentalStartDate = today;
                    DateTime expectedReturnDate = request.ExpectedReturnDate.Value;

                    // Validate expected return date is after rental start date
                    if (expectedReturnDate <= today)
                    {
                        throw new ValidationException("Expected return date must be in the future");
                    }

                    if (request.ExpectedReturnDate.HasValue &&
                        request.ExpectedReturnDate.Value <= order.RentOrder.RentalStartDate)
                    {
                        throw new ValidationException("Expected return date must be at least one day after rental start date");
                    }
                    order.RentOrder.ExpectedReturnDate = request.ExpectedReturnDate.Value;
                    await _unitOfWork.Repository<RentOrder>().Update(order.RentOrder, order.RentOrder.OrderId);
                }

                // Update discount if provided
                if (request.DiscountId.HasValue && request.DiscountId != order.DiscountId)
                {
                    var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
                    if (discount == null)
                        throw new ValidationException($"Discount with ID {request.DiscountId} not found");

                    // Validate discount is still valid
                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                        throw new ValidationException("The selected discount is not valid or has expired");

                    // Calculate new total price with discount
                    decimal basePrice = order.TotalPrice;
                    if (order.DiscountId.HasValue)
                    {
                        // Remove old discount first
                        var oldDiscount = await _discountService.GetByIdAsync(order.DiscountId.Value);
                        if (oldDiscount != null)
                        {
                            basePrice = basePrice / (1 - (decimal)(oldDiscount.DiscountPercentage / 100));
                        }
                    }

                    // Apply new discount
                    order.TotalPrice = basePrice - (basePrice * (decimal)(discount.DiscountPercentage / 100));
                    order.DiscountId = request.DiscountId;
                }
                else if (request.DiscountId == null && order.DiscountId.HasValue)
                {
                    // Remove discount
                    var oldDiscount = await _discountService.GetByIdAsync(order.DiscountId.Value);
                    if (oldDiscount != null)
                    {
                        // Restore original price
                        order.TotalPrice = order.TotalPrice / (1 - (decimal)(oldDiscount.DiscountPercentage / 100));
                    }

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
                    throw new NotFoundException($"Order with ID {id} not found");

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
