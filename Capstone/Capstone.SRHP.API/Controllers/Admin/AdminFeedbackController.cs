using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
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
                    pagedResult, "Đã lấy phản hồi thành công"));
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
                    return NotFound(ApiResponse<FeedbackDetailDto>.ErrorResponse($"Không tìm thấy phản hồi với ID {id}"));
                }

                return Ok(ApiResponse<FeedbackDetailDto>.SuccessResponse(
                    feedback, "Đã lấy phản hồi thành công"));
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

        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStats>>> GetFeedbackStats()
        {
            var stats = await _feedbackService.GetFeedbackStatsAsync();
            return Ok(ApiResponse<FeedbackStats>.SuccessResponse(stats, "Thống kê phản hồi đã được lấy thành công."));
        }
    }
}