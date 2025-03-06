using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
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
    //[Authorize(Roles = "Customer")]

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

                // Notify managers about the new feedback via SignalR
                await _feedbackHubContext.Clients.Group("Managers").SendAsync("ReceiveNewFeedback",
                    feedback.FeedbackId,
                    customerName,
                    feedback.Title,
                    feedback.CreatedAt);

                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.FeedbackId },
                    ApiResponse<Feedback>.SuccessResponse(feedback, "Feedback created successfully"));
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
    }
}
