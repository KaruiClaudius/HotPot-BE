using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/rentals")]
    [ApiController]
    [Authorize(Roles = "Manager")]

    public class ManagerRentalController : ControllerBase
    {
        private readonly IRentOrderService _rentOrderService;
        private readonly IStaffService _staffService;
        private readonly INotificationService _notificationService;

        public ManagerRentalController(
            IRentOrderService rentOrderService,
            IStaffService staffService,
            INotificationService notificationService
           )
        {
            _rentOrderService = rentOrderService;
            _staffService = staffService;
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
                // First get the order detail to have all the necessary information
                var orderDetail = await _rentOrderService.GetOrderDetailAsync(request.RentOrderDetailId);

                // Assign staff to pickup using the correct IDs
                var result = await _staffService.AssignStaffToPickupAsync(
                    request.StaffId,
                    request.RentOrderDetailId,
                    request.VehicleId,
                    request.Notes);

                // Get the created assignment
                var assignments = await _staffService.GetStaffAssignmentsAsync(request.StaffId);

                // Find the assignment with the matching OrderId
                var assignmentDto = assignments.FirstOrDefault(a => a.OrderId == orderDetail.OrderId);

                if (assignmentDto == null)
                {
                    return NotFound(ApiResponse<StaffPickupAssignmentDto>.ErrorResponse(
                        $"Assignment for order {orderDetail.OrderId} not found"));
                }

                // Get staff information
                var staff = await _staffService.GetStaffByIdAsync(request.StaffId);
                string staffName = staff?.Name ?? "Staff Member";

                // Notify the staff member about the new assignment
                await _notificationService.NotifyUserAsync(
                    request.StaffId,
                    "NewAssignment",
                    "Nhiệm Vụ Thu Hồi Mới",
                    $"Bạn đã được phân công thu hồi thiết bị từ {orderDetail.CustomerName}",
                    new Dictionary<string, object>
                    {
                        { "AssignmentId", assignmentDto.AssignmentId },
                        { "OrderId", orderDetail.OrderId },
                        { "CustomerName", orderDetail.CustomerName },
                        { "PickupAddress", orderDetail.CustomerAddress },
                        { "Notes", request.Notes ?? "Không có ghi chú bổ sung" },
                        { "AssignmentType", "Pickup" },
                    });


                return Ok(ApiResponse<StaffPickupAssignmentDto>.SuccessResponse(
                    assignmentDto, "Staff allocated for equipment pickup successfully"));
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
