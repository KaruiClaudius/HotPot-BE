using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/feedback")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminFeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly INotificationService _notificationService;

        public AdminFeedbackController(
            IFeedbackService feedbackService,
            INotificationService notificationService)
        {
            _feedbackService = feedbackService;
            _notificationService = notificationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<FeedbackListDto>>>> GetFilteredFeedback([FromQuery] FeedbackFilterRequest request)
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
                return Ok(ApiResponse<PagedResult<FeedbackListDto>>.SuccessResponse(
                    pagedResult, "Feedback retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<PagedResult<FeedbackListDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<FeedbackDetailDto>>> GetFeedbackById(int id)
        {
            try
            {
                // Use the GetFeedbackDetailByIdAsync method which returns FeedbackDetailDto
                var feedback = await _feedbackService.GetFeedbackDetailByIdAsync(id);
                if (feedback == null)
                {
                    return NotFound(ApiResponse<FeedbackDetailDto>.ErrorResponse($"Feedback with ID {id} not found"));
                }

                return Ok(ApiResponse<FeedbackDetailDto>.SuccessResponse(
                    feedback, "Feedback retrieved successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<FeedbackDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FeedbackDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("by-status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<ManagerFeedbackListDto>>>> GetFeedbackByStatus(
            [FromRoute] FeedbackApprovalStatus status,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var pagedResult = await _feedbackService.GetFeedbackByStatusAsync(status, pageNumber, pageSize);

                string statusName = status.ToString().ToLower();
                return Ok(ApiResponse<PagedResult<ManagerFeedbackListDto>>.SuccessResponse(
                    pagedResult,
                    $"{char.ToUpper(statusName[0])}{statusName.Substring(1)} feedback retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<PagedResult<ManagerFeedbackListDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost("{id}/approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<FeedbackDetailDto>>> ApproveFeedback(int id, [FromBody] ApproveFeedbackRequest request)
        {
            try
            {
                var feedback = await _feedbackService.ApproveFeedbackAsync(id, request.AdminUserId);

                // Get admin name for notification
                string adminName = feedback.ApprovedByUserName ?? "Admin";

                // Notify managers about the newly approved feedback
                await _notificationService.NotifyFeedbackApproved(
                    feedback.FeedbackId,
                    adminName,
                    feedback.Title);

                // Notify the customer that their feedback was approved
                if (feedback.UserId !=0)
                {
                    await _notificationService.NotifyFeedbackResponse(
                        feedback.UserId,
                        feedback.FeedbackId,
                        "Your feedback has been approved and will be shared with our management team.",
                        adminName);
                }

                return Ok(ApiResponse<FeedbackDetailDto>.SuccessResponse(feedback, "Feedback approved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<FeedbackDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FeedbackDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost("{id}/reject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<FeedbackDetailDto>>> RejectFeedback(int id, [FromBody] RejectFeedbackRequest request)
        {
            try
            {
                var feedback = await _feedbackService.RejectFeedbackAsync(id, request.AdminUserId, request.RejectionReason);

                // Get admin name for notification
                string adminName = feedback.ApprovedByUserName ?? "Admin";

                // Notify the customer that their feedback was rejected
                if (feedback.UserId != 0)
                {
                    await _notificationService.NotifyFeedbackResponse(
                        feedback.UserId,
                        feedback.FeedbackId,
                        $"Your feedback was not approved. Reason: {request.RejectionReason}",
                        adminName);
                }

                return Ok(ApiResponse<FeedbackDetailDto>.SuccessResponse(feedback, "Feedback rejected successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<FeedbackDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FeedbackDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStats>>> GetFeedbackStats()
        {
            var stats = await _feedbackService.GetFeedbackStatsAsync();
            return Ok(ApiResponse<FeedbackStats>.SuccessResponse(stats, "Feedback statistics retrieved successfully"));
        }
    }
}