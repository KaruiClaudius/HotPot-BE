using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/[controller]")]
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

        [HttpGet("pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetPendingFeedback(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var feedback = await _feedbackService.GetPendingFeedbackAsync(pageNumber, pageSize);
            var totalCount = await _feedbackService.GetPendingFeedbackCountAsync();

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "Pending feedback retrieved successfully"));
        }

        [HttpGet("approved")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetApprovedFeedback(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var feedback = await _feedbackService.GetApprovedFeedbackAsync(pageNumber, pageSize);

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = feedback.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "Approved feedback retrieved successfully"));
        }

        [HttpGet("rejected")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Feedback>>>> GetRejectedFeedback(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var feedback = await _feedbackService.GetRejectedFeedbackAsync(pageNumber, pageSize);

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = feedback.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "Rejected feedback retrieved successfully"));
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
                    feedback.UserID,
                    feedback.User?.Name ?? "Customer",
                    feedback.ApprovalDate);

                // Notify the customer that their feedback was approved
                await _feedbackHubContext.Clients.User(feedback.UserID.ToString()).SendAsync("FeedbackApproved",
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
                await _feedbackHubContext.Clients.User(feedback.UserID.ToString()).SendAsync("FeedbackRejected",
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
            var pendingCount = await _feedbackService.GetPendingFeedbackCountAsync();
            var unrespondedCount = await _feedbackService.GetUnrespondedFeedbackCountAsync();

            // Calculate approved and rejected counts
            // Note: This is a simplified approach. For better performance, you might want to add specific methods to count these
            var approvedCount = totalCount - pendingCount - (await _feedbackService.GetRejectedFeedbackAsync()).Count();
            var rejectedCount = totalCount - pendingCount - approvedCount;

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
