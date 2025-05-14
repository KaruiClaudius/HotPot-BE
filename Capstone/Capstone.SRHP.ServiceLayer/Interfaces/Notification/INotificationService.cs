using System;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.Interfaces.Notification
{
    public interface INotificationService
    {
        // Create and store notifications
        Task<int> CreateNotificationAsync(string type, string title, string message, string targetType, string targetId, Dictionary<string, object> data = null);
        Task<int> CreateUserNotificationAsync(int notificationId, int userId);

        // Send notifications through SignalR
        Task NotifyUserAsync(int userId, string type, string title, string message, Dictionary<string, object> data = null);
        Task NotifyRoleAsync(string role, string type, string title, string message, Dictionary<string, object> data = null);
        Task NotifyAllAsync(string type, string title, string message, Dictionary<string, object> data = null);

        // Manage notifications
        Task<List<NotificationDto>> GetUserNotificationsAsync(int userId, bool includeRead = false, int page = 1, int pageSize = 20);
        Task<int> GetUnreadNotificationCountAsync(int userId);
        Task MarkAsReadAsync(int userNotificationId, int userId);
        Task MarkAllAsReadAsync(int userId);
        Task MarkAsDeliveredAsync(int notificationId, int userId);

        // Template-based notifications
        Task<int> CreateFromTemplateAsync(string templateCode, Dictionary<string, string> placeholders, string targetType, string targetId, Dictionary<string, object> data = null);
    }
}