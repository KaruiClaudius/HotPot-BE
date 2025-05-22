using System.Security.Claims;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [ApiController]
    [Route("api/staff/orders")]
    [Authorize(Roles = "Staff")]
    public class StaffOrderController : ControllerBase
    {
        private readonly IStaffOrderService _staffOrderService;
        private readonly ILogger<StaffOrderController> _logger;

        public StaffOrderController(
            IStaffOrderService staffOrderService,
            ILogger<StaffOrderController> logger)
        {
            _staffOrderService = staffOrderService;
            _logger = logger;
        }

        //   [HttpGet("assigned")]
        //   [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>), StatusCodes.Status200OK)]
        //   public async Task<ActionResult<ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>>> GetAssignedOrders(
        //[FromQuery] StaffTaskType taskType = StaffTaskType.Preparation,
        //[FromQuery] OrderStatus? statusFilter = null)
        //   {
        //       var userIdClaim = User.FindFirstValue("id");
        //       if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
        //       {
        //           return Unauthorized(new { message = "User ID not found in token" });
        //       }

        //       try
        //       {
        //           _logger.LogInformation("Staff {StaffId} retrieving assigned orders for task type {TaskType} with status filter {StatusFilter}",
        //               userId, taskType, statusFilter);
        //           var orders = await _staffOrderService.GetAssignedOrdersAsync(userId, taskType, statusFilter);

        //           return Ok(new ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>
        //           {
        //               Success = true,
        //               Message = $"Assigned {taskType} orders retrieved successfully",
        //               Data = orders
        //           });
        //       }
        //       catch (Exception ex)
        //       {
        //           _logger.LogError(ex, "Error retrieving {TaskType} orders for staff ID: {StaffId}", taskType, userId);
        //           return BadRequest(new ApiErrorResponse
        //           {
        //               Status = "Error",
        //               Message = $"Failed to retrieve {taskType} orders"
        //           });
        //       }
        //   }

        [HttpGet("assigned")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>>> GetAssignedOrders(
  [FromQuery] StaffTaskType taskType = StaffTaskType.Preparation)
        {
            var userIdClaim = User.FindFirstValue("id");
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized(new { message = "User ID not found in token" });
            }

            try
            {
                _logger.LogInformation("Staff {StaffId} retrieving assigned orders for task type {TaskType}", userId, taskType);
                var orders = await _staffOrderService.GetAssignedOrdersAsync(userId, taskType);

                return Ok(new ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>
                {
                    Success = true,
                    Message = $"Assigned {taskType} orders retrieved successfully",
                    Data = orders
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving {TaskType} orders for staff ID: {StaffId}", taskType, userId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = $"Failed to retrieve {taskType} orders"
                });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<StaffOrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<StaffOrderDto>>> GetOrderById(int id)
        {
            try
            {
                _logger.LogInformation("Staff retrieving order details for ID: {OrderId}", id);
                var order = await _staffOrderService.GetOrderWithDetailsAsync(id);

                return Ok(new ApiResponse<StaffOrderDto>
                {
                    Success = true,
                    Message = "Order details retrieved successfully",
                    Data = order
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Order not found with ID: {OrderId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order details for ID: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve order details"
                });
            }
        }


        [HttpPut("{id}/status")]
        [ProducesResponseType(typeof(ApiResponse<StaffOrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<StaffOrderDto>>> UpdateOrderStatus(
            int id,
            [FromBody] UpdateOrderStatusRequest request)
        {
            try
            {
                _logger.LogInformation("Staff updating order {OrderId} status to {NewStatus}", id, request.Status);

                // Get the current staff ID from the token
                var userIdClaim = User.FindFirstValue("id");
                if (userIdClaim == null || !int.TryParse(userIdClaim, out int staffId))
                {
                    return Unauthorized(new { message = "User ID not found in token" });
                }

                var updatedOrder = await _staffOrderService.UpdateOrderStatusAsync(id, request.Status, staffId);

                return Ok(new ApiResponse<StaffOrderDto>
                {
                    Success = true,
                    Message = $"Order status updated to {request.Status} successfully",
                    Data = updatedOrder
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Order not found with ID: {OrderId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating order status: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order status: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update order status"
                });
            }
        }


        [HttpPut("{id}/cancel")]
        [ProducesResponseType(typeof(ApiResponse<StaffOrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<StaffOrderDto>>> CancelOrder(
            int id,
            [FromBody] CancelOrderRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Staff cancelling order with ID: {OrderId}, Reason: {Reason}", id, request.CancellationReason);
                var cancelledOrder = await _staffOrderService.CancelOrderAsync(id, request.CancellationReason);

                return Ok(new ApiResponse<StaffOrderDto>
                {
                    Success = true,
                    Message = "Order cancelled successfully",
                    Data = cancelledOrder
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Order not found with ID: {OrderId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error cancelling order: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Request to cancel order {OrderId} was cancelled by the client", id);
                return StatusCode(499, new ApiErrorResponse
                {
                    Status = "Cancelled",
                    Message = "The request was cancelled by the client"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to cancel order"
                });
            }
        }


        [HttpGet("history")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<StaffOrderDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<StaffOrderDto>>>> GetOrderHistory(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] OrderStatus? status = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Page number and page size must be greater than 0"
                    });
                }

                _logger.LogInformation("Staff retrieving order history - Page {PageNumber}, Size {PageSize}, Status {Status}, StartDate {StartDate}, EndDate {EndDate}",
                    pageNumber, pageSize, status, startDate, endDate);

                var pagedOrders = await _staffOrderService.GetOrderHistoryAsync(pageNumber, pageSize, status, startDate, endDate);

                return Ok(new ApiResponse<PagedResult<StaffOrderDto>>
                {
                    Success = true,
                    Message = "Order history retrieved successfully",
                    Data = pagedOrders
                });
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Request to get order history was cancelled by the client");
                return StatusCode(499, new ApiErrorResponse
                {
                    Status = "Cancelled",
                    Message = "The request was cancelled by the client"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order history");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve order history"
                });
            }
        }


        [HttpGet("{id}/vehicle")]
        [ProducesResponseType(typeof(ApiResponse<VehicleInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<VehicleInfoDto>>> GetVehicleInfo(int id)
        {
            try
            {
                _logger.LogInformation("Staff retrieving vehicle information for order ID: {OrderId}", id);
                var vehicleInfo = await _staffOrderService.GetVehicleInfoAsync(id);

                return Ok(new ApiResponse<VehicleInfoDto>
                {
                    Success = true,
                    Message = "Vehicle information retrieved successfully",
                    Data = vehicleInfo
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Vehicle information not found for order ID: {OrderId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving vehicle information for order ID: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve vehicle information"
                });
            }
        }
    }
}