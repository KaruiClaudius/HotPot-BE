using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]

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
            var feedback = await _managerFeedbackService.GetAllFeedbackAsync(pageNumber, pageSize);
            var totalCount = await _managerFeedbackService.GetTotalFeedbackCountAsync();

            var pagedResult = new PagedResult<Feedback>
            {
                Items = feedback,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<Feedback>>.SuccessResponse(pagedResult, "Feedback retrieved successfully"));
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

            // For simplicity, we're not implementing a separate count method for user feedback
            // In a real application, you would want to do this for better performance
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
            return Ok(ApiResponse<IEnumerable<Feedback>>.SuccessResponse(feedback, "Order feedback retrieved successfully"));
        }
        // FeedbackController.cs (continued)
        [HttpPost("{id}/respond")]
        [Authorize(Roles = "Manager")]
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
                if (feedback.Manager?.User != null)
                {
                    managerName = feedback.Manager.User.Name;
                }

                // Notify the customer about the response via SignalR
                await _feedbackHubContext.Clients.User(feedback.UserID.ToString()).SendAsync("ReceiveFeedbackResponse",
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
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
        }

        

        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStats>>> GetFeedbackStats()
        {
            var totalCount = await _managerFeedbackService.GetTotalFeedbackCountAsync();
            var unrespondedCount = await _managerFeedbackService.GetUnrespondedFeedbackCountAsync();

            var stats = new FeedbackStats
            {
                TotalFeedbackCount = totalCount,
                UnrespondedFeedbackCount = unrespondedCount,
                RespondedFeedbackCount = totalCount - unrespondedCount,
                ResponseRate = totalCount > 0 ? (double)(totalCount - unrespondedCount) / totalCount * 100 : 0
            };

            return Ok(ApiResponse<FeedbackStats>.SuccessResponse(stats, "Feedback statistics retrieved successfully"));
        }
     
       
    }
}
