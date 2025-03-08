using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]

    public class CustomerFeedbackController : ControllerBase
    {
        private readonly IFeedbackService _customerFeedbackService;
        private readonly IHubContext<FeedbackHub> _feedbackHubContext;

        public CustomerFeedbackController(IFeedbackService customerFeedbackService, IHubContext<FeedbackHub> feedbackHubContext)
        {
            _customerFeedbackService = customerFeedbackService;
            _feedbackHubContext = feedbackHubContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<Feedback>>> GetFeedbackById(int id)
        {
            var feedback = await _customerFeedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
                return NotFound(ApiResponse<Feedback>.ErrorResponse($"Feedback with ID {id} not found"));

            return Ok(ApiResponse<Feedback>.SuccessResponse(feedback, "Feedback retrieved successfully"));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<Feedback>>>> GetUserFeedback(
            int userId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var feedback = await _customerFeedbackService.GetFeedbackByUserIdAsync(userId, pageNumber, pageSize);
            return Ok(ApiResponse<IEnumerable<Feedback>>.SuccessResponse(feedback, "User feedback retrieved successfully"));
        }

        [HttpGet("order/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<Feedback>>>> GetOrderFeedback(int orderId)
        {
            var feedback = await _customerFeedbackService.GetFeedbackByOrderIdAsync(orderId);
            return Ok(ApiResponse<IEnumerable<Feedback>>.SuccessResponse(feedback, "Order feedback retrieved successfully"));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Feedback>>> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            try
            {
                var feedback = await _customerFeedbackService.CreateFeedbackAsync(request);

                // Get customer name for notification
                string customerName = "Customer";
                if (feedback.User != null)
                {
                    customerName = feedback.User.Name;
                }

                // Notify admins about the new feedback that needs approval via SignalR
                await _feedbackHubContext.Clients.Group("Admins").SendAsync("ReceiveNewFeedback",
                    feedback.FeedbackId,
                    customerName,
                    feedback.Title,
                    feedback.CreatedAt);

                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.FeedbackId },
                    ApiResponse<Feedback>.SuccessResponse(feedback, "Feedback created successfully. It will be reviewed by an administrator."));
            }
            catch (InvalidOperationException ex)
            {
                // This will catch our specific foreign key validation errors
                return NotFound(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                // This will catch other errors
                return BadRequest(ApiResponse<Feedback>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStatusSummary>>> GetFeedbackStatusSummary(
            [FromQuery] int userId)
        {
            var allFeedback = await _customerFeedbackService.GetFeedbackByUserIdAsync(userId);

            var summary = new FeedbackStatusSummary
            {
                TotalFeedback = allFeedback.Count(),
                PendingApproval = allFeedback.Count(f => f.ApprovalStatus == FeedbackApprovalStatus.Pending),
                Approved = allFeedback.Count(f => f.ApprovalStatus == FeedbackApprovalStatus.Approved),
                Rejected = allFeedback.Count(f => f.ApprovalStatus == FeedbackApprovalStatus.Rejected),
                Responded = allFeedback.Count(f => f.Response != null)
            };

            return Ok(ApiResponse<FeedbackStatusSummary>.SuccessResponse(summary, "Feedback status summary retrieved successfully"));
        }
    }
}

