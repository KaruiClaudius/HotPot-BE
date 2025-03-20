using System.Security.Claims;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/staff/rentals")]
    [ApiController]
    [Authorize(Roles = "Staff")]

    public class StaffRentalController : ControllerBase
    {
        private readonly IRentOrderService _rentOrderService;
        private readonly IStaffService _staffService;
        private readonly INotificationService _notificationService;


        public StaffRentalController(IRentOrderService rentOrderService, IStaffService staffService, INotificationService notificationService)
        {
            _rentOrderService = rentOrderService;
            _staffService = staffService;
            _notificationService = notificationService;
        }

        [HttpGet("my-assignments")]
        public async Task<ActionResult<ApiResponse<List<StaffPickupAssignmentDto>>>> GetMyAssignments()
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                var myAssignments = await _staffService.GetStaffAssignmentsAsync(staffId);
                return Ok(ApiResponse<List<StaffPickupAssignmentDto>>.SuccessResponse(myAssignments, "My assignments retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<StaffPickupAssignmentDto>>.ErrorResponse(ex.Message));
            }
        }

        // Mark an assignment as completed
        [HttpPost("complete-assignment")]
        public async Task<ActionResult<ApiResponse<bool>>> CompleteAssignment([FromBody] CompletePickupRequestDto request)
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                // Verify the assignment belongs to this staff member
                var myAssignments = await _staffService.GetStaffAssignmentsAsync(staffId);
                var assignment = myAssignments.FirstOrDefault(a => a.AssignmentId == request.AssignmentId);

                if (assignment == null)
                {
                    return NotFound(ApiResponse<bool>.ErrorResponse("Assignment not found or does not belong to you"));
                }

                var result = await _staffService.CompletePickupAssignmentAsync(
                    request.AssignmentId,
                    request.CompletedDate,
                    request.ReturnCondition,
                    request.DamageFee);

                // Send notification to the staff member
                await _notificationService.NotifyStaffAssignmentCompletedAsync(staffId, request.AssignmentId);

                // Send notification to managers
                await _notificationService.NotifyManagerAssignmentCompletedAsync(
                    request.AssignmentId,
                    staffId,
                    assignment.StaffName ?? "Staff member");

                return Ok(ApiResponse<bool>.SuccessResponse(result, "Assignment completed successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("all-pending-pickups")]
        public async Task<ActionResult<PagedResult<RentOrderDetail>>> GetAllPendingPickups([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pendingPickups = await _rentOrderService.GetPendingPickupsAsync(pageNumber, pageSize);
                return Ok(pendingPickups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("my-pending-pickups")]
        public async Task<ActionResult<ApiResponse<List<StaffPickupAssignmentDto>>>> GetMyPendingPickups()
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                var myAssignments = await _staffService.GetStaffAssignmentsAsync(staffId);
                var pendingPickups = myAssignments.Where(a => a.CompletedDate == null).ToList();

                return Ok(ApiResponse<List<StaffPickupAssignmentDto>>.SuccessResponse(pendingPickups, "My pending pickups retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<StaffPickupAssignmentDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<PagedResult<RentOrderDetail>>> GetOverdueRentals([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var overdueRentals = await _rentOrderService.GetOverdueRentalsAsync(pageNumber, pageSize);
                return Ok(overdueRentals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalDetail(int id)
        {
            try
            {
                var rentOrderDetail = await _rentOrderService.GetByIdAsync(id);
                return Ok(rentOrderDetail);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("{id}/return")]
        public async Task<IActionResult> RecordReturn(int id, [FromBody] RecordReturnRequest request)
        {
            try
            {
                var result = await _rentOrderService.RecordEquipmentReturnAsync(id, request);

                // Get the rental detail to notify the customer
                var rentOrderDetail = await _rentOrderService.GetByIdAsync(id);

                // Send notification to the customer
                if (rentOrderDetail.Order?.UserId != null)
                {
                    await _notificationService.NotifyCustomerRentalReturnedAsync(
                        rentOrderDetail.Order.UserId,
                        id);
                }

                return Ok(new { message = "Equipment return recorded successfully" });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
