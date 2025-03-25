using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/feedback")]
    [ApiController]
    [Authorize(Roles = "Quản lý")]
    public class ManagerFeedbackController : ControllerBase
    {
        private readonly IFeedbackService _managerFeedbackService;
        private readonly IHubContext<FeedbackHub> _feedbackHubContext;

        public ManagerFeedbackController(IFeedbackService managerFeedbackService, IHubContext<FeedbackHub> feedbackHubContext)
        {
            _managerFeedbackService = managerFeedbackService;
            _feedbackHubContext = feedbackHubContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetAllFeedback(
           [FromQuery] int pageNumber = 1,
           [FromQuery] int pageSize = 10)
        {
            // Only get approved feedback
            var feedback = await _managerFeedbackService.GetFeedbackByStatusAsync(FeedbackApprovalStatus.Approved,pageNumber, pageSize);
            var totalCount = feedback.Count();

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "Approved feedback retrieved successfully"));
        }

        [HttpGet("unresponded")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetUnrespondedFeedback(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var feedback = await _managerFeedbackService.GetUnrespondedFeedbackAsync(pageNumber, pageSize);
            var totalCount = await _managerFeedbackService.GetUnrespondedFeedbackCountAsync();

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "Unresponded feedback retrieved successfully"));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetFeedbackByUserId(
            int userId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var feedback = await _managerFeedbackService.GetFeedbackByUserIdAsync(userId, pageNumber, pageSize);

            // Filter to only show approved feedback
            feedback = feedback.Where(f => f.ApprovalStatus == FeedbackApprovalStatus.Approved).ToList();

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = feedback.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "User feedback retrieved successfully"));
        }

        [HttpGet("order/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<Feedback>>>> GetFeedbackByOrderId(int orderId)
        {
            var feedback = await _managerFeedbackService.GetFeedbackByOrderIdAsync(orderId);

            // Filter to only show approved feedback
            feedback = feedback.Where(f => f.ApprovalStatus == FeedbackApprovalStatus.Approved).ToList();

            return Ok(ApiResponse<IEnumerable<Feedback>>.SuccessResponse(feedback, "Order feedback retrieved successfully"));
        }

        [HttpPost("{id}/respond")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse<Feedback>>> RespondToFeedback(int id, [FromBody] RespondToFeedbackRequest request)
        {
            try
            {
                var feedback = await _managerFeedbackService.RespondToFeedbackAsync(id, request.ManagerId, request.Response);

                // Get manager name for notification
                string managerName = "Manager";
                if (feedback.Manager != null)
                {
                    managerName = feedback.Manager.Name;
                }

                // Notify the customer about the response via SignalR
                await _feedbackHubContext.Clients.User(feedback.UserId.ToString()).SendAsync("ReceiveFeedbackResponse",
                    feedback.FeedbackId,
                    feedback.Response,
                    managerName,
                    feedback.ResponseDate);

                return Ok(ApiResponse<Feedback>.SuccessResponse(feedback, "Response added successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                // This will catch the error when trying to respond to unapproved feedback
                return StatusCode(StatusCodes.Status403Forbidden, ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStats>>> GetFeedbackStats()
        {
            // Only count approved feedback for managers
            var approvedCount = (await _managerFeedbackService.GetFeedbackCountByStatusAsync(FeedbackApprovalStatus.Approved));
            var unrespondedCount = await _managerFeedbackService.GetUnrespondedFeedbackCountAsync();

            var stats = new FeedbackStats
            {
                TotalFeedbackCount = approvedCount,
                UnrespondedFeedbackCount = unrespondedCount,
                RespondedFeedbackCount = approvedCount - unrespondedCount,
                ResponseRate = approvedCount > 0 ? (double)(approvedCount - unrespondedCount) / approvedCount * 100 : 0
            };

            return Ok(ApiResponse<FeedbackStats>.SuccessResponse(stats, "Feedback statistics retrieved successfully"));
        }
    }
}