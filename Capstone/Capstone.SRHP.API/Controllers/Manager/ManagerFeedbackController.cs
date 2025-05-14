using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/feedback")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerFeedbackController : ControllerBase
    {
        private readonly IFeedbackService _managerFeedbackService;
        private readonly INotificationService _notificationService;

        public ManagerFeedbackController(
            IFeedbackService managerFeedbackService,
            INotificationService notificationService)
        {
            _managerFeedbackService = managerFeedbackService;
            _notificationService = notificationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<ManagerFeedbackListDto>>>> GetAllFeedback(
           [FromQuery] int pageNumber = 1,
           [FromQuery] int pageSize = 10)
        {
            // Only get approved feedback
            var pagedResult = await _managerFeedbackService.GetFeedbackByStatusAsync(
                FeedbackApprovalStatus.Approved, pageNumber, pageSize);

            return Ok(ApiResponse<PagedResult<ManagerFeedbackListDto>>.SuccessResponse(
                pagedResult, "Approved feedback retrieved successfully"));
        }

        [HttpGet("unresponded")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<ManagerFeedbackListDto>>>> GetUnrespondedFeedback(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagedResult = await _managerFeedbackService.GetUnrespondedFeedbackAsync(pageNumber, pageSize);

            return Ok(ApiResponse<PagedResult<ManagerFeedbackListDto>>.SuccessResponse(
                pagedResult, "Unresponded feedback retrieved successfully"));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<ManagerFeedbackListDto>>>> GetFeedbackByUserId(
            int userId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagedResult = await _managerFeedbackService.GetFeedbackByUserIdAsync(
                userId, pageNumber, pageSize);

            return Ok(ApiResponse<PagedResult<ManagerFeedbackListDto>>.SuccessResponse(
                pagedResult, "User feedback retrieved successfully"));
        }

        [HttpGet("order/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ManagerFeedbackListDto>>>> GetFeedbackByOrderId(int orderId)
        {
            var feedback = await _managerFeedbackService.GetFeedbackByOrderIdAsync(orderId);

            return Ok(ApiResponse<IEnumerable<ManagerFeedbackListDto>>.SuccessResponse(
                feedback, "Order feedback retrieved successfully"));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ManagerFeedbackDetailDto>>> GetFeedbackById(int id)
        {
            var feedback = await _managerFeedbackService.GetFeedbackByIdAsync(id);

            if (feedback == null)
            {
                return NotFound(ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse("Feedback not found"));
            }

            return Ok(ApiResponse<ManagerFeedbackDetailDto>.SuccessResponse(
                feedback, "Feedback retrieved successfully"));
        }

        [HttpPost("{id}/respond")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse<ManagerFeedbackDetailDto>>> RespondToFeedback(
int id, [FromBody] RespondToFeedbackRequest request)
        {
            try
            {
                var feedback = await _managerFeedbackService.RespondToFeedbackAsync(
                    id, request.ManagerId, request.Response);

                // Get manager name for notification
                string managerName = feedback.Manager?.Name ?? "Manager";

                // Notify the customer about the response via the simplified notification service
                await _notificationService.NotifyUserAsync(
                    feedback.User.UserId,
                    "FeedbackResponse",
                    "Response to Your Feedback",
                    $"A manager has responded to your feedback: {feedback.Title}",
                    new Dictionary<string, object>
                    {
                { "FeedbackId", feedback.FeedbackId },
                { "Title", feedback.Title },
                { "Response", feedback.Response },
                { "ResponderName", managerName },
                { "ResponderId", request.ManagerId },
                { "ResponseDate", DateTime.UtcNow },
                    });

                // Also notify other managers about the response for transparency
                await _notificationService.NotifyRoleAsync(
                    "Managers",
                    "FeedbackResponseAdded",
                    "Feedback Response Added",
                    $"{managerName} responded to feedback: {feedback.Title}",
                    new Dictionary<string, object>
                    {
                { "FeedbackId", feedback.FeedbackId },
                { "Title", feedback.Title },
                { "Response", feedback.Response },
                { "ResponderName", managerName },
                { "ResponderId", request.ManagerId },
                { "ResponseDate", DateTime.UtcNow },
                { "CustomerName", feedback.User?.Name ?? "Customer" },
                { "CustomerId", feedback.User?.UserId ?? 0 },
                    });

                return Ok(ApiResponse<ManagerFeedbackDetailDto>.SuccessResponse(
                    feedback, "Response added successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                // This will catch the error when trying to respond to unapproved feedback
                return StatusCode(StatusCodes.Status403Forbidden,
                    ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStats>>> GetFeedbackStats()
        {
            var stats = await _managerFeedbackService.GetFeedbackStatsAsync();

            return Ok(ApiResponse<FeedbackStats>.SuccessResponse(
                stats, "Feedback statistics retrieved successfully"));
        }
    }
}