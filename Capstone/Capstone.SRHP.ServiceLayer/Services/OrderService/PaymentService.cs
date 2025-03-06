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

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(PayOS payOS, IUnitOfWork unitOfWork, ILogger<PaymentService> logger)
        {
            _payOS = payOS;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response> GetOrderByUserId(int userId)
        {
            try
            {
                var orders = await _unitOfWork.Repository<Payment>()
                                              .AsQueryable()
                                              .AsNoTracking()
                                              .Where(u => u.UserID == userId)
                                              .Include(u => u.User)
                                              .ToListAsync();
                return new Response(0, "Ok", orders);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error getting orders for user {UserId}", userId);
                return new Response(-1, "fail", null);
            }
        }

        public async Task<Response> GetOrders()
        {
            try
            {
                var orders = await _unitOfWork.Repository<Payment>()
                                              .AsQueryable()
                                              .ToListAsync();
                return new Response(0, "Ok", orders);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error getting all orders");
                return new Response(-1, "fail", null);
            }
        }

        public async Task<Response> CreatePaymentLink(CreatePaymentLinkRequest body, string Phone, int postId, int transactionId)
        {
            try
            {
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == Phone);
                if (user == null)
                {
                    return new Response(-1, "User not found", null);
                }

                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                ItemData item = new ItemData(body.productName, 1, body.price);
                List<ItemData> items = new List<ItemData> { item };

                if (body.cancelUrl == null || body.returnUrl == null)
                {
                    body = body with
                    {
                        cancelUrl = body.cancelUrl ?? "",
                        returnUrl = body.returnUrl ?? ""
                    };
                }

                string buyerName = !string.IsNullOrEmpty(body.buyerName) ? body.buyerName : user.Name;
                string buyerPhone = !string.IsNullOrEmpty(body.buyerPhone) ? body.buyerPhone : Phone;

                PaymentData paymentData = new PaymentData(
                    orderCode,
                    body.price,
                    body.description,
                    items,
                    body.cancelUrl,
                    body.returnUrl,
                    buyerName,
                    buyerPhone
                );

                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                var paymentTransaction = new Payment
                {
                    PaymentId = transactionId,
                    TransactionCode = orderCode,
                    UserID = user.UserId,
                    OrderID = postId,
                    Price = body.price,
                    Type = PaymentType.Online,
                    Status = PaymentStatus.Pending
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
                _logger.LogError(exception, "Error creating payment link for user {Phone}", Phone);
                return new Response(-1, "fail", null);
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

        // New methods for cash payments
        public async Task<Payment> CreateCashPaymentAsync(int userId, int orderId, decimal amount)
        {
            try
            {
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == userId);
                if (user == null)
                {
                    throw new NotFoundException($"User with ID {userId} not found");
                }

                var order = await _unitOfWork.Repository<Order>().FindAsync(o => o.OrderId == orderId);
                if (order == null)
                {
                    throw new NotFoundException($"Order with ID {orderId} not found");
                }

                int transactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                var payment = new Payment
                {
                    TransactionCode = transactionCode,
                    UserID = userId,
                    OrderID = orderId,
                    Price = amount,
                    Type = PaymentType.Cash,
                    Status = PaymentStatus.Pending
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(payment);
                await _unitOfWork.CommitAsync();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cash payment for user {UserId}, order {OrderId}", userId, orderId);
                throw;
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

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAll(p => p.UserID == userId)
                    .Include(p => p.Order)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments for user {UserId}", userId);
                throw;
            }
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAsync(p => p.PaymentId == paymentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment {PaymentId}", paymentId);
                throw;
            }
        }

        public async Task<Payment> GetPaymentByOrderIdAsync(int orderId)
        {
            try
            {
                return await _unitOfWork.Repository<Payment>()
                    .FindAsync(p => p.OrderID == orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment for order {OrderId}", orderId);
                throw;
            }
        }
    }
}
