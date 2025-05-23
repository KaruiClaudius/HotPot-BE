using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.BackgroundServices
{
    public class CheckPaymentService : BackgroundService
    {
        private readonly ILogger<CheckPaymentService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(1);
        private readonly TimeSpan _paymentTimeout = TimeSpan.FromMinutes(10);

        private readonly Dictionary<int, DateTime> _monitoredPayments = new();

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
            _logger.LogInformation("Checking pending payments...");

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                // Get all pending payments
                var pendingPayments = await unitOfWork.Repository<Payment>()
                    .FindAll(p => p.Status == PaymentStatus.Pending && !p.IsDelete)
                    .ToListAsync();

                _logger.LogInformation("Found {Count} pending payments to check", pendingPayments.Count);

                foreach (var payment in pendingPayments)
                {
                    if (stoppingToken.IsCancellationRequested)
                        break;

                    try
                    {
                        // Add payment to monitoring if not already tracked
                        if (!_monitoredPayments.ContainsKey(payment.PaymentId))
                        {
                            _monitoredPayments[payment.PaymentId] = DateTime.UtcNow.AddHours(7);
                        }

                        var monitoringTime = DateTime.UtcNow.AddHours(7) - _monitoredPayments[payment.PaymentId];

                        var user = await unitOfWork.Repository<User>().GetById(payment.UserId);
                        if (user == null)
                        {
                            _logger.LogWarning("User not found for payment {PaymentId}", payment.PaymentId);
                            continue;
                        }

                        if (monitoringTime > _paymentTimeout)
                        {
                            _logger.LogInformation("Payment {TransactionCode} has timed out after {Minutes} minutes. Cancelling...",
                                payment.TransactionCode,
                                monitoringTime.TotalMinutes);

                            // Cancel the payment in our system
                            payment.Status = PaymentStatus.Cancelled;
                            payment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                            await unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);

                            // Get the order and release inventory
                            if (payment.OrderId.HasValue)
                            {
                                var order = await unitOfWork.Repository<Order>().GetById(payment.OrderId.Value);
                                if (order != null)
                                {
                                    // Call method to release inventory reservations
                                    await ReleaseInventoryReservation(order);
                                }

                            }

                            await unitOfWork.CommitAsync();

                            // Remove from monitoring
                            _monitoredPayments.Remove(payment.PaymentId);

                            continue;
                        }

                        // Check the payment status with PayOS
                        var checkRequest = new CheckOrderRequest(payment.TransactionCode);
                        var response = await paymentService.CheckOrder(checkRequest, user.PhoneNumber);

                        _logger.LogInformation("Payment {TransactionCode} status check result: {Status}",
                                                payment.TransactionCode,
                                                response.error == 0 ? "Success" : "Failed");

                        // If payment is no longer pending, remove from monitoring
                        if (response.error == 0 &&
                            (response.message == "Hoàn thành giao dịch" ||
                             response.message == "Huỷ giao dịch"))
                        {
                            _monitoredPayments.Remove(payment.PaymentId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error checking payment {PaymentId}", payment.PaymentId);
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
                        }
                    }
                }

                // Update the quantity for each affected hotpot type
                foreach (var hotpotId in hotpotIdsToUpdate)
                {
                    await paymentService.UpdateHotpotQuantityFromInventoryAsync(hotpotId);
                }
            }
        }
    }
}
