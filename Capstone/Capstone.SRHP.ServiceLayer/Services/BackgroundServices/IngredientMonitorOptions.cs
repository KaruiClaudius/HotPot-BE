using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public int CheckIntervalMinutes { get; set; } = 60; // Default: check every hour
        public int ExpirationWarningDays { get; set; } = 2; // Default: warn 7 days before expiration
        public string AdminRole { get; set; } = "Admin"; // Default admin role name
        public int NotificationCooldownHours { get; set; } = 24;
    }

    public class IngredientMonitorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IngredientMonitorService> _logger;
        private readonly IngredientMonitorOptions _options;
        private readonly Dictionary<string, DateTime> _lastNotificationSent = new();


        public IngredientMonitorService(
            IServiceProvider serviceProvider,
            IOptions<IngredientMonitorOptions> options,
            ILogger<IngredientMonitorService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Ingredient Monitor Service started at: {time}", DateTimeOffset.Now);

            using PeriodicTimer timer = new(TimeSpan.FromMinutes(_options.CheckIntervalMinutes));

            try
            {
                // Run immediately on startup
                await CheckIngredientsAsync(stoppingToken);

                // Then run on the timer
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
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

        private async Task CheckExpiringIngredientsAsync(
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            CancellationToken stoppingToken)
        {
            try
            {
                var warningDate = DateTime.UtcNow.AddDays(_options.ExpirationWarningDays);
                var cooldownDate = DateTime.UtcNow.AddHours(-_options.NotificationCooldownHours);

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
                        var daysUntilExpiry = (item.EarliestExpiryDate - DateTime.UtcNow.AddHours(7)).Days;
                        var totalExpiringQuantity = item.ExpiringBatches.Sum(b => b.RemainingQuantity);

                        // Check if we've recently sent a notification about this
                        var recentNotification = await unitOfWork.Repository<Notification>()
                            .FindAsync(n =>
                                n.Type == "IngredientExpiringSoon" &&
                                n.TargetType == "Role" &&
                                n.TargetId == _options.AdminRole &&
                                n.CreatedAt > cooldownDate &&
                                n.DataJson.Contains($"\"IngredientId\":{item.Ingredient.IngredientId}"));

                        if (recentNotification != null)
                        {
                            _logger.LogInformation(
                                "Skipping expiration notification for {ingredient} - cooldown period not elapsed",
                                item.Ingredient.Name);
                            continue;
                        }

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
                            "IngredientExpiringSoon",
                            $"Nguyên liệu sắp hết hạn: {item.Ingredient.Name}",
                            $"{totalExpiringQuantity} {item.Ingredient.Unit} của {item.Ingredient.Name} sẽ hết hạn trong {daysUntilExpiry} ngày",
                            notificationData);

                        _logger.LogInformation(
                            "Đã gửi thông báo hết hạn cho {ingredient} ({quantity} {unit}), sẽ hết hạn trong {days} ngày",
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
                        // Create a unique key for this notification
                        string notificationKey = $"lowstock_{ingredient.IngredientId}";

                        // Check if we've recently sent a notification about this
                        if (_lastNotificationSent.TryGetValue(notificationKey, out DateTime lastSent))
                        {
                            // If the cooldown period hasn't elapsed, skip this notification
                            if (DateTime.UtcNow.AddHours(7) < lastSent.AddHours(_options.NotificationCooldownHours))
                            {
                                _logger.LogInformation(
                                    "Skipping low stock notification for {ingredient} - cooldown period not elapsed",
                                    ingredient.Name);
                                continue;
                            }
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
                            "IngredientLowStock",
                            $"Cảnh báo tồn kho thấp: {ingredient.Name}",
                            $"{ingredient.Name} đang sắp hết. Tồn kho hiện tại: {ingredient.Quantity} {ingredient.Unit} (Tối thiểu: {ingredient.MinStockLevel} {ingredient.Unit})",
                            notificationData);

                        // Update the last notification time
                        _lastNotificationSent[notificationKey] = DateTime.UtcNow.AddHours(7);

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

