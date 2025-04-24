using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/rentals")]
    [ApiController]
    [Authorize(Roles = "Manager")]

    public class ManagerRentalController : ControllerBase
    {
        private readonly IRentOrderService _rentOrderService;
        private readonly IStaffService _staffService;
        private readonly IEquipmentReturnService _equipmentReturnService;
        private readonly INotificationService _notificationService;

        public ManagerRentalController(
            IRentOrderService rentOrderService,
            IStaffService staffService,
            IEquipmentReturnService equipmentReturnService,
            INotificationService notificationService)
        {
            _rentOrderService = rentOrderService;
            _staffService = staffService;
            _equipmentReturnService = equipmentReturnService;
            _notificationService = notificationService;
        }

        [HttpGet("unassigned-pickups")]
        public async Task<ActionResult<ApiResponse<PagedResult<RentOrderDetailResponse>>>> GetUnassignedPickups([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var unassignedPickups = await _rentOrderService.GetUnassignedPickupsAsync(pageNumber, pageSize);
                return Ok(ApiResponse<PagedResult<RentOrderDetailResponse>>.SuccessResponse(unassignedPickups, "Unassigned pickups retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResult<RentOrderDetailDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost("allocate-pickup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<StaffPickupAssignmentDto>>> AllocateStaffForPickup([FromBody] PickupAssignmentRequestDto request)
        {
            try
            {
                var result = await _staffService.AssignStaffToPickupAsync(
                    request.StaffId,
                    request.RentOrderDetailId,
                    request.Notes);

                // Get the created assignment
                var assignments = await _staffService.GetStaffAssignmentsAsync(request.StaffId);
                var assignmentDto = assignments.FirstOrDefault(a => a.OrderId == request.RentOrderDetailId);

                if (assignmentDto == null)
                {
                    return NotFound(ApiResponse<StaffPickupAssignmentDto>.ErrorResponse($"Assignment for rent order detail {request.RentOrderDetailId} not found"));
                }

                // Notify the staff member about the new assignment
                await _notificationService.NotifyStaffNewAssignmentAsync(
                    request.StaffId,
                    assignmentDto.AssignmentId,
                    assignmentDto);

                return Ok(ApiResponse<StaffPickupAssignmentDto>.SuccessResponse(assignmentDto, "Staff allocated for equipment pickup successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<StaffPickupAssignmentDto>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<StaffPickupAssignmentDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<StaffPickupAssignmentDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRentalHistory()
        {
            try
            {
                var rentalHistory = await _rentOrderService.GetRentalHistoryByUserAsync();
                return Ok(rentalHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("hotpot/{hotpotInventoryId}")]
        public async Task<IActionResult> GetRentalHistoryByHotpot(int? hotpotInventoryId = null)
        {
            try
            {
                var rentalHistory = await _rentOrderService.GetRentalHistoryByEquipmentAsync(hotpotInventoryId: hotpotInventoryId);
                return Ok(rentalHistory);
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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRentalHistoryByUser(int? userId = null)
        {
            try
            {
                var rentalHistory = await _rentOrderService.GetRentalHistoryByUserAsync(userId);
                return Ok(rentalHistory);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> AdjustReturnDateForException(int id, [FromBody] UpdateRentOrderDetailRequest request)
        {
            try
            {
                var rentOrder = await _equipmentReturnService.GetRentOrderAsync(id);
                var result = await _rentOrderService.UpdateRentOrderDetailAsync(id, request);

                // Notify the customer if the return date has changed
                if (!string.IsNullOrEmpty(request.ExpectedReturnDate) &&
                    DateTime.TryParse(request.ExpectedReturnDate, out DateTime parsedDate) &&
                    rentOrder.ExpectedReturnDate != parsedDate &&
                    rentOrder.Order?.UserId != null)
                {
                    await _notificationService.NotifyCustomerRentalExtendedAsync(
                        rentOrder.Order.UserId,
                        id,
                        parsedDate);
                }

                return Ok(ApiResponse<bool>.SuccessResponse(result, "Rental detail updated successfully"));
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
                return StatusCode(500, ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}/calculate-late-fee")]
        public async Task<IActionResult> CalculateLateFee(int id, [FromQuery] DateTime actualReturnDate)
        {
            try
            {
                var lateFee = await _rentOrderService.CalculateLateFeeAsync(id, actualReturnDate);
                return Ok(new { lateFee });
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

        [HttpGet("current-assignments")]
        public async Task<ActionResult<ApiResponse<PagedResult<StaffPickupAssignmentDto>>>> GetCurrentAssignments([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var currentAssignments = await _staffService.GetAllCurrentAssignmentsAsync(pageNumber, pageSize);
                return Ok(ApiResponse<PagedResult<StaffPickupAssignmentDto>>.SuccessResponse(currentAssignments, "Current assignments retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<PagedResult<StaffPickupAssignmentDto>>.ErrorResponse(ex.Message));
            }
        }
    }
}
