using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.BackgroundServices
{
    public class OrderReturnReminderService : BackgroundService
    {
        private readonly ILogger<OrderReturnReminderService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _checkInterval = TimeSpan.FromHours(1); // Check every hour

        public OrderReturnReminderService(
            ILogger<OrderReturnReminderService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Order Return Reminder Service is starting.");

            using PeriodicTimer timer = new(_checkInterval);

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await CheckOrdersForReturnAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Order Return Reminder Service is stopping.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in Order Return Reminder Service.");
                throw;
            }
        }

        private async Task CheckOrdersForReturnAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Checking orders for return status updates...");

            try
            {
                // Create a scope to resolve scoped services
                using var scope = _serviceProvider.CreateScope();
                var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                // Get current time with Vietnam timezone offset
                var currentTime = DateTime.UtcNow.AddHours(7);

                // Get all orders that are in Delivered status and have rental items
                var deliveredOrders = await unitOfWork.Repository<Order>()
                    .IncludeNested(query =>
                        query.Include(o => o.RentOrder)
                             .Include(o => o.User))
                    .Where(o => o.Status == OrderStatus.Delivered &&
                                  o.HasRentItems &&
                                  o.RentOrder != null &&
                                  !o.IsDelete)
                    .ToListAsync();

                _logger.LogInformation("Found {Count} delivered orders with rental items to check", deliveredOrders.Count);

                foreach (var order in deliveredOrders)
                {
                    if (stoppingToken.IsCancellationRequested)
                        break;

                    try
                    {
                        // Check if the expected return date has been reached or passed
                        if (order.RentOrder.ExpectedReturnDate <= currentTime)
                        {
                            _logger.LogInformation("Order {OrderId} has reached its return date. Updating status to Returning.",
                                order.OrderId);

                            // Update the order status to Returning
                            await orderService.UpdateStatusAsync(order.OrderId, OrderStatus.Returning);

                            // Send a reminder notification to the customer
                            if (order.User != null)
                            {
                                await notificationService.NotifyUserAsync(
                                    order.UserId,
                                    "Order",
                                    "Nhắc Nhở Trả Lại Nồi Lẩu",
                                    $"Đơn hàng #{order.OrderId} của bạn đã đến ngày trả lại. Vui lòng trả lại nồi lẩu sớm nhất có thể.",
                                    new Dictionary<string, object>
                                    {
                                    { "OrderId", order.OrderId },
                                    { "OrderCode", order.OrderCode },
                                    { "ExpectedReturnDate", order.RentOrder.ExpectedReturnDate.ToString("dd/MM/yyyy HH:mm") },
                                    { "Instructions", "Vui lòng trả lại nồi lẩu trong tình trạng sạch sẽ và đầy đủ phụ kiện." },
                                    { "ContactInfo", "Nếu bạn cần hỗ trợ, vui lòng liên hệ với chúng tôi qua số điện thoại 0123456789." }
                                    });
                            }
                        }
                        else
                        {
                            // If the return date is approaching (within 1 hours), send a reminder
                            TimeSpan timeUntilReturn = order.RentOrder.ExpectedReturnDate - currentTime;
                            if (timeUntilReturn.TotalHours <= 1 && timeUntilReturn.TotalHours > 0)
                            {
                                _logger.LogInformation("Order {OrderId} is approaching its return date. Sending reminder.",
                                    order.OrderId);

                                // Send a reminder notification to the customer
                                if (order.User != null)
                                {
                                    await notificationService.NotifyUserAsync(
                                        order.UserId,
                                        "Order",
                                        "Sắp Đến Ngày Trả Lại Nồi Lẩu",
                                        $"Đơn hàng #{order.OrderId} của bạn sẽ đến ngày trả lại trong {Math.Round(timeUntilReturn.TotalHours)} giờ nữa.",
                                        new Dictionary<string, object>
                                        {
                                        { "OrderId", order.OrderId },
                                        { "OrderCode", order.OrderCode },
                                        { "ExpectedReturnDate", order.RentOrder.ExpectedReturnDate.ToString("dd/MM/yyyy HH:mm") },
                                        { "HoursRemaining", Math.Round(timeUntilReturn.TotalHours) },
                                        { "Instructions", "Vui lòng chuẩn bị trả lại nồi lẩu trong tình trạng sạch sẽ và đầy đủ phụ kiện." }
                                        });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing order {OrderId} for return status update", order.OrderId);
                        // Continue with the next order
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CheckOrdersForReturnAsync");
            }
        }
    }
}
