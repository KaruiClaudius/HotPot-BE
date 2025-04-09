using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    //public class CartCleanupService : BackgroundService
    //{
    //    private readonly IServiceProvider _serviceProvider;
    //    private readonly ILogger<CartCleanupService> _logger;
    //    private readonly TimeSpan _cleanupInterval;
    //    private readonly TimeSpan _abandonThreshold;

    //    public CartCleanupService(
    //        IServiceProvider serviceProvider,
    //        ILogger<CartCleanupService> logger,
    //        IConfiguration configuration)
    //    {
    //        _serviceProvider = serviceProvider;
    //        _logger = logger;

    //        // Get configuration values with defaults
    //        _cleanupInterval = TimeSpan.FromMinutes(
    //            configuration.GetValue<int>("CartCleanup:IntervalMinutes", 60));
    //        _abandonThreshold = TimeSpan.FromHours(
    //            configuration.GetValue<int>("CartCleanup:AbandonThresholdHours", 24));
    //    }

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        _logger.LogInformation("Cart cleanup service is starting");

    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            _logger.LogInformation("Running cart cleanup task");

    //            try
    //            {
    //                using (var scope = _serviceProvider.CreateScope())
    //                {
    //                    var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
    //                    await orderService.CleanupAbandonedCartsAsync(_abandonThreshold);
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                _logger.LogError(ex, "Error occurred while cleaning up abandoned carts");
    //            }

    //            await Task.Delay(_cleanupInterval, stoppingToken);
    //        }

    //        _logger.LogInformation("Cart cleanup service is stopping");
    //    }
    //}
}
