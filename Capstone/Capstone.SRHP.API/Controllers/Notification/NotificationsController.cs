using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Notification
{
    [Route("api/notifications")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotificationDto>>> GetNotifications(
            [FromQuery] bool includeRead = false,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized("User ID not found in token");
            }

            var notifications = await _notificationService.GetUserNotificationsAsync(userId, includeRead, page, pageSize);
            return Ok(notifications);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetUnreadCount()
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized("User ID not found in token");
            }

            int count = await _notificationService.GetUnreadNotificationCountAsync(userId);
            return Ok(count);
        }

        [HttpPut("{id}/read")]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized("User ID not found in token");
            }

            await _notificationService.MarkAsReadAsync(id, userId);
            return NoContent();
        }

        [HttpPut("read-all")]
        public async Task<ActionResult> MarkAllAsRead()
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized("User ID not found in token");
            }

            await _notificationService.MarkAllAsReadAsync(userId);
            return NoContent();
        }

        [HttpPost("send-user")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> SendUserNotification([FromBody] SendNotificationRequest request)
        {
            await _notificationService.NotifyUserAsync(
                request.TargetId,
                request.Type,
                request.Title,
                request.Message,
                request.Data);

            return Ok();
        }

        [HttpPost("send-role")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> SendRoleNotification([FromBody] SendRoleNotificationRequest request)
        {
            await _notificationService.NotifyRoleAsync(
                request.Role,
                request.Type,
                request.Title,
                request.Message,
                request.Data);

            return Ok();
        }

        [HttpPost("send-all")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> SendAllNotification([FromBody] SendNotificationRequest request)
        {
            await _notificationService.NotifyAllAsync(
                request.Type,
                request.Title,
                request.Message,
                request.Data);

            return Ok();
        }
    }
}

