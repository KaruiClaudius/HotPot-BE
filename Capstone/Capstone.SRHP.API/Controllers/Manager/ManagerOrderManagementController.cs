using Capstone.HPTY.API.Controllers.Staff;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
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
        private readonly ILogger<ManagerOrderManagementController> _logger;


        public ManagerOrderManagementController(IOrderManagementService orderManagementService,
            ILogger<ManagerOrderManagementController> logger)
        {
            _orderManagementService = orderManagementService;
            _logger = logger;
        }

        [HttpPost("assign-preparation-staff")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<OrderPreparationDTO>>> AssignPreparationStaff([FromBody] AssignPreparationStaffRequest request)
        {
            try
            {
                var result = await _orderManagementService.AssignPreparationStaff(request.OrderId, request.StaffId);
                return Ok(ApiResponse<OrderPreparationDTO>.SuccessResponse(result, "Preparation staff assigned successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<OrderPreparationDTO>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<OrderPreparationDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<OrderPreparationDTO>.ErrorResponse(ex.Message));
            }
        }

        // Order allocation endpoints
        [HttpPost("allocate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ShippingOrderAllocationDTO>>> AllocateOrderToStaff([FromBody] AllocateOrderRequest request)
        {
            try
            {
                var result = await _orderManagementService.AllocateOrderToStaff(request.OrderId, request.StaffId);
                return Ok(ApiResponse<ShippingOrderAllocationDTO>.SuccessResponse(result, "Order allocated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ShippingOrderAllocationDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ShippingOrderAllocationDTO>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("unallocated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<UnallocatedOrderDTO>>>> GetUnallocatedOrders(
             [FromQuery] OrderQueryParams queryParams = null)
        {
            // If no query params provided, create with defaults
            queryParams ??= new OrderQueryParams { PageNumber = 1, PageSize = 10 };

            var pagedOrders = await _orderManagementService.GetUnallocatedOrdersPaged(queryParams);

            return Ok(ApiResponse<PagedResult<UnallocatedOrderDTO>>.SuccessResponse(
                pagedOrders,
                $"Unallocated orders retrieved successfully (Page {pagedOrders.PageNumber} of {pagedOrders.TotalPages})"));
        }

        [HttpGet("staff/{staffId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffShippingOrderDTO>>>> GetOrdersByStaff(int staffId)
        {
            try
            {
                var orders = await _orderManagementService.GetOrdersByStaff(staffId);
                return Ok(ApiResponse<IEnumerable<StaffShippingOrderDTO>>.SuccessResponse(orders, $"Orders for staff {staffId} retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<IEnumerable<StaffShippingOrderDTO>>.ErrorResponse(ex.Message));
            }
        }

        // Order status tracking endpoints
        [HttpPut("status/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<OrderStatusUpdateDTO>>> UpdateOrderStatus(string orderId, [FromBody] ManagerOrderStatusUpdateRequest request)
        {
            try
            {
                var order = await _orderManagementService.UpdateOrderStatus(orderId, request.Status);
                return Ok(ApiResponse<OrderStatusUpdateDTO>.SuccessResponse(order, "Order status updated successfully"));
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
        public async Task<ActionResult<ApiResponse<OrderDetailDTO>>> GetOrderWithDetails(string orderId)
        {
            try
            {
                var order = await _orderManagementService.GetOrderWithDetails(orderId);
                return Ok(ApiResponse<OrderDetailDTO>.SuccessResponse(order, "Order details retrieved successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<OrderDetailDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<OrderDetailDTO>.ErrorResponse($"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<OrderWithDetailsDTO>>>> GetOrdersByStatus(
            OrderStatus? status= null,
            [FromQuery] OrderQueryParams queryParams = null)
        {
            // If no query params provided, create with defaults
            queryParams ??= new OrderQueryParams { PageNumber = 1, PageSize = 10 };

            // Set the status from the route parameter
            queryParams.Status = status;

            var pagedOrders = await _orderManagementService.GetOrdersByStatusPaged(queryParams);

            return Ok(ApiResponse<PagedResult<OrderWithDetailsDTO>>.SuccessResponse(
                pagedOrders,
                $"Orders with status {status} retrieved successfully (Page {pagedOrders.PageNumber} of {pagedOrders.TotalPages})"));
        }

        // Delivery progress monitoring endpoints
        [HttpPut("delivery/status/{shippingOrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<DeliveryStatusUpdateDTO>>> UpdateDeliveryStatus(int shippingOrderId, [FromBody] UpdateDeliveryStatusRequest request)
        {
            try
            {
                var shippingOrder = await _orderManagementService.UpdateDeliveryStatus(
                    shippingOrderId,
                    request.IsDelivered,
                    request.Notes);

                return Ok(ApiResponse<DeliveryStatusUpdateDTO>.SuccessResponse(shippingOrder, "Delivery status updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<DeliveryStatusUpdateDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<DeliveryStatusUpdateDTO>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("pending-deliveries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<PendingDeliveryDTO>>>> GetPendingDeliveries(
           [FromQuery] ShippingOrderQueryParams queryParams = null)
        {
            // If no query params provided, create with defaults
            queryParams ??= new ShippingOrderQueryParams { PageNumber = 1, PageSize = 10 };

            var pagedDeliveries = await _orderManagementService.GetPendingDeliveriesPaged(queryParams);

            return Ok(ApiResponse<PagedResult<PendingDeliveryDTO>>.SuccessResponse(
                pagedDeliveries,
                $"Pending deliveries retrieved successfully (Page {pagedDeliveries.PageNumber} of {pagedDeliveries.TotalPages})"));
        }

        [HttpPut("delivery/time/{shippingOrderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<DeliveryTimeUpdateDTO>>> UpdateDeliveryTime(int shippingOrderId, [FromBody] UpdateDeliveryTimeRequest request)
        {
            try
            {
                var shippingOrder = await _orderManagementService.UpdateDeliveryTime(
                    shippingOrderId,
                    request.DeliveryTime);

                return Ok(ApiResponse<DeliveryTimeUpdateDTO>.SuccessResponse(shippingOrder, "Delivery time updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<DeliveryTimeUpdateDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<DeliveryTimeUpdateDTO>.ErrorResponse(ex.Message));
            }
        }


        [HttpPost("allocate-with-vehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ShippingOrderAllocationDTO>>> AllocateOrderToStaffWithVehicle([FromBody] AllocateOrderWithVehicleRequest request)
        {
            try
            {
                var result = await _orderManagementService.AllocateOrderToStaffWithVehicle(
                    request.OrderId,
                    request.StaffId,
                    request.VehicleId);

                return Ok(ApiResponse<ShippingOrderAllocationDTO>.SuccessResponse(
                    result,
                    "Order allocated successfully with vehicle"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ShippingOrderAllocationDTO>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<ShippingOrderAllocationDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ShippingOrderAllocationDTO>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("estimate-size/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<OrderSizeDTO>>> EstimateOrderSize(int orderId)
        {
            try
            {
                var orderSize = await _orderManagementService.EstimateOrderSizeAsync(orderId);

                var result = new OrderSizeDTO
                {
                    OrderId = orderId,
                    Size = orderSize,
                    SuggestedVehicleType = orderSize == OrderSize.Large ? VehicleType.Car : VehicleType.Scooter
                };

                return Ok(ApiResponse<OrderSizeDTO>.SuccessResponse(
                    result,
                    $"Order size estimated as {orderSize}"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<OrderSizeDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error estimating size for order {OrderId}", orderId);
                return StatusCode(500, ApiResponse<OrderSizeDTO>.ErrorResponse($"An error occurred: {ex.Message}"));
            }
        }

    }
}