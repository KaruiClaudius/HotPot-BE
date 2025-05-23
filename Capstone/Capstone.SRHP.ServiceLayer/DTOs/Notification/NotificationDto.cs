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

    public class GetNotificationsRequest
    {
        public bool IncludeRead { get; set; } = false;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class PaginatedNotificationsResponse
    {

        public List<NotificationDto> Notifications { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

    }

    public class NotificationCountResponse
    {
        /// <summary>
        /// Number of unread notifications
        /// </summary>
        public int UnreadCount { get; set; }

        /// <summary>
        /// Total number of notifications
        /// </summary>
        public int TotalCount { get; set; }
    }


}