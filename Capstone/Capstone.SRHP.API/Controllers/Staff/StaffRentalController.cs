using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
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
        private readonly INotificationService _notificationService;


        public StaffRentalController(IRentOrderService rentOrderService, 
            IStaffService staffService,
            IEquipmentReturnService equipmentReturnService, 
            INotificationService notificationService)
        {
            _rentOrderService = rentOrderService;
            _staffService = staffService;
            _equipmentReturnService = equipmentReturnService;
            _notificationService = notificationService;
        }

        [HttpGet("my-assignments")]
        public async Task<ActionResult<ApiResponse<List<StaffPickupAssignmentDto>>>> GetMyAssignments([FromQuery] bool pendingOnly = false)
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                var myAssignments = await _staffService.GetStaffAssignmentsAsync(staffId);

                // Filter for pending pickups if requested
                if (pendingOnly)
                {
                    myAssignments = myAssignments.Where(a => a.CompletedDate == null).ToList();
                }

                return Ok(ApiResponse<List<StaffPickupAssignmentDto>>.SuccessResponse(
                    myAssignments,
                    pendingOnly ? "My pending pickups retrieved successfully" : "My assignments retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<StaffPickupAssignmentDto>>.ErrorResponse(ex.Message));
            }
        }
      

        [HttpGet("all-pending-pickups")]
        public async Task<ActionResult<PagedResult<RentalListingDto>>> GetAllPendingPickups([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
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
      
        [HttpGet("overdue")]
        public async Task<ActionResult<PagedResult<RentalListingDto>>> GetOverdueRentals([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
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
                var rentOrderDetail = await _equipmentReturnService.GetRentOrderDetailAsync(id);
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

        [HttpPost("record-return")]
        public async Task<ActionResult<ApiResponse<bool>>> RecordReturn([FromBody] UnifiedReturnRequestDto request)
        {
            try
            {
                // Get current staff ID from claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int staffId = int.Parse(userIdClaim.Value);

                // Create the equipment return request with staff ID
                var equipmentReturnRequest = new EquipmentReturnRequest
                {
                    RentOrderDetailId = request.RentOrderDetailId,
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
                        request.AssignmentId.Value,
                        equipmentReturnRequest);
                }
                else if (request.RentOrderDetailId.HasValue)
                {
                    // Process direct equipment return
                    result = await _equipmentReturnService.ProcessEquipmentReturnAsync(equipmentReturnRequest);
                }
                else
                {
                    return BadRequest(ApiResponse<bool>.ErrorResponse("Either AssignmentId or RentOrderDetailId must be provided"));
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
