using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Capstone.HPTY.ServiceLayer.Services.BackgroundServices
{
    public class IngredientMonitorOptions
    {
        public int CheckIntervalMinutes { get; set; } = 60;
        public int ExpirationWarningDays { get; set; } = 2;
        public string AdminRole { get; set; } = "Admin";
        public int NotificationCooldownHours { get; set; } = 24;
    }

    public class IngredientMonitorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IngredientMonitorService> _logger;
        private readonly IngredientMonitorOptions _options;

        public IngredientMonitorService(
            IServiceProvider serviceProvider,
            IOptions<IngredientMonitorOptions> options,
            ILogger<IngredientMonitorService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _options = options.Value;

            // Validate configuration
            if (_options.CheckIntervalMinutes <= 0)
            {
                _logger.LogWarning("Invalid CheckIntervalMinutes value: {value}. Using default of 60 minutes.",
                    _options.CheckIntervalMinutes);
                _options.CheckIntervalMinutes = 60;
            }

            if (_options.NotificationCooldownHours <= 0)
            {
                _logger.LogWarning("Invalid NotificationCooldownHours value: {value}. Using default of 24 hours.",
                    _options.NotificationCooldownHours);
                _options.NotificationCooldownHours = 24;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Ingredient Monitor Service started at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Check interval set to {minutes} minutes", _options.CheckIntervalMinutes);
            _logger.LogInformation("Notification cooldown set to {hours} hours", _options.NotificationCooldownHours);

            try
            {
                // Use a timer for more accurate timing
                using PeriodicTimer timer = new(TimeSpan.FromMinutes(_options.CheckIntervalMinutes));

                // Run immediately on startup
                _logger.LogInformation("Running initial ingredient check");
                await CheckIngredientsAsync(stoppingToken);

                // Then run on the timer
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    _logger.LogInformation("Timer triggered after {minutes} minutes", _options.CheckIntervalMinutes);
                    await CheckIngredientsAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Ingredient Monitor Service is stopping.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in Ingredient Monitor Service.");
            }
        }

        private async Task CheckIngredientsAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Checking ingredients at: {time}", DateTimeOffset.Now);

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                // Check for expiring ingredients
                await CheckExpiringIngredientsAsync(unitOfWork, notificationService, stoppingToken);

                // Check for low stock ingredients
                await CheckLowStockIngredientsAsync(unitOfWork, notificationService, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking ingredients.");
            }
        }

        private async Task<bool> HasRecentNotificationAsync(
            IUnitOfWork unitOfWork,
            string notificationType,
            int ingredientId,
            CancellationToken stoppingToken = default)
        {
            try
            {
                // Calculate the cooldown date
                var cooldownDate = DateTime.UtcNow.AddHours(7).AddHours(-_options.NotificationCooldownHours);

                _logger.LogInformation(
                    "Checking for recent {type} notifications for ingredient {id} since {date}",
                    notificationType,
                    ingredientId,
                    cooldownDate);

                // Query for recent notifications of this type for this ingredient
                var recentNotification = await unitOfWork.Repository<Notification>()
                    .FindAll(n =>
                        !n.IsDelete &&
                        n.Type == notificationType &&
                        n.TargetType == "Role" &&
                        n.TargetId == _options.AdminRole &&
                        n.CreatedAt > cooldownDate)
                    .Where(n => n.DataJson.Contains($"\"IngredientId\":{ingredientId}"))
                    .FirstOrDefaultAsync(stoppingToken);

                if (recentNotification != null)
                {
                    _logger.LogInformation(
                        "Found recent notification (ID: {id}) for {type} and ingredient {ingredientId} sent at {time}",
                        recentNotification.NotificationId,
                        notificationType,
                        ingredientId,
                        recentNotification.CreatedAt);
                    return true;
                }

                _logger.LogInformation(
                    "No recent {type} notifications found for ingredient {id} since {date}",
                    notificationType,
                    ingredientId,
                    cooldownDate);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking for recent notifications");
                return false; // Assume no recent notification in case of error
            }
        }

        private async Task CheckExpiringIngredientsAsync(
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            CancellationToken stoppingToken)
        {
            try
            {
                var warningDate = DateTime.UtcNow.AddHours(7).AddDays(_options.ExpirationWarningDays);
                var now = DateTime.UtcNow.AddHours(7);

                _logger.LogInformation("Checking expiring ingredients. Warning date: {warningDate}", warningDate);

                // Get all active ingredient batches that will expire within the warning period
                var expiringBatches = await unitOfWork.Repository<IngredientBatch>()
                    .FindAll(
                        batch => !batch.IsDelete &&
                                batch.RemainingQuantity > 0 &&
                                batch.BestBeforeDate <= warningDate)
                    .Include(batch => batch.Ingredient)
                    .ToListAsync(stoppingToken);

                if (expiringBatches.Any())
                {
                    _logger.LogInformation("Found {count} ingredient batches expiring soon", expiringBatches.Count);

                    // Group by ingredient to avoid multiple notifications for the same ingredient
                    var groupedByIngredient = expiringBatches
                        .GroupBy(batch => batch.IngredientId)
                        .Select(group => new
                        {
                            group.First().Ingredient,
                            ExpiringBatches = group.ToList(),
                            EarliestExpiryDate = group.Min(b => b.BestBeforeDate)
                        })
                        .ToList();

                    foreach (var item in groupedByIngredient)
                    {
                        // Check if we've sent a notification for this ingredient recently
                        if (await HasRecentNotificationAsync(
                            unitOfWork,
                            "Ingredient",
                            item.Ingredient.IngredientId,
                            stoppingToken))
                        {
                            _logger.LogInformation(
                                "Skipping expiration notification for {ingredient} - notification sent within cooldown period",
                                item.Ingredient.Name);
                            continue;
                        }

                        var daysUntilExpiry = (item.EarliestExpiryDate - now).Days;
                        var totalExpiringQuantity = item.ExpiringBatches.Sum(b => b.RemainingQuantity);

                        // Prepare notification data
                        var notificationData = new Dictionary<string, object>
                    {
                        { "IngredientId", item.Ingredient.IngredientId },
                        { "IngredientName", item.Ingredient.Name },
                        { "ExpiryDate", item.EarliestExpiryDate },
                        { "DaysUntilExpiry", daysUntilExpiry },
                        { "ExpiringQuantity", totalExpiringQuantity },
                        { "Unit", item.Ingredient.Unit }
                    };

                        // Send notification
                        await notificationService.NotifyRoleAsync(
                            _options.AdminRole,
                            "Ingredient", 
                            $"Sắp Hết Hạn: {item.Ingredient.Name}",
                            $"{totalExpiringQuantity} phần của {item.Ingredient.Name} sẽ hết hạn trong {daysUntilExpiry} ngày",
                            notificationData);

                        _logger.LogInformation(
                            "Sent expiration notification for {ingredient} ({quantity} {unit}), expiring in {days} days",
                            item.Ingredient.Name,
                            totalExpiringQuantity,
                            item.Ingredient.Unit,
                            daysUntilExpiry);
                    }
                }
                else
                {
                    _logger.LogInformation("No ingredient batches expiring within {days} days", _options.ExpirationWarningDays);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking for expiring ingredients");
            }
        }

        private async Task CheckLowStockIngredientsAsync(
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            CancellationToken stoppingToken)
        {
            try
            {
                var now = DateTime.UtcNow.AddHours(7);
                _logger.LogInformation("Checking low stock ingredients");

                // Get all active ingredients with their batches
                var ingredients = await unitOfWork.Repository<Ingredient>()
                    .FindAll(i => !i.IsDelete)
                    .Include(i => i.IngredientBatches.Where(b => !b.IsDelete))
                    .ToListAsync(stoppingToken);

                var lowStockIngredients = ingredients
                    .Where(i => i.Quantity <= i.MinStockLevel)
                    .ToList();

                if (lowStockIngredients.Any())
                {
                    _logger.LogInformation("Found {count} ingredients with low stock", lowStockIngredients.Count);

                    foreach (var ingredient in lowStockIngredients)
                    {
                        // Check if we've sent a notification for this ingredient recently
                        if (await HasRecentNotificationAsync(
                            unitOfWork,
                            "Ingredient",
                            ingredient.IngredientId,
                            stoppingToken))
                        {
                            _logger.LogInformation(
                                "Skipping low stock notification for {ingredient} - notification sent within cooldown period",
                                ingredient.Name);
                            continue;
                        }

                        // Prepare notification data
                        var notificationData = new Dictionary<string, object>
                    {
                        { "IngredientId", ingredient.IngredientId },
                        { "IngredientName", ingredient.Name },
                        { "CurrentStock", ingredient.Quantity },
                        { "MinStockLevel", ingredient.MinStockLevel },
                        { "Unit", ingredient.Unit }
                    };

                        // Send notification
                        await notificationService.NotifyRoleAsync(
                            _options.AdminRole,
                            "Ingredient", 
                            $"Cảnh báo tồn kho thấp: {ingredient.Name}",
                            $"{ingredient.Name} đang sắp hết. Tồn kho hiện tại:{ingredient.Quantity} (Minimum: {ingredient.MinStockLevel} phần)",
                            notificationData);

                        _logger.LogInformation(
                            "Sent low stock notification for {ingredient}. Current: {current} {unit}, Minimum: {min} {unit}",
                            ingredient.Name,
                            ingredient.Quantity,
                            ingredient.Unit,
                            ingredient.MinStockLevel,
                            ingredient.Unit);
                    }
                }
                else
                {
                    _logger.LogInformation("No ingredients with stock below minimum level");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking for low stock ingredients");
            }
        }
    }
}
