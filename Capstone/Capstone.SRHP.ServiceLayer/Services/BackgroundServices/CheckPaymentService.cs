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
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var payOS = scope.ServiceProvider.GetRequiredService<PayOS>();

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
                            // Get the order to check if it's still in Cart status
                            var order = await unitOfWork.Repository<Order>().GetById(payment.OrderId.Value);
                            if (order == null)
                            {
                                _logger.LogWarning("Order not found for payment {PaymentId}", payment.PaymentId);
                                continue;
                            }

                            // If order is no longer in Cart status, it means it's already been processed
                            if (order.Status != OrderStatus.Cart)
                            {
                                _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                _logger.LogInformation("Order {OrderId} is no longer in Cart status, removing payment {PaymentId} from monitoring",
                                    order.OrderId, payment.PaymentId);
                                continue;
                            }

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

                            _logger.LogInformation("Background service checking payment {PaymentId} ({TransactionCode}) after {Minutes:N1} minutes",
                                payment.PaymentId, payment.TransactionCode, monitoringTime.TotalMinutes);

                            // Check directly with PayOS
                            try
                            {
                                var paymentInfo = await payOS.getPaymentLinkInformation(payment.TransactionCode);

                                if (paymentInfo == null)
                                {
                                    _logger.LogWarning("Could not get payment information from PayOS for {TransactionCode}",
                                        payment.TransactionCode);
                                    continue;
                                }

                                _logger.LogInformation("Payment {TransactionCode} PayOS status: {Status}",
                                    payment.TransactionCode, paymentInfo.status);

                                // Process based on PayOS status
                                if (paymentInfo.status == "PAID")
                                {
                                    // Process successful payment
                                    var success = await ProcessSuccessfulPayment(payment, order, user, paymentInfo);
                                    if (success)
                                    {
                                        _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                        _logger.LogInformation("Payment {PaymentId} ({TransactionCode}) processed successfully and removed from monitoring",
                                            payment.PaymentId, payment.TransactionCode);
                                    }
                                }
                                else if (paymentInfo.status == "CANCELLED")
                                {
                                    // Process cancelled payment
                                    var success = await ProcessCancelledPayment(payment, order);
                                    if (success)
                                    {
                                        _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                        _logger.LogInformation("Payment {PaymentId} ({TransactionCode}) cancelled and removed from monitoring",
                                            payment.PaymentId, payment.TransactionCode);
                                    }
                                }
                                else if (isTimedOut && (paymentInfo.status == "PENDING" || paymentInfo.status == "CREATED"))
                                {
                                    // If the payment has timed out and is still pending according to PayOS, cancel it
                                    _logger.LogInformation("Payment {TransactionCode} has timed out after {Minutes:N1} minutes and is still {Status} in PayOS. Cancelling...",
                                        payment.TransactionCode, monitoringTime.TotalMinutes, paymentInfo.status);

                                    var success = await ProcessCancelledPayment(payment, order);
                                    if (success)
                                    {
                                        _monitoredPayments.TryRemove(payment.PaymentId, out _);
                                        _logger.LogInformation("Payment {PaymentId} ({TransactionCode}) cancelled due to timeout and removed from monitoring",
                                            payment.PaymentId, payment.TransactionCode);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error checking payment status with PayOS for {TransactionCode}", payment.TransactionCode);
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
        private async Task<bool> ProcessSuccessfulPayment(Payment payment, Order order, User user, PaymentLinkInformation paymentInfo)
        {
            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var discountService = scope.ServiceProvider.GetRequiredService<IDiscountService>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

            // Execute all database operations in a single transaction
            var result = await unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Get fresh copies of the entities within the transaction
                var freshPayment = await unitOfWork.Repository<Payment>().GetById(payment.PaymentId);
                if (freshPayment == null)
                {
                    return false;
                }

                // If payment is already successful, don't process again
                if (freshPayment.Status == PaymentStatus.Success)
                {
                    return false;
                }

                var freshOrder = await unitOfWork.Repository<Order>().GetById(order.OrderId);
                if (freshOrder == null)
                {
                    return false;
                }

                // If order is no longer in Cart status, it means it's already been processed
                if (freshOrder.Status != OrderStatus.Cart)
                {
                    return false;
                }

                // Process loyalty points
                if (freshOrder.DiscountId != null)
                {
                    if (await discountService.HasSufficientPointsAsync((int)freshOrder.DiscountId, user.LoyatyPoint))
                    {
                        var newPoint = user.LoyatyPoint - (await discountService.GetByIdAsync((int)freshOrder.DiscountId)).PointCost;
                        user.LoyatyPoint = newPoint;
                        await unitOfWork.Repository<User>().Update(user, user.UserId);
                    }
                }
                else
                {
                    user.LoyatyPoint = (double)(freshOrder.TotalPrice * 0.0001m);
                    await unitOfWork.Repository<User>().Update(user, user.UserId);
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
                _logger.LogError(ex, "Error in transaction while processing successful payment for order {OrderId}", order.OrderId);
            });

            // If transaction was successful, send notifications
            if (result)
            {
                try
                {
                    await notificationService.NotifyUserAsync(
                        user.UserId,
                        "Order",
                        "Thanh Toán Thành Công",
                        $"Đơn hàng #{order.OrderId} của bạn đã được thanh toán thành công",
                        new Dictionary<string, object>
                        {
                        { "OrderId", order.OrderId },
                        { "Amount", paymentInfo.amount },
                        { "PaymentTime", DateTime.Parse(paymentInfo.createdAt) },
                        { "Status", "Đang xử lý" },
                        { "NextSteps", "Đơn hàng của bạn đang được xử lý. Chúng tôi sẽ thông báo khi đơn hàng được giao." }
                        });

                    string orderType = order.HasRentItems && order.HasSellItems
                       ? "Thuê và Mua"
                       : (order.HasRentItems ? "Thuê" : "Mua");

                    // Format the amount as currency
                    var formattedAmount = string.Format("{0:N0} VND", paymentInfo.amount);

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
                        { "PaymentTime", DateTime.Parse(paymentInfo.createdAt) },
                        { "OrderType", orderType },
                        { "TransactionId", paymentInfo.id }
                        });
                }
                catch (Exception ex)
                {
                    // Log notification errors but don't fail the operation
                    _logger.LogError(ex, "Error sending notifications for successful payment {OrderId}", order.OrderId);
                }
            }

            return result;
        }
        private async Task<bool> ProcessCancelledPayment(Payment payment, Order order)
        {
            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            // Execute all database operations in a single transaction
            var result = await unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Get fresh copies of the entities within the transaction
                var freshPayment = await unitOfWork.Repository<Payment>().GetById(payment.PaymentId);
                if (freshPayment == null)
                {
                    return false;
                }

                // If payment is already cancelled, don't process again
                if (freshPayment.Status == PaymentStatus.Cancelled)
                {
                    return false;
                }

                var freshOrder = await unitOfWork.Repository<Order>().GetById(order.OrderId);
                if (freshOrder == null)
                {
                    return false;
                }

                // If order is no longer in Cart status, it means it's already been processed
                if (freshOrder.Status != OrderStatus.Cart)
                {
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
                _logger.LogError(ex, "Error in transaction while processing cancelled payment for order {OrderId}", order.OrderId);
            });

            return result;
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
    }
}
