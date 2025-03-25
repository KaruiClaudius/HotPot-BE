using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/order-management")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerOrderManagementController : ControllerBase
    {
        private readonly IOrderManagementService _orderManagementService;

        public ManagerOrderManagementController(IOrderManagementService orderManagementService)
        {
            _orderManagementService = orderManagementService;
        }

        // Order allocation endpoints
        [HttpPost("allocate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ShippingOrder>>> AllocateOrderToStaff([FromBody] AllocateOrderRequest request)
        {
            try
            {
                var result = await _orderManagementService.AllocateOrderToStaff(request.OrderId, request.StaffId);
                return Ok(ApiResponse<ShippingOrder>.SuccessResponse(result, "Order allocated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ShippingOrder>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ShippingOrder>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("unallocated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Order>>>> GetUnallocatedOrders(
             [FromQuery] OrderQueryParams queryParams = null)
        {
            // If no query params provided, create with defaults
            queryParams ??= new OrderQueryParams { PageNumber = 1, PageSize = 10 };

            var pagedOrders = await _orderManagementService.GetUnallocatedOrdersPaged(queryParams);

            return Ok(ApiResponse<PagedResult<Order>>.SuccessResponse(
                pagedOrders,
                $"Unallocated orders retrieved successfully (Page {pagedOrders.PageNumber} of {pagedOrders.TotalPages})"));
        }

        [HttpGet("staff/{staffId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ShippingOrder>>>> GetOrdersByStaff(int staffId)
        {
            try
            {
                var orders = await _orderManagementService.GetOrdersByStaff(staffId);
                return Ok(ApiResponse<IEnumerable<ShippingOrder>>.SuccessResponse(orders, $"Orders for staff {staffId} retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<IEnumerable<ShippingOrder>>.ErrorResponse(ex.Message));
            }
        }

        // Order status tracking endpoints
        [HttpPut("status/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Order>>> UpdateOrderStatus(int orderId, [FromBody] ManagerOrderStatusUpdateRequest request)
        {
            try
            {
                var order = await _orderManagementService.UpdateOrderStatus(orderId, request.Status);
                return Ok(ApiResponse<Order>.SuccessResponse(order, "Order status updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Order>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Order>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("details/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<Order>>> GetOrderWithDetails(int orderId)
        {
            try
            {
                var order = await _orderManagementService.GetOrderWithDetails(orderId);
                return Ok(ApiResponse<Order>.SuccessResponse(order, "Order details retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Order>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<Order>>>> GetOrdersByStatus(
            OrderStatus? status= null,
            [FromQuery] OrderQueryParams queryParams = null)
        {
            // If no query params provided, create with defaults
            queryParams ??= new OrderQueryParams { PageNumber = 1, PageSize = 10 };

            // Set the status from the route parameter
            queryParams.Status = status;

            var pagedOrders = await _orderManagementService.GetOrdersByStatusPaged(queryParams);

            return Ok(ApiResponse<PagedResult<Order>>.SuccessResponse(
                pagedOrders,
                $"Orders with status {status} retrieved successfully (Page {pagedOrders.PageNumber} of {pagedOrders.TotalPages})"));
        }

        // Delivery progress monitoring endpoints
        [HttpPut("delivery/status/{shippingOrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ShippingOrder>>> UpdateDeliveryStatus(int shippingOrderId, [FromBody] UpdateDeliveryStatusRequest request)
        {
            try
            {
                var shippingOrder = await _orderManagementService.UpdateDeliveryStatus(
                    shippingOrderId,
                    request.IsDelivered,
                    request.Notes);

                return Ok(ApiResponse<ShippingOrder>.SuccessResponse(shippingOrder, "Delivery status updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ShippingOrder>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ShippingOrder>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("pending-deliveries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<ShippingOrder>>>> GetPendingDeliveries(
           [FromQuery] ShippingOrderQueryParams queryParams = null)
        {
            // If no query params provided, create with defaults
            queryParams ??= new ShippingOrderQueryParams { PageNumber = 1, PageSize = 10 };

            var pagedDeliveries = await _orderManagementService.GetPendingDeliveriesPaged(queryParams);

            return Ok(ApiResponse<PagedResult<ShippingOrder>>.SuccessResponse(
                pagedDeliveries,
                $"Pending deliveries retrieved successfully (Page {pagedDeliveries.PageNumber} of {pagedDeliveries.TotalPages})"));
        }

        [HttpPut("delivery/time/{shippingOrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ShippingOrder>>> UpdateDeliveryTime(int shippingOrderId, [FromBody] UpdateDeliveryTimeRequest request)
        {
            try
            {
                var shippingOrder = await _orderManagementService.UpdateDeliveryTime(
                    shippingOrderId,
                    request.DeliveryTime);

                return Ok(ApiResponse<ShippingOrder>.SuccessResponse(shippingOrder, "Delivery time updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ShippingOrder>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ShippingOrder>.ErrorResponse(ex.Message));
            }
        }
             
    }
}