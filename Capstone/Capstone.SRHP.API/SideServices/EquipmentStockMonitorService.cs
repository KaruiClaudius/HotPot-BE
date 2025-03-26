using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.API.SideServices
{
   public class EquipmentStockMonitorService : BackgroundService
    {
        private readonly ILogger<EquipmentStockMonitorService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<EquipmentStockHub> _hubContext;
        private readonly TimeSpan _checkInterval = TimeSpan.FromHours(6); // Check every 6 hours
        private const int DEFAULT_LOW_STOCK_THRESHOLD = 5;

        public EquipmentStockMonitorService(
            ILogger<EquipmentStockMonitorService> logger,
            IServiceProvider serviceProvider,
            IHubContext<EquipmentStockHub> hubContext)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
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

                // Check for low stock utensils
                var lowStockUtensils = await equipmentStockService.GetLowStockUtensilsAsync(DEFAULT_LOW_STOCK_THRESHOLD);
                foreach (var utensil in lowStockUtensils)
                {
                    _logger.LogWarning("Low stock detected for utensil: {utensilName}, Current quantity: {quantity}",
                        utensil.Name, utensil.Quantity);

                    // Notify administrators about low stock
                    await _hubContext.Clients.Group("Administrators").SendAsync("ReceiveLowStockAlert",
                        "Utensil",
                        utensil.Name,
                        utensil.Quantity,
                        DEFAULT_LOW_STOCK_THRESHOLD,
                        DateTime.UtcNow);
                }

                // Check for unavailable equipment
                var hotpotInventory = await equipmentStockService.GetAllHotPotInventoryAsync();
                var unavailableHotpots = hotpotInventory.Where(h => !h.Status).ToList();

                foreach (var hotpot in unavailableHotpots)
                {
                    _logger.LogWarning("Unavailable hotpot detected: {hotpotName}, Series: {series}",
                        hotpot.HotpotName ?? "Unknown", hotpot.SeriesNumber);
                }

                var utensils = await equipmentStockService.GetAllUtensilsAsync();
                var unavailableUtensils = utensils.Where(u => !u.Status || u.Quantity == 0).ToList();

                foreach (var utensil in unavailableUtensils)
                {
                    _logger.LogWarning("Unavailable utensil detected: {utensilName}, Quantity: {quantity}",
                        utensil.Name, utensil.Quantity);
                }

                // Send a summary notification to administrators
                if (unavailableHotpots.Any() || unavailableUtensils.Any() || lowStockUtensils.Any())
                {
                    await _hubContext.Clients.Group("Administrators").SendAsync("ReceiveStockSummary",
                        unavailableHotpots.Count,
                        unavailableUtensils.Count,
                        lowStockUtensils.Count(),
                        DateTime.UtcNow);
                }
            }
        }
    }
}
