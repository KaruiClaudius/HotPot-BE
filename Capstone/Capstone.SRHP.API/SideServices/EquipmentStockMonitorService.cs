using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.API.SideServices
{
    public class EquipmentStockMonitorService : BackgroundService
    {
        private readonly ILogger<EquipmentStockMonitorService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _checkInterval = TimeSpan.FromHours(6); // Check every 6 hours
        private const int DEFAULT_LOW_STOCK_THRESHOLD = 5;

        public EquipmentStockMonitorService(
            ILogger<EquipmentStockMonitorService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Equipment Stock Monitor Service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CheckEquipmentStockAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while checking equipment stock.");
                }

                await Task.Delay(_checkInterval, stoppingToken);
            }

            _logger.LogInformation("Equipment Stock Monitor Service is stopping.");
        }

        private async Task CheckEquipmentStockAsync()
        {
            _logger.LogInformation("Checking equipment stock at: {time}", DateTimeOffset.Now);

            using (var scope = _serviceProvider.CreateScope())
            {
                var equipmentStockService = scope.ServiceProvider.GetRequiredService<IEquipmentStockService>();
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                // Check for low stock utensils
                var lowStockUtensils = await equipmentStockService.GetLowStockUtensilsAsync(DEFAULT_LOW_STOCK_THRESHOLD);

                // Group low stock utensils by type for better reporting
                var lowStockByType = lowStockUtensils
                    .GroupBy(u => u.UtensilTypeName ?? "Other")
                    .ToDictionary(g => g.Key, g => g.ToList());

                // Send individual notifications for each low stock utensil
                foreach (var utensil in lowStockUtensils)
                {
                    _logger.LogWarning("Low stock detected for utensil: {utensilName}, Current quantity: {quantity}",
                        utensil.Name, utensil.Quantity);

                    // Notify inventory managers about low stock
                    await notificationService.NotifyRoleAsync(
                        "InventoryManagers",
                        "LowStock",
                        "Low Utensil Stock Alert",
                        $"Low stock for {utensil.Name}: {utensil.Quantity} remaining (threshold: {DEFAULT_LOW_STOCK_THRESHOLD})",
                        new Dictionary<string, object>
                        {
                    { "EquipmentId", utensil.UtensilId },
                    { "EquipmentType", "Utensil" },
                    { "EquipmentName", utensil.Name },
                    { "Quantity", utensil.Quantity },
                    { "Threshold", DEFAULT_LOW_STOCK_THRESHOLD },
                    { "UtensilTypeName", utensil.UtensilTypeName },
                    { "CheckTime", DateTimeOffset.Now },
                    { "Priority", utensil.Quantity <= DEFAULT_LOW_STOCK_THRESHOLD / 2 ? "High" : "Medium" }
                        });
                }

                // If there are any low stock items, send a summary notification to administrators
                if (lowStockUtensils.Any())
                {
                    string summaryMessage = $"{lowStockUtensils.Count()} utensil types are low in stock";

                    // Create a summary of low stock items by type
                    var typeSummaries = lowStockByType.Select(kvp =>
                        $"{kvp.Key}: {kvp.Value.Count} items, lowest: {kvp.Value.Min(u => u.Quantity)}");

                    await notificationService.NotifyRoleAsync(
                        "Administrators",
                        "LowStockSummary",
                        "Low Stock Summary",
                        summaryMessage,
                        new Dictionary<string, object>
                        {
                    { "TotalLowStockItems", lowStockUtensils.Count() },
                    { "TypeSummaries", string.Join("; ", typeSummaries) },
                    { "ItemsByType", lowStockByType.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Select(u => u.Name).ToList()) },
                    { "CheckTime", DateTimeOffset.Now }
                        });
                }

                // Check for unavailable equipment
                var hotpotInventory = await equipmentStockService.GetAllHotPotInventoryAsync();
                var unavailableHotpots = hotpotInventory.Where(h => h.Status == "Unavailable").ToList();

                foreach (var hotpot in unavailableHotpots)
                {
                    _logger.LogWarning("Unavailable hotpot detected: {hotpotName}, Series: {series}",
                        hotpot.HotpotName ?? "Unknown", hotpot.SeriesNumber);

                    // Notify about unavailable hotpot
                    await notificationService.NotifyRoleAsync(
                        "Managers",
                        "UnavailableEquipment",
                        "HotPot Unavailable",
                        $"HotPot {hotpot.HotpotName ?? $"#{hotpot.SeriesNumber}"} is currently unavailable",
                        new Dictionary<string, object>
                        {
                    { "EquipmentId", hotpot.HotPotInventoryId },
                    { "EquipmentType", "HotPot" },
                    { "EquipmentName", hotpot.HotpotName ?? $"HotPot #{hotpot.SeriesNumber}" },
                    { "SeriesNumber", hotpot.SeriesNumber },
                    { "Status", hotpot.Status },
                    { "CheckTime", DateTimeOffset.Now },
                        });
                }

                var utensils = await equipmentStockService.GetAllUtensilsAsync();
                var unavailableUtensils = utensils.Where(u => !u.Status || u.Quantity == 0).ToList();

                foreach (var utensil in unavailableUtensils)
                {
                    string reason = utensil.Quantity == 0 ? "Out of stock" : "Equipment is currently unavailable";

                    _logger.LogWarning("Unavailable utensil detected: {utensilName}, Quantity: {quantity}, Reason: {reason}",
                        utensil.Name, utensil.Quantity, reason);

                    // Notify about unavailable utensil
                    await notificationService.NotifyRoleAsync(
                        "Managers",
                        "UnavailableEquipment",
                        "Utensil Unavailable",
                        $"Utensil {utensil.Name} is unavailable: {reason}",
                        new Dictionary<string, object>
                        {
                    { "EquipmentId", utensil.UtensilId },
                    { "EquipmentType", "Utensil" },
                    { "EquipmentName", utensil.Name },
                    { "Quantity", utensil.Quantity },
                    { "Status", utensil.Status },
                    { "Reason", reason },
                    { "UtensilTypeName", utensil.UtensilTypeName },
                    { "CheckTime", DateTimeOffset.Now },
                    { "Priority", utensil.Quantity == 0 ? "High" : "Medium" }
                        });
                }

                // Send a summary notification about unavailable equipment if any exists
                int totalUnavailable = unavailableHotpots.Count + unavailableUtensils.Count;
                if (totalUnavailable > 0)
                {
                    await notificationService.NotifyRoleAsync(
                        "Administrators",
                        "UnavailableEquipmentSummary",
                        "Unavailable Equipment Summary",
                        $"{totalUnavailable} equipment items are currently unavailable",
                        new Dictionary<string, object>
                        {
                    { "UnavailableHotpots", unavailableHotpots.Count },
                    { "UnavailableUtensils", unavailableUtensils.Count },
                    { "HotpotDetails", unavailableHotpots.Select(h => new {
                        Id = h.HotPotInventoryId,
                        Name = h.HotpotName ?? $"HotPot #{h.SeriesNumber}",
                        Status = h.Status
                    }).ToList() },
                    { "UtensilDetails", unavailableUtensils.Select(u => new {
                        Id = u.UtensilId,
                        Name = u.Name,
                        Quantity = u.Quantity,
                        Reason = u.Quantity == 0 ? "Out of stock" : "Unavailable"
                    }).ToList() },
                    { "CheckTime", DateTimeOffset.Now }
                        });
                }
            }
        }
    }
}