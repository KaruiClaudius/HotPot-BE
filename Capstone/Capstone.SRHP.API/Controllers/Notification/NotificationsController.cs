using Capstone.HPTY.ServiceLayer.DTOs.Common;
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
        [ProducesResponseType(typeof(PaginatedNotificationsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PaginatedNotificationsResponse>> GetNotifications(
           [FromQuery] GetNotificationsRequest request)
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized("User ID not found in token");
            }

            var notifications = await _notificationService.GetUserNotificationsAsync(
                userId,
                request.IncludeRead,
                request.Page,
                request.PageSize);


            var response = new PaginatedNotificationsResponse
            {
                Notifications = notifications,
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                HasPreviousPage = request.Page > 1,
            };

            return Ok(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ApiResponse<NotificationCountResponse>>> GetUnreadCount()
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized(new ApiResponse<NotificationCountResponse>
                {
                    Success = false,
                    Message = "User ID not found in token"
                });
            }

            try
            {
                int count = await _notificationService.GetUnreadNotificationCountAsync(userId);

                return Ok(new ApiResponse<NotificationCountResponse>
                {
                    Success = true,
                    Data = new NotificationCountResponse
                    {
                        UnreadCount = count,
                        // If you don't have a method to get total count, you can omit this
                        TotalCount = count // This should be replaced with actual total count if available
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<NotificationCountResponse>
                {
                    Success = false,
                    Message = $"Error retrieving notification count: {ex.Message}"
                });
            }
        }

        [HttpPut("{id}/read")]
        public async Task<ActionResult<ApiResponse<object>>> MarkAsRead(int id)
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized(new ApiResponse<object>
                {
                    Success = false,
                    Message = "User ID not found in token"
                });
            }

            try
            {
                await _notificationService.MarkAsReadAsync(id, userId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Notification marked as read"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error marking notification as read: {ex.Message}"
                });
            }
        }

        [HttpPut("read-all")]
        public async Task<ActionResult<ApiResponse<object>>> MarkAllAsRead()
        {
            // Get user ID from claims
            if (!int.TryParse(User.FindFirst("id")?.Value, out int userId))
            {
                return Unauthorized(new ApiResponse<object>
                {
                    Success = false,
                    Message = "User ID not found in token"
                });
            }

            try
            {
                await _notificationService.MarkAllAsReadAsync(userId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "All notifications marked as read"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error marking all notifications as read: {ex.Message}"
                });
            }
        }

    }
}

