using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Services.FeedbackService;
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

                var pagedResult = await _managerFeedbackService.GetFilteredFeedbackAsync(request);
                return Ok(ApiResponse<PagedResult<FeedbackListDto>>.SuccessResponse(
                    pagedResult, "Đã lấy phản hồi thành công"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<PagedResult<FeedbackListDto>>.ErrorResponse(ex.Message));
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