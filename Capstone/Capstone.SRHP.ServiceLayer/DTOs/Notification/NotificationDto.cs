using System;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.DTOs.Notification
{
    public class NotificationDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }

    public class TargetedNotificationDto : NotificationDto
    {
        public string Target { get; set; } // User, Role, or Group
        public string TargetId { get; set; } // UserId, RoleName, or GroupName
    }

}