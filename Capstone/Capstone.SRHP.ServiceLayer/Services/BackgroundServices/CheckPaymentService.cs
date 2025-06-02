using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Net.payOS.Types;
using Net.payOS;
using static System.Formats.Asn1.AsnWriter;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Services.OrderService;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.BackgroundService;

namespace Capstone.HPTY.ServiceLayer.Services.BackgroundServices
{
    public class CheckPaymentService : BackgroundService
    {
        private readonly ILogger<CheckPaymentService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _checkInterval = TimeSpan.FromSeconds(10);
        private readonly TimeSpan _paymentTimeout = TimeSpan.FromMinutes(10);

        // Dictionary to track when we last saw each payment
        private readonly ConcurrentDictionary<int, DateTime> _monitoredPayments = new();

        public CheckPaymentService(
            ILogger<CheckPaymentService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Payment Status Checker Service is starting.");

            using PeriodicTimer timer = new(_checkInterval);

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await CheckPendingPaymentsAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Dịch vụ kiểm tra trạng thái thanh toán đang dừng lại.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Đã xảy ra lỗi trong dịch vụ kiểm tra trạng thái thanh toán.");
                throw;
            }
        }

        private async Task CheckPendingPaymentsAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Checking pending payments at {Time}...", DateTime.UtcNow.AddHours(7));

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var payOS = scope.ServiceProvider.GetRequiredService<PayOS>();
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                var lockService = scope.ServiceProvider.GetRequiredService<ILockService>();

                // Get all pending payments
                var pendingPayments = await unitOfWork.Repository<Payment>()
                    .FindAll(p => p.Status == PaymentStatus.Pending && !p.IsDelete)
                    .ToListAsync();

                _logger.LogInformation("Found {Count} pending payments to check", pendingPayments.Count);

                // Clean up monitoring dictionary - remove payments that are no longer pending
                var paymentIdsToRemove = _monitoredPayments.Keys
                    .Where(id => !pendingPayments.Any(p => p.PaymentId == id))
                    .ToList();

                foreach (var id in paymentIdsToRemove)
                {
                    _monitoredPayments.TryRemove(id, out _);
                    _logger.LogInformation("Removed payment {PaymentId} from monitoring as it's no longer pending", id);
                }

                foreach (var payment in pendingPayments)
                {
                    if (stoppingToken.IsCancellationRequested)
                        break;

                    try
                    {
                        // Add payment to monitoring if not already tracked
                        if (!_monitoredPayments.TryGetValue(payment.PaymentId, out var firstSeenTime))
                        {
                            firstSeenTime = DateTime.UtcNow.AddHours(7);
                            _monitoredPayments[payment.PaymentId] = firstSeenTime;
                            _logger.LogInformation("Started monitoring payment {PaymentId} ({TransactionCode})",
                                payment.PaymentId, payment.TransactionCode);
                        }

                        var monitoringTime = DateTime.UtcNow.AddHours(7) - firstSeenTime;

                        // Check if this payment has timed out
                        bool isTimedOut = monitoringTime > _paymentTimeout;

                        var paymentInfo = await payOS.getPaymentLinkInformation(payment.TransactionCode);

                        if (paymentInfo == null)
                        {
                            _logger.LogWarning("Could not get payment information from PayOS for {TransactionCode}",
                                payment.TransactionCode);
                            continue;
                        }

                        _logger.LogInformation("Payment {TransactionCode} PayOS status: {Status}",
                            payment.TransactionCode, paymentInfo.status);

                        if (paymentInfo.status == "PAID" || paymentInfo.status == "CANCELLED" || isTimedOut)
                        {
                            string processLockKey = $"process_payment_{payment.TransactionCode}";



                               _logger.LogInformation("Payment {TransactionCode} PayOS status: {Status}",
                            payment.TransactionCode, paymentInfo.status);

                            var user = await unitOfWork.Repository<User>().GetById(payment.UserId);
                            if (user == null)
                            {
                                _logger.LogWarning("User not found for payment {PaymentId}", payment.PaymentId);
                                continue;
                            }

                            if (paymentInfo.status == "PAID")
                            {
                                _logger.LogInformation("Payment {TransactionCode} is PAID according to PayOS. Processing as successful payment.",
                                    payment.TransactionCode);

                                // Process successful payment - ProcessOrder will acquire its own lock
                                var checkRequest = new CheckOrderRequest(payment.TransactionCode);
                                try
                                {
                                    var response = await paymentService.ProcessOrder(checkRequest, user.PhoneNumber);

                                    _logger.LogInformation("Payment {TransactionCode} ProcessOrder result: {Status}, Message: {Message}",
                                        payment.TransactionCode, response.error == 0 ? "Success" : "Failed", response.message);

                                    if (response.error == 0)
                                    {
                                        _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                        _logger.LogInformation("Payment {PaymentId} ({TransactionCode}) processed successfully and removed from monitoring",
                                            payment.PaymentId, payment.TransactionCode);
                                    }
                                    else
                                    {
                                        _logger.LogWarning("Failed to process successful payment {TransactionCode}: {Message}",
                                            payment.TransactionCode, response.message);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    _logger.LogError(ex, "Exception in ProcessOrder for PAID payment {TransactionCode}", payment.TransactionCode);
                                }
                            }

                            else if (paymentInfo.status == "CANCELLED")
                            {
                                _logger.LogInformation("Payment {TransactionCode} is CANCELLED according to PayOS. Processing as cancelled payment.",
                                    payment.TransactionCode);

                                // Process cancelled payment
                                var checkRequest = new CheckOrderRequest(payment.TransactionCode);
                                try
                                {
                                    var response = await paymentService.ProcessOrder(checkRequest, user.PhoneNumber);

                                    _logger.LogInformation("Payment {TransactionCode} ProcessOrder result: {Status}, Message: {Message}",
                                        payment.TransactionCode, response.error == 0 ? "Success" : "Failed", response.message);

                                    if (response.error == 0)
                                    {
                                        _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                        _logger.LogInformation("Payment {PaymentId} ({TransactionCode}) cancelled and removed from monitoring",
                                            payment.PaymentId, payment.TransactionCode);
                                    }
                                    else
                                    {
                                        _logger.LogWarning("Failed to process cancelled payment {TransactionCode}: {Message}",
                                            payment.TransactionCode, response.message);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex, "Exception in ProcessOrder for CANCELLED payment {TransactionCode}", payment.TransactionCode);
                                }
                            }

                            else if (isTimedOut)
                            {
                                // ONLY cancel if the payment has timed out AND is still in a pending-like state
                                if (paymentInfo.status == "PENDING")
                                {
                                    _logger.LogInformation("Payment {TransactionCode} has timed out after {Minutes:N1} minutes and is still {Status} in PayOS. Cancelling...",
                                        payment.TransactionCode, monitoringTime.TotalMinutes, paymentInfo.status);

                                    // Get a fresh copy of the payment again to ensure it's still pending
                                    var freshPayment = await unitOfWork.Repository<Payment>().GetById(payment.PaymentId);
                                    if (freshPayment != null && freshPayment.Status == PaymentStatus.Pending)
                                    {
                                        var success = await unitOfWork.ExecuteInTransactionAsync(async () =>
                                        {
                                            // Get the most up-to-date payment record within the transaction
                                            var transactionPayment = await unitOfWork.Repository<Payment>().GetById(payment.PaymentId);
                                            if (transactionPayment == null || transactionPayment.Status != PaymentStatus.Pending)
                                            {
                                                // Payment was already processed by another thread
                                                return false;
                                            }

                                            // Double-check with PayOS one more time before cancelling
                                            var finalCheck = await payOS.getPaymentLinkInformation(payment.TransactionCode);
                                            if (finalCheck != null && finalCheck.status == "PAID")
                                            {
                                                _logger.LogWarning("Payment {TransactionCode} changed to PAID during cancellation. Aborting cancellation.",
                                                    payment.TransactionCode);
                                                return false;
                                            }

                                            // Cancel the payment in our system
                                            transactionPayment.Status = PaymentStatus.Cancelled;
                                            transactionPayment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                                            await unitOfWork.Repository<Payment>().Update(transactionPayment, transactionPayment.PaymentId);

                                            // Get the order and release inventory
                                            if (transactionPayment.OrderId.HasValue)
                                            {
                                                var orderToCancel = await unitOfWork.Repository<Order>().GetById(transactionPayment.OrderId.Value);
                                                if (orderToCancel != null)
                                                {
                                                    // Call method to release inventory reservations
                                                    await ReleaseInventoryReservation(orderToCancel);
                                                }
                                            }

                                            return true; // Transaction success
                                        },
                                        ex =>
                                        {
                                            _logger.LogError(ex, "Error in transaction while cancelling payment {PaymentId} ({TransactionCode})",
                                                payment.PaymentId, payment.TransactionCode);
                                        });

                                        if (success)
                                        {
                                            // Remove from monitoring
                                            _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                            _logger.LogInformation("Payment {PaymentId} ({TransactionCode}) cancelled due to timeout and removed from monitoring",
                                                payment.PaymentId, payment.TransactionCode);
                                        }
                                        else
                                        {
                                            _logger.LogWarning("Failed to cancel payment {PaymentId} ({TransactionCode}) - transaction failed or payment already processed",
                                                payment.PaymentId, payment.TransactionCode);
                                        }
                                    }
                                }
                                else
                                {
                                    _logger.LogInformation("Payment {TransactionCode} has timed out but has status {Status} in PayOS. Not cancelling.",
                                        payment.TransactionCode, paymentInfo.status);
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing payment {PaymentId} ({TransactionCode})",
                            payment.PaymentId, payment.TransactionCode);
                        // Continue with the next payment
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CheckPendingPaymentsAsync");
            }
        }


        private async Task ReleaseInventoryReservation(Order order)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                // For hotpots, we need to update their status back to Available
                if (order.RentOrder != null)
                {
                    // Track which hotpot types need quantity updates
                    var hotpotIdsToUpdate = new HashSet<int>();

                    foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                    {
                        if (detail.HotpotInventoryId.HasValue)
                        {
                            var hotpotInventory = await unitOfWork.Repository<HotPotInventory>()
                                .IncludeNested(query => query.Include(h => h.Hotpot))
                                .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);

                            if (hotpotInventory != null &&
                                (hotpotInventory.Status == HotpotStatus.Reserved || hotpotInventory.Status == HotpotStatus.Rented))
                            {
                                // Add the hotpot ID to the set of IDs to update
                                hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);

                                // Update the inventory status
                                hotpotInventory.Status = HotpotStatus.Available;
                                await unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);

                                _logger.LogInformation("Released hotpot inventory item {InventoryId} for hotpot {HotpotId}",
                                    hotpotInventory.HotPotInventoryId, hotpotInventory.HotpotId);
                            }
                        }
                    }

                    // Update the quantity for each affected hotpot type
                    //foreach (var hotpotId in hotpotIdsToUpdate)
                    //{
                    //    try
                    //    {
                    //        await paymentService.UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                    //        _logger.LogInformation("Updated quantity for hotpot {HotpotId}", hotpotId);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        _logger.LogError(ex, "Error updating quantity for hotpot {HotpotId}", hotpotId);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ReleaseInventoryReservation for order {OrderId}", order.OrderId);
                // Don't rethrow - we want to continue processing even if this fails
            }
        }
    }
}
