using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/feedback")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdminFeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IHubContext<FeedbackHub> _feedbackHubContext;

        public AdminFeedbackController(IFeedbackService feedbackService, IHubContext<FeedbackHub> feedbackHubContext)
        {
            _feedbackService = feedbackService;
            _feedbackHubContext = feedbackHubContext;
        }

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetFilteredFeedback([FromQuery] FeedbackFilterRequest request)
        {
            try
            {
                // Validate and fix request parameters
                if (request.PageNumber < 1)
                    request.PageNumber = 1;

                if (request.PageSize < 1)
                    request.PageSize = 10;
                else if (request.PageSize > 100)
                    request.PageSize = 100;

                if (request.FromDate.HasValue && request.ToDate.HasValue && request.FromDate > request.ToDate)
                {
                    var temp = request.FromDate;
                    request.FromDate = request.ToDate;
                    request.ToDate = temp;
                }

                var pagedResult = await _feedbackService.GetFilteredFeedbackAsync(request);

                return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(
                    pagedResult,
                    "Feedback retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<PagedResult<Feedback>>.ErrorResponse(ex.Message));
            }
        }


        [HttpGet("by-status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetFeedbackByStatus(
     [FromRoute] FeedbackApprovalStatus status,
     [FromQuery] int pageNumber = 1,
     [FromQuery] int pageSize = 10)
        {
            try
            {
                var feedback = await _feedbackService.GetFeedbackByStatusAsync(status, pageNumber, pageSize);
                var totalCount = await _feedbackService.GetFeedbackCountByStatusAsync(status);

                var pagedResult = new PagedResult<Feedback>
                {
                    Items = feedback,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                string statusName = status.ToString().ToLower();
                return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(
                    pagedResult,
                    $"{char.ToUpper(statusName[0])}{statusName.Substring(1)} feedback retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<PagedResult<Feedback>>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost("{id}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Feedback>>> ApproveFeedback(int id, [FromBody] ApproveFeedbackRequest request)
        {
            try
            {
                var feedback = await _feedbackService.ApproveFeedbackAsync(id, request.AdminUserId);

                // Get admin name for notification
                string adminName = "Admin";
                if (feedback.ApprovedByUser != null)
                {
                    adminName = feedback.ApprovedByUser.Name;
                }

                // Notify managers about the newly approved feedback via SignalR
                await _feedbackHubContext.Clients.Group("Managers").SendAsync("ReceiveApprovedFeedback",
                    feedback.FeedbackId,
                    feedback.Title,
                    feedback.UserId,
                    feedback.User?.Name ?? "Customer",
                    feedback.ApprovalDate);

                // Notify the customer that their feedback was approved
                await _feedbackHubContext.Clients.User(feedback.UserId.ToString()).SendAsync("FeedbackApproved",
                    feedback.FeedbackId,
                    adminName,
                    feedback.ApprovalDate);

                return Ok(ApiResponse<Feedback>.SuccessResponse(feedback, "Feedback approved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost("{id}/reject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Feedback>>> RejectFeedback(int id, [FromBody] RejectFeedbackRequest request)
        {
            try
            {
                var feedback = await _feedbackService.RejectFeedbackAsync(id, request.AdminUserId, request.RejectionReason);

                // Get admin name for notification
                string adminName = "Admin";
                if (feedback.ApprovedByUser != null)
                {
                    adminName = feedback.ApprovedByUser.Name;
                }

                // Notify the customer that their feedback was rejected
                await _feedbackHubContext.Clients.User(feedback.UserId.ToString()).SendAsync("FeedbackRejected",
                    feedback.FeedbackId,
                    adminName,
                    feedback.RejectionReason,
                    feedback.ApprovalDate);

                return Ok(ApiResponse<Feedback>.SuccessResponse(feedback, "Feedback rejected successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Feedback>.ErrorResponse(ex.Message));
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
            var totalCount = await _feedbackService.GetTotalFeedbackCountAsync();
            var pendingCount = (await _feedbackService.GetFeedbackCountByStatusAsync(FeedbackApprovalStatus.Pending));
            var unrespondedCount = await _feedbackService.GetUnrespondedFeedbackCountAsync();

            // Calculate approved and rejected counts
            var approvedCount = (await _feedbackService.GetFeedbackCountByStatusAsync(FeedbackApprovalStatus.Approved));
            var rejectedCount = (await _feedbackService.GetFeedbackCountByStatusAsync(FeedbackApprovalStatus.Rejected));

            var stats = new FeedbackStats
            {
                TotalFeedbackCount = totalCount,
                PendingFeedbackCount = pendingCount,
                ApprovedFeedbackCount = approvedCount,
                RejectedFeedbackCount = rejectedCount,
                UnrespondedFeedbackCount = unrespondedCount,
                ResponseRate = approvedCount > 0 ? (double)(approvedCount - unrespondedCount) / approvedCount * 100 : 0
            };

            return Ok(ApiResponse<FeedbackStats>.SuccessResponse(stats, "Feedback statistics retrieved successfully"));
        }
    }
}
