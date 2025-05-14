using System;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.DTOs.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }

    public class UserNotificationDto
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public NotificationDto Notification { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }

    public class NotificationTemplateDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string MessageTemplate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class SendNotificationRequest
    {
        public int TargetId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }

    public class SendRoleNotificationRequest
    {
        public string Role { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }

}