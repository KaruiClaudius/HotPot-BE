using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IEquipmentReturnService _equipmentReturnService;

        public StaffRentalController(IRentOrderService rentOrderService,
            IStaffService staffService,
            IEquipmentReturnService equipmentReturnService
            )
        {
            _rentOrderService = rentOrderService;
            _staffService = staffService;
            _equipmentReturnService = equipmentReturnService;

        }

        [HttpGet("my-assignments")]
        public async Task<ActionResult<ApiResponse<PagedResult<StaffPickupAssignmentDto>>>> GetMyAssignments(
            [FromQuery] bool pendingOnly = false,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                // Fetch paginated assignments
                var pagedAssignments = await _staffService.GetStaffAssignmentsPaginatedAsync(staffId, pendingOnly, pageNumber, pageSize);

                return Ok(ApiResponse<PagedResult<StaffPickupAssignmentDto>>.SuccessResponse(
                    pagedAssignments,
                    pendingOnly ? "My pending pickups retrieved successfully" : "My assignments retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResult<StaffPickupAssignmentDto>>.ErrorResponse(ex.Message));
            }
        }


        [HttpGet("listings")]
        public async Task<ActionResult<PagedResult<RentalListingDto>>> GetRentalListings(
                   [FromQuery] string type = "pending",
                   [FromQuery] int pageNumber = 1,
                   [FromQuery] int pageSize = 10)
        {
            try
            {
                if (type.Equals("pending", StringComparison.OrdinalIgnoreCase))
                {
                    var pendingPickups = await _rentOrderService.GetPendingPickupsAsync(pageNumber, pageSize);
                    return Ok(pendingPickups);
                }
                else if (type.Equals("overdue", StringComparison.OrdinalIgnoreCase))
                {
                    var overdueRentals = await _rentOrderService.GetOverdueRentalsAsync(pageNumber, pageSize);
                    return Ok(overdueRentals);
                }
                else
                {
                    return BadRequest(new { message = "Invalid type. Please specify 'pending' or 'overdue'." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetRentOrder(int id)
        {
            try
            {
                var rentOrder = await _equipmentReturnService.GetRentOrderAsync(id);
                return Ok(rentOrder);
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

        [HttpPost("record-return")]
        public async Task<ActionResult<ApiResponse<bool>>> RecordReturn([FromBody] UnifiedReturnRequestDto request)
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                // Create the equipment return request with staff ID
                var equipmentReturnRequest = new EquipmentReturnRequest
                {
                    RentOrderId = request.RentOrderId,
                    ReturnDate = request.CompletedDate,
                    ReturnCondition = request.ReturnCondition,
                    DamageFee = request.DamageFee,
                    Notes = request.Notes,
                    StaffId = staffId
                };

                bool result;

                // Handle based on whether this is an assignment completion or direct return
                if (request.AssignmentId.HasValue)
                {
                    // Verify the assignment belongs to this staff member
                    var myAssignments = await _staffService.GetStaffAssignmentsAsync(staffId);
                    var assignment = myAssignments.FirstOrDefault(a => a.AssignmentId == request.AssignmentId.Value);

                    if (assignment == null)
                    {
                        return NotFound(ApiResponse<bool>.ErrorResponse("Assignment not found or does not belong to you"));
                    }

                    // Process the assignment completion
                    result = await _equipmentReturnService.CompletePickupAssignmentAsync(
                        request.AssignmentId.Value);
                }
                else if (request.RentOrderId.HasValue)
                {
                    // Process direct order return (new primary method)
                    result = await _equipmentReturnService.ProcessEquipmentReturnAsync(equipmentReturnRequest);
                }
                else
                {
                    return BadRequest(ApiResponse<bool>.ErrorResponse("Either AssignmentId, OrderId, or RentOrderDetailId must be provided"));
                }

                return Ok(ApiResponse<bool>.SuccessResponse(result, "Return recorded successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }
    }
}
