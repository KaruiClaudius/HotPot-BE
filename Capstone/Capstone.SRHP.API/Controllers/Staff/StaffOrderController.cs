using System.Security.Claims;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.Services.StaffService;
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

        [HttpGet("assigned")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffOrderDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffOrderDto>>>> GetAssignedOrders()
        {
            var userIdClaim = User.FindFirstValue("id");
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))

            {
                return Unauthorized(new { message = "User ID not found in token" });
            }
            try
            {
                _logger.LogInformation("Staff {StaffId} retrieving assigned orders", userId);

                var orders = await _staffOrderService.GetAssignedOrdersAsync(userId);
                var orderDtos = orders.Select(MapToStaffOrderDto).ToList();

                return Ok(new ApiResponse<IEnumerable<StaffOrderDto>>
                {
                    Success = true,
                    Message = "Assigned orders retrieved successfully",
                    Data = orderDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving assigned orders for staff ID: {StaffId}", userId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve assigned orders"
                });
            }
        }

        [HttpGet("by-status/{status}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffOrderDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffOrderDto>>>> GetOrdersByStatus(OrderStatus status)
        {
            try
            {
                _logger.LogInformation("Staff retrieving orders with status: {Status}", status);

                var orders = await _staffOrderService.GetOrdersByStatusAsync(status);
                var orderDtos = orders.Select(MapToStaffOrderDto).ToList();

                return Ok(new ApiResponse<IEnumerable<StaffOrderDto>>
                {
                    Success = true,
                    Message = $"Orders with status {status} retrieved successfully",
                    Data = orderDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders with status: {Status}", status);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = $"Failed to retrieve orders with status {status}"
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
                _logger.LogInformation("Staff retrieving order with ID: {OrderId}", id);

                var order = await _staffOrderService.GetOrderWithDetailsAsync(id);
                var orderDto = MapToStaffOrderDto(order);

                return Ok(new ApiResponse<StaffOrderDto>
                {
                    Success = true,
                    Message = "Order retrieved successfully",
                    Data = orderDto
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order with ID: {OrderId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve order"
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

                var updatedOrder = await _staffOrderService.UpdateOrderStatusAsync(id, request.Status, request.Notes);
                var orderDto = MapToStaffOrderDto(updatedOrder);

                return Ok(new ApiResponse<StaffOrderDto>
                {
                    Success = true,
                    Message = $"Order status updated to {request.Status} successfully",
                    Data = orderDto
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
                var orderDto = MapToStaffOrderDto(cancelledOrder);

                return Ok(new ApiResponse<StaffOrderDto>
                {
                    Success = true,
                    Message = "Order cancelled successfully",
                    Data = orderDto
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

                var orderDtos = pagedOrders.Items.Select(MapToStaffOrderDto).ToList();

                var result = new PagedResult<StaffOrderDto>
                {
                    Items = orderDtos,
                    PageNumber = pagedOrders.PageNumber,
                    PageSize = pagedOrders.PageSize,
                    TotalCount = pagedOrders.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<StaffOrderDto>>
                {
                    Success = true,
                    Message = "Order history retrieved successfully",
                    Data = result
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
        private StaffOrderDto MapToStaffOrderDto(Order order)
        {
            if (order == null) return null;

            return new StaffOrderDto
            {
                OrderId = order.OrderId,
                Address = order.Address,
                Notes = order.Notes ?? string.Empty,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                UserID = order.UserId,
                UserName = order.User?.Name ?? "Unknown",
                UserPhone = order.User?.PhoneNumber ?? "Unknown",
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                OrderDetails = order.SellOrder.SellOrderDetails?.Select(MapToOrderDetailDto).ToList() ?? new List<OrderDetailDto>()
            };
        }

        // Helper method to map OrderDetail to OrderDetailDto
        private OrderDetailDto MapToOrderDetailDto(SellOrderDetail detail)
        {
            if (detail == null) return null;

            string itemName = "Unknown";
            string itemType = "Unknown";
            int? itemId = null;

            if (detail.Ingredient != null)
            {
                itemName = detail.Ingredient.Name;
                itemType = "Ingredient";
                itemId = detail.IngredientId;
            }
            else if (detail.Customization != null)
            {
                itemName = detail.Customization.Name;
                itemType = "Customization";
                itemId = detail.CustomizationId;
            }
            else if (detail.Combo != null)
            {
                itemName = detail.Combo.Name;
                itemType = "Combo";
                itemId = detail.ComboId;
            }

            return new OrderDetailDto
            {
                OrderDetailId = detail.SellOrderDetailId,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
                ItemName = itemName,
                ItemType = itemType,
                ItemId = itemId,
             
            };
        }
    }
}
