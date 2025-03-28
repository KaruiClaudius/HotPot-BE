using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [Route("api/customer/feedback")]
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
        public async Task<ActionResult<ApiResponse<ManagerFeedbackDetailDto>>> GetFeedbackById(int id)
        {
            var feedback = await _customerFeedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
                return NotFound(ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse($"Feedback with ID {id} not found"));

            return Ok(ApiResponse<ManagerFeedbackDetailDto>.SuccessResponse(feedback, "Feedback retrieved successfully"));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<ManagerFeedbackListDto>>>> GetUserFeedback(
            int userId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagedResult = await _customerFeedbackService.GetFeedbackByUserIdAsync(userId, pageNumber, pageSize);
            return Ok(ApiResponse<PagedResult<ManagerFeedbackListDto>>.SuccessResponse(pagedResult, "User feedback retrieved successfully"));
        }

        [HttpGet("order/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ManagerFeedbackListDto>>>> GetOrderFeedback(int orderId)
        {
            var feedback = await _customerFeedbackService.GetFeedbackByOrderIdAsync(orderId);
            return Ok(ApiResponse<IEnumerable<ManagerFeedbackListDto>>.SuccessResponse(feedback, "Order feedback retrieved successfully"));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ManagerFeedbackDetailDto>>> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            try
            {
                var feedback = await _customerFeedbackService.CreateFeedbackAsync(request);

                // Get customer name for notification
                string customerName = feedback.User?.Name ?? "Customer";

                // Notify admins about the new feedback that needs approval via SignalR
                await _feedbackHubContext.Clients.Group("Admins").SendAsync("ReceiveNewFeedback",
                    feedback.FeedbackId,
                    customerName,
                    feedback.Title,
                    feedback.CreatedAt);

                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.FeedbackId },
                    ApiResponse<ManagerFeedbackDetailDto>.SuccessResponse(feedback, "Feedback created successfully. It will be reviewed by an administrator."));
            }
            catch (InvalidOperationException ex)
            {
                // This will catch our specific foreign key validation errors
                return NotFound(ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                // This will catch other errors
                return BadRequest(ApiResponse<ManagerFeedbackDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<FeedbackStatusSummary>>> GetFeedbackStatusSummary(
            [FromQuery] int userId)
        {
            var pagedResult = await _customerFeedbackService.GetFeedbackByUserIdAsync(userId);

            // Extract the items from the paged result
            var allFeedback = pagedResult.Items;

            var summary = new FeedbackStatusSummary
            {
                TotalFeedback = pagedResult.TotalCount,
                PendingApproval = allFeedback.Count(f => f.ApprovalStatus == FeedbackApprovalStatus.Pending),
                Approved = allFeedback.Count(f => f.ApprovalStatus == FeedbackApprovalStatus.Approved),
                Rejected = allFeedback.Count(f => f.ApprovalStatus == FeedbackApprovalStatus.Rejected),
                Responded = allFeedback.Count(f => f.HasResponse)
            };

            return Ok(ApiResponse<ServiceLayer.DTOs.Management.FeedbackStatusSummary>.SuccessResponse(summary, "Feedback status summary retrieved successfully"));
        }
    }
    
}