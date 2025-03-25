using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.OrderHistory
{
    [Route("api/order-history")]
    [ApiController]
    [Authorize(Roles = "Nhân viên,Quản trị viên")]

    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;
        private readonly ILogger<OrderHistoryController> _logger;

        public OrderHistoryController(
            IOrderHistoryService orderHistoryService,
            ILogger<OrderHistoryController> logger)
        {
            _orderHistoryService = orderHistoryService;
            _logger = logger;
        }
        /// <summary>
        /// Get order history with optional filtering
        /// </summary>
        /// <param name="filter">Filter parameters for order history</param>
        /// <returns>Filtered list of orders</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<OrderHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<OrderHistoryDto>>>> GetOrderHistory([FromQuery] OrderHistoryFilterRequest filter)
        {
            try
            {
                _logger.LogInformation("Staff retrieving order history with filters");

                // Validate date range if both dates are provided
                if (filter.StartDate.HasValue && filter.EndDate.HasValue)
                {
                    if (filter.StartDate > filter.EndDate)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Bad Request",
                            Message = "Start date cannot be later than end date"
                        });
                    }
                }

                // Validate page number and size
                if (filter.PageNumber < 1)
                {
                    filter.PageNumber = 1;
                }

                if (filter.PageSize < 1)
                {
                    filter.PageSize = 10;
                }

                var result = await _orderHistoryService.GetOrderHistoryAsync(filter);

                return Ok(new ApiResponse<PagedResult<OrderHistoryDto>>
                {
                    Success = true,
                    Message = "Order history retrieved successfully",
                    Data = result
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

        /// <summary>
        /// Get details of a specific order
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <returns>Detailed information about the order</returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(ApiResponse<OrderHistoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<OrderHistoryDto>>> GetOrderDetails(int orderId)
        {
            try
            {
                _logger.LogInformation("Staff retrieving details for order ID: {OrderId}", orderId);

                var order = await _orderHistoryService.GetOrderDetailsAsync(orderId);

                return Ok(new ApiResponse<OrderHistoryDto>
                {
                    Success = true,
                    Message = "Order details retrieved successfully",
                    Data = order
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Order not found with ID: {OrderId}", orderId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order details for ID: {OrderId}", orderId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve order details"
                });
            }
        }

        /// <summary>
        /// Get orders by status
        /// </summary>
        /// <param name="status">The order status to filter by</param>
        /// <param name="pageNumber">Page number for pagination</param>
        /// <param name="pageSize">Page size for pagination</param>
        /// <returns>List of orders with the specified status</returns>
        [HttpGet("status/{status}")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<OrderHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<OrderHistoryDto>>>> GetOrdersByStatus(
            OrderStatus status,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Staff retrieving orders with status: {Status}", status);

                // Validate page number and size
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;

                var result = await _orderHistoryService.GetOrdersByStatusAsync(status, pageNumber, pageSize);

                return Ok(new ApiResponse<PagedResult<OrderHistoryDto>>
                {
                    Success = true,
                    Message = $"Orders with status '{status}' retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders with status: {Status}", status);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve orders by status"
                });
            }
        }

        /// <summary>
        /// Get orders by date range
        /// </summary>
        /// <param name="startDate">Start date for filtering orders</param>
        /// <param name="endDate">End date for filtering orders</param>
        /// <param name="pageNumber">Page number for pagination</param>
        /// <param name="pageSize">Page size for pagination</param>
        /// <returns>List of orders within the specified date range</returns>
        [HttpGet("daterange")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<OrderHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<OrderHistoryDto>>>> GetOrdersByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Staff retrieving orders between {StartDate} and {EndDate}", startDate, endDate);

                // Validate date range
                if (startDate > endDate)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Bad Request",
                        Message = "Start date cannot be later than end date"
                    });
                }

                // Validate page number and size
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;

                var result = await _orderHistoryService.GetOrdersByDateRangeAsync(startDate, endDate, pageNumber, pageSize);

                return Ok(new ApiResponse<PagedResult<OrderHistoryDto>>
                {
                    Success = true,
                    Message = $"Orders between {startDate:yyyy-MM-dd} and {endDate:yyyy-MM-dd} retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders between {StartDate} and {EndDate}", startDate, endDate);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve orders by date range"
                });
            }
        }
    }
}
