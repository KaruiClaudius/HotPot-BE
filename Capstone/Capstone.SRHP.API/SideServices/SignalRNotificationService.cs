using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.API.SideServices;
using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.SignalR;

public class SignalRNotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
    private readonly IConnectionManager _connectionManager;

    public SignalRNotificationService(
        IHubContext<NotificationHub, INotificationClient> hubContext,
        IConnectionManager connectionManager)
    {
        _hubContext = hubContext;
        _connectionManager = connectionManager;
    }

    // Equipment notifications
    public async Task NotifyEquipmentIssue(int equipmentId, string equipmentType, string equipmentName, string issue, string details)
    {
        var notification = new NotificationDto
        {
            Type = "EquipmentIssue",
            Title = "Equipment Issue Detected",
            Message = $"Issue detected with {equipmentName}: {issue}",
            Timestamp = DateTime.UtcNow,
            Data = new Dictionary<string, object>
            {
                { "EquipmentId", equipmentId },
                { "EquipmentType", equipmentType },
                { "EquipmentName", equipmentName },
                { "Issue", issue },
                { "Details", details }
            }
        };

        await _hubContext.Clients.Group("Administrators").ReceiveNotification(notification);
        await _hubContext.Clients.Group("Managers").ReceiveNotification(notification);
    }

    // Inventory notifications
    public async Task NotifyInventoryStatus(string itemType, string itemName, int quantity, int threshold, bool isLow)
    {
        var notification = new NotificationDto
        {
            Type = isLow ? "LowStock" : "InventoryUpdate",
            Title = isLow ? "Low Stock Alert" : "Inventory Update",
            Message = isLow
                ? $"Low stock for {itemName}: {quantity} remaining (threshold: {threshold})"
                : $"Inventory update for {itemName}: {quantity} in stock",
            Timestamp = DateTime.UtcNow,
            Data = new Dictionary<string, object>
            {
                { "ItemType", itemType },
                { "ItemName", itemName },
                { "Quantity", quantity },
                { "Threshold", threshold }
            }
        };

        await _hubContext.Clients.Group("Administrators").ReceiveNotification(notification);
        await _hubContext.Clients.Group("Managers").ReceiveNotification(notification);
    }

    // User notifications
    public async Task NotifyUser(int userId, string type, string title, string message, Dictionary<string, object> data = null)
    {
        var notification = new NotificationDto
        {
            Type = type,
            Title = title,
            Message = message,
            Timestamp = DateTime.UtcNow,
            Data = data ?? new Dictionary<string, object>()
        };

        await _hubContext.Clients.Group($"User_{userId}").ReceiveNotification(notification);
    }

    // Role notifications
    public async Task NotifyRole(string role, string type, string title, string message, Dictionary<string, object> data = null)
    {
        var notification = new NotificationDto
        {
            Type = type,
            Title = title,
            Message = message,
            Timestamp = DateTime.UtcNow,
            Data = data ?? new Dictionary<string, object>()
        };

        await _hubContext.Clients.Group(role).ReceiveNotification(notification);
    }

    // Feedback notifications
    public async Task NotifyFeedback(string target, string targetId, string feedbackType, string title, string message, Dictionary<string, object> data = null)
    {
        var notification = new NotificationDto
        {
            Type = feedbackType,
            Title = title,
            Message = message,
            Timestamp = DateTime.UtcNow,
            Data = data ?? new Dictionary<string, object>()
        };

        if (target.Equals("User", StringComparison.OrdinalIgnoreCase) && int.TryParse(targetId, out int userId))
        {
            await _hubContext.Clients.Group($"User_{userId}").ReceiveNotification(notification);
        }
        else if (target.Equals("Role", StringComparison.OrdinalIgnoreCase))
        {
            await _hubContext.Clients.Group(targetId).ReceiveNotification(notification);
        }
    }
}