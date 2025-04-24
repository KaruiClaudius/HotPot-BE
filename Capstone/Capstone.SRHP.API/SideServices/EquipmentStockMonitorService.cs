using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
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
                foreach (var utensil in lowStockUtensils)
                {
                    _logger.LogWarning("Low stock detected for utensil: {utensilName}, Current quantity: {quantity}",
                        utensil.Name, utensil.Quantity);

                    // Notify administrators about low stock
                    await notificationService.NotifyLowStock(
                        "Utensil",
                        utensil.Name,
                        utensil.Quantity,
                        DEFAULT_LOW_STOCK_THRESHOLD);
                }

                // Check for unavailable equipment
                var hotpotInventory = await equipmentStockService.GetAllHotPotInventoryAsync();
                var unavailableHotpots = hotpotInventory.Where(h => h.Status == "Unavailable").ToList();

                foreach (var hotpot in unavailableHotpots)
                {
                    _logger.LogWarning("Unavailable hotpot detected: {hotpotName}, Series: {series}",
                        hotpot.HotpotName ?? "Unknown", hotpot.SeriesNumber);

                    // Notify about unavailable hotpot
                    await notificationService.NotifyStatusChange(
                        "HotPot",
                        hotpot.HotPotInventoryId,
                        hotpot.HotpotName ?? $"HotPot #{hotpot.SeriesNumber}",
                        false,
                        "Equipment is currently unavailable");
                }

                var utensils = await equipmentStockService.GetAllUtensilsAsync();
                var unavailableUtensils = utensils.Where(u => !u.Status || u.Quantity == 0).ToList();

                foreach (var utensil in unavailableUtensils)
                {
                    _logger.LogWarning("Unavailable utensil detected: {utensilName}, Quantity: {quantity}",
                        utensil.Name, utensil.Quantity);

                    // Notify about unavailable utensil
                    await notificationService.NotifyStatusChange(
                        "Utensil",
                        utensil.UtensilId,
                        utensil.Name,
                        false,
                        utensil.Quantity == 0 ? "Out of stock" : "Equipment is currently unavailable");
                }

                // No need for a separate summary notification as the individual notifications will be sufficient
                // with the new notification system that handles grouping and aggregation
            }
        }
    }
}