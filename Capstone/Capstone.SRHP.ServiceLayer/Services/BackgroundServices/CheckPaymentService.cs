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

namespace Capstone.HPTY.ServiceLayer.Services.BackgroundServices
{
    public class CheckPaymentService : BackgroundService
    {
        private readonly ILogger<CheckPaymentService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _checkInterval = TimeSpan.FromSeconds(20);
        private readonly TimeSpan _paymentTimeout = TimeSpan.FromMinutes(10);
        private readonly TimeSpan _apiCheckGracePeriod = TimeSpan.FromSeconds(30);

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
                            _logger.LogInformation("Started monitoring payment {PaymentId}", payment.PaymentId);
                        }

                        var monitoringTime = DateTime.UtcNow.AddHours(7) - firstSeenTime;

                        // Skip payments that haven't been pending long enough to warrant intervention
                        if (monitoringTime < _apiCheckGracePeriod)
                        {
                            _logger.LogDebug("Payment {PaymentId} is still within grace period, skipping", payment.PaymentId);
                            continue;
                        }

                        // Check if this payment has timed out
                        bool isTimedOut = monitoringTime > _paymentTimeout;

                        // Only check with PayOS if the payment has been pending for a while or has timed out
                        if (isTimedOut || monitoringTime > TimeSpan.FromMinutes(1))
                        {
                            var user = await unitOfWork.Repository<User>().GetById(payment.UserId);
                            if (user == null)
                            {
                                _logger.LogWarning("User not found for payment {PaymentId}", payment.PaymentId);
                                continue;
                            }

                            // Double-check the payment is still pending in our database before proceeding
                            var freshPayment = await unitOfWork.Repository<Payment>().GetById(payment.PaymentId);
                            if (freshPayment == null || freshPayment.Status != PaymentStatus.Pending)
                            {
                                _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                _logger.LogInformation("Payment {PaymentId} is no longer pending, removing from monitoring", payment.PaymentId);
                                continue;
                            }

                            _logger.LogInformation("Background service checking payment {PaymentId} after {Minutes:N1} minutes",
                                payment.PaymentId, monitoringTime.TotalMinutes);

                            // Check the payment status with PayOS
                            var checkRequest = new CheckOrderRequest(payment.TransactionCode);
                            var response = await paymentService.CheckOrder(checkRequest, user.PhoneNumber);

                            _logger.LogInformation("Payment {TransactionCode} status check result: {Status}, Message: {Message}",
                                                    payment.TransactionCode,
                                                    response.error == 0 ? "Success" : "Failed",
                                                    response.message);

                            // If the payment has timed out and is still pending according to PayOS, cancel it
                            if (isTimedOut && response.error == 0 && response.message != "Hoàn thành giao dịch" && response.message != "Huỷ giao dịch")
                            {
                                _logger.LogInformation("Payment {TransactionCode} has timed out after {Minutes:N1} minutes. Cancelling...",
                                    payment.TransactionCode,
                                    monitoringTime.TotalMinutes);

                                // Get a fresh copy of the payment again to ensure it's still pending
                                freshPayment = await unitOfWork.Repository<Payment>().GetById(payment.PaymentId);
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

                                        // Cancel the payment in our system
                                        transactionPayment.Status = PaymentStatus.Cancelled;
                                        transactionPayment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                                        await unitOfWork.Repository<Payment>().Update(transactionPayment, transactionPayment.PaymentId);

                                        // Get the order and release inventory
                                        if (transactionPayment.OrderId.HasValue)
                                        {
                                            var order = await unitOfWork.Repository<Order>().GetById(transactionPayment.OrderId.Value);
                                            if (order != null)
                                            {
                                                // Call method to release inventory reservations
                                                await ReleaseInventoryReservation(order);
                                            }
                                        }

                                        return true; // Transaction success
                                    },
                                    ex =>
                                    {
                                        _logger.LogError(ex, "Error in transaction while cancelling payment {PaymentId}", payment.PaymentId);
                                    });

                                    if (success)
                                    {
                                        // Remove from monitoring
                                        _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                        _logger.LogInformation("Payment {PaymentId} cancelled and removed from monitoring", payment.PaymentId);
                                    }
                                }
                            }
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
        private async Task<Response> CheckOrder(CheckOrderRequest request, string userPhone)
        {
            using var scope = _serviceProvider.CreateScope();
            var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
            var payOS = scope.ServiceProvider.GetRequiredService<PayOS>();
            var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            try
            {
                // Get user information
                var user = await unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == userPhone);
                if (user == null)
                {
                    return new Response(-1, "Không tìm thấy người dùng", null);
                }

                // Get payment information from PayOS (external call, outside transaction)
                PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(request.OrderCode);
                if (paymentLinkInformation == null)
                {
                    return new Response(-1, "thông tin thanh toán không thấy", null);
                }

                // Get payment transaction
                var paymentTransaction = await unitOfWork.Repository<Payment>()
                    .FindAsync(pt => pt.TransactionCode == request.OrderCode);
                if (paymentTransaction == null)
                {
                    return new Response(-1, "Không tìm thấy giao dịch", null);
                }

                // Get the order (outside transaction to avoid long-running transaction)
                var order = await orderService.GetByIdAsync(paymentTransaction.OrderId.Value);

                // Process based on payment status
                if (paymentLinkInformation.status == "PAID")
                {
                    // Execute all database operations in a single transaction
                    var result = await unitOfWork.ExecuteInTransactionAsync(async () =>
                    {
                        // Get fresh copies of the entities within the transaction
                        var freshPayment = await unitOfWork.Repository<Payment>().GetById(paymentTransaction.PaymentId);
                        if (freshPayment == null || freshPayment.Status != PaymentStatus.Pending)
                        {
                            // Payment already processed or deleted
                            return false;
                        }


                        var freshOrder = await unitOfWork.Repository<Order>().GetById(order.OrderId);
                        if (freshOrder == null)
                        {
                            // Order not found
                            return false;
                        }

                        // Update transaction
                        freshPayment.Status = PaymentStatus.Success;
                        freshPayment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                        await unitOfWork.Repository<Payment>().Update(freshPayment, freshPayment.PaymentId);

                        // Finalize inventory deduction
                        await FinalizeInventoryDeduction(freshOrder);

                        // Update order status to Pending
                        freshOrder.Status = OrderStatus.Pending;
                        freshOrder.SetUpdateDate();
                        await unitOfWork.Repository<Order>().Update(freshOrder, freshOrder.OrderId);

                        return true; // Transaction successful
                    },
                    ex =>
                    {
                        _logger.LogError(ex, "Error in transaction while processing successful payment for order {OrderCode}", request.OrderCode);
                    });

                    // If transaction was successful, send notifications
                    if (result)
                    {
                        var updatedUserInfo = new
                        {
                            user.UserId,
                            user.Name,
                            user.PhoneNumber,
                        };

                        await notificationService.NotifyUserAsync(
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
                        await notificationService.NotifyRoleAsync(
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

                        return new Response(0, "Hoàn thành giao dịch",
                            new { paymentInfo = paymentLinkInformation, userInfo = updatedUserInfo });
                    }
                    else
                    {
                        // Transaction failed or payment already processed
                        return new Response(-1, "Không thể xử lý giao dịch", null);
                    }
                }
                else if (paymentLinkInformation.status == "CANCELLED")
                {
                    // Execute all database operations in a single transaction
                    var result = await unitOfWork.ExecuteInTransactionAsync(async () =>
                    {
                        // Get fresh copies of the entities within the transaction
                        var freshPayment = await unitOfWork.Repository<Payment>().GetById(paymentTransaction.PaymentId);
                        if (freshPayment == null || freshPayment.Status != PaymentStatus.Pending)
                        {
                            // Payment already processed or deleted
                            return false;
                        }

                        var freshOrder = await unitOfWork.Repository<Order>().GetById(order.OrderId);
                        if (freshOrder == null)
                        {
                            // Order not found
                            return false;
                        }

                        // Update transaction
                        freshPayment.Status = PaymentStatus.Cancelled;
                        freshPayment.UpdatedAt = DateTime.UtcNow.AddHours(7);
                        await unitOfWork.Repository<Payment>().Update(freshPayment, freshPayment.PaymentId);

                        // Release inventory reservations
                        await ReleaseInventoryReservation(freshOrder);

                        return true; // Transaction successful
                    },
                    ex =>
                    {
                        _logger.LogError(ex, "Error in transaction while processing cancelled payment for order {OrderCode}", request.OrderCode);
                    });

                    if (result)
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
                        // Transaction failed or payment already processed
                        return new Response(-1, "Không thể xử lý giao dịch", null);
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
                _logger.LogError(exception, "Error checking order {OrderCode}", request.OrderCode);
                return new Response(-1, "fail", null);
            }
        }

        private async Task FinalizeInventoryDeduction(Order order)
        {
            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var ingredientService = scope.ServiceProvider.GetRequiredService<IIngredientService>();
            var comboService = scope.ServiceProvider.GetRequiredService<IComboService>();
            var customizationService = scope.ServiceProvider.GetRequiredService<ICustomizationService>();
            var utensilService = scope.ServiceProvider.GetRequiredService<IUtensilService>();
            var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();

            // This method actually deducts inventory quantities after payment is confirmed
            if (order.SellOrder != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.IngredientId.HasValue)
                    {
                        try
                        {
                            // Use the updated ConsumeIngredientAsync method
                            int consumed = await ingredientService.ConsumeIngredientAsync(
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
                        var combo = await comboService.GetByIdAsync(detail.ComboId.Value);
                        if (combo != null && combo.ComboIngredients != null)
                        {
                            foreach (var comboIngredient in combo.ComboIngredients.Where(ci => !ci.IsDelete))
                            {
                                try
                                {
                                    // Calculate quantity needed based on order size
                                    int quantityNeeded = comboIngredient.Quantity * detail.Quantity;

                                    // Consume the ingredient
                                    int consumed = await ingredientService.ConsumeIngredientAsync(
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
                        var customization = await customizationService.GetByIdAsync(detail.CustomizationId.Value);
                        if (customization != null && customization.CustomizationIngredients != null)
                        {
                            foreach (var customizationIngredient in customization.CustomizationIngredients.Where(ci => !ci.IsDelete))
                            {
                                try
                                {
                                    // Calculate quantity needed based on order size
                                    int quantityNeeded = customizationIngredient.Quantity * detail.Quantity;

                                    // Consume the ingredient
                                    int consumed = await ingredientService.ConsumeIngredientAsync(
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
                        var utensil = await utensilService.GetUtensilByIdAsync(detail.UtensilId.Value);
                        if (utensil != null)
                        {
                            // Deduct from inventory
                            utensil.Quantity -= detail.Quantity;
                            await unitOfWork.Repository<Utensil>().Update(utensil, utensil.UtensilId);
                        }
                    }
                }
            }

            // For hotpots, we update their status to Rented
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

                        if (hotpotInventory != null)
                        {
                            // Add the hotpot ID to the set of IDs to update
                            hotpotIdsToUpdate.Add(hotpotInventory.HotpotId);

                            // Update the inventory status
                            hotpotInventory.Status = HotpotStatus.Rented;
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
        //public async Task<bool> UpdateHotpotQuantityFromInventoryAsync(int hotpotId)
        //{
        //    using var scope = _serviceProvider.CreateScope();
        //    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        //    try
        //    {
        //        // Get the hotpot
        //        var hotpot = await unitOfWork.Repository<Hotpot>().GetById(hotpotId);
        //        if (hotpot == null)
        //        {
        //            _logger.LogWarning("Cannot update quantity for non-existent hotpot ID {HotpotId}", hotpotId);
        //            return false;
        //        }

        //        // Count available inventory
        //        int availableCount = await CountHotpotInventoryByStatusAsync(hotpotId,
        //            new List<HotpotStatus> { HotpotStatus.Available, HotpotStatus.Reserved });

        //        // Update hotpot quantity
        //        hotpot.Quantity = availableCount;
        //        hotpot.SetUpdateDate();

        //        await unitOfWork.Repository<Hotpot>().Update(hotpot, hotpotId);

        //        _logger.LogInformation("Updated hotpot {HotpotId} quantity to {Quantity} based on inventory count",
        //            hotpotId, availableCount);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error updating hotpot quantity from inventory for hotpot ID {HotpotId}", hotpotId);
        //        return false;
        //    }
        //}

        //private async Task<int> CountHotpotInventoryByStatusAsync(int hotpotId, List<HotpotStatus> statuses)
        //{
        //    try
        //    {
        //        // Query for the specific hotpot type with the given statuses
        //        var count = await _unitOfWork.Repository<HotPotInventory>()
        //            .CountAsync(h => h.HotpotId == hotpotId &&
        //                           statuses.Contains(h.Status) &&
        //                           !h.IsDelete);

        //        return count;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error counting hotpot inventory for hotpot ID {HotpotId}", hotpotId);
        //        return 0; // Return 0 on error to be safe
        //    }
        //}
    }
}
