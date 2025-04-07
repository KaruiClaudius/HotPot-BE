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

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentService> _logger;
        private readonly IDiscountService _discountService;


        public PaymentService(PayOS payOS, IUnitOfWork unitOfWork, ILogger<PaymentService> logger, IDiscountService discountService)
        {
            _payOS = payOS;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _discountService = discountService;
        }

        public async Task<Response> ProcessOnlinePayment(int orderId, string address, string notes, int? discountId, DateTime? expectedReturnDate, CreatePaymentLinkRequest paymentRequest, int userId)
        {
            try
            {
                // 1. Update the order details
                var updateRequest = new UpdateOrderRequest
                {
                    Address = address,
                    Notes = notes,
                    DiscountId = discountId,
                    ExpectedReturnDate = expectedReturnDate
                };

                await OrderUpdateAsync(orderId, updateRequest);

                // 2. Get user information
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == paymentRequest.buyerPhone);
                if (user == null)
                {
                    return new Response(-1, "User not found", null);
                }

                // 3. Generate transaction code
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                // 4. Create payment data
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

                // 5. Create payment link
                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                // 6. Create payment record
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
                return new Response(-1, "fail", null);
            }
        }

        public async Task<Payment> ProcessCashPayment(int orderId, string address, string notes, int? discountId, DateTime? expectedReturnDate, int userId)
        {
            try
            {
                // 1. Update the order details
                var updateRequest = new UpdateOrderRequest
                {
                    Address = address,
                    Notes = notes,
                    DiscountId = discountId,
                    ExpectedReturnDate = expectedReturnDate
                };

                var order = await OrderUpdateAsync(orderId, updateRequest);

                // 2. Create payment record
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

                paymentTransaction.Status = PaymentStatus.Cancelled;
                paymentTransaction.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);
                await _unitOfWork.CommitAsync();

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

                if (paymentLinkInformation.status == "PAID")
                {
                    var paymentTransaction = (await _unitOfWork.Repository<Payment>()
                        .GetWhere(pt => pt.TransactionCode == request.OrderCode)).SingleOrDefault();

                    if (paymentTransaction == null)
                    {
                        return new Response(-1, "Transaction not found", null);
                    }

                    // Update transaction
                    paymentTransaction.Status = PaymentStatus.Success;
                    paymentTransaction.UpdatedAt = DateTime.UtcNow;
                    await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);
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
                    var paymentTransaction = (await _unitOfWork.Repository<Payment>()
                        .GetWhere(pt => pt.TransactionCode == request.OrderCode)).SingleOrDefault();

                    if (paymentTransaction == null)
                    {
                        return new Response(-1, "Transaction not found", null);
                    }

                    // Update transaction
                    paymentTransaction.Status = PaymentStatus.Cancelled;
                    paymentTransaction.UpdatedAt = DateTime.UtcNow;
                    await _unitOfWork.Repository<Payment>().Update(paymentTransaction, paymentTransaction.PaymentId);
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

                // Update expected return date if provided and order has rental items
                if (request.ExpectedReturnDate.HasValue && order.RentOrder != null)
                {
                    // Validate that the expected return date is in the future
                    if (request.ExpectedReturnDate.Value <= DateTime.UtcNow.AddHours(7))
                        throw new ValidationException("Expected return date must be in the future");

                    // Validate that the expected return date is after the rental start date
                    if (request.ExpectedReturnDate.Value <= order.RentOrder.RentalStartDate)
                        throw new ValidationException("Expected return date must be after the rental start date");


                    order.RentOrder.ExpectedReturnDate = request.ExpectedReturnDate.Value;
                    order.RentOrder.SetUpdateDate();
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

                // Update payment amount if exists
                var mainPayment = await GetPaymentByOrderIdAsync(id);
                if (mainPayment != null && mainPayment.Status == PaymentStatus.Pending)
                {
                    mainPayment.Price = order.TotalPrice;
                    await _unitOfWork.Repository<Payment>().Update(mainPayment, mainPayment.PaymentId);
                    await _unitOfWork.CommitAsync();
                }

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
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
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
