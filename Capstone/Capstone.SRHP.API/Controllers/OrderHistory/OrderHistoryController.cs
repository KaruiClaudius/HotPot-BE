using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.OrderHistory
{
    [Route("api/order-history")]
    [ApiController]
    [Authorize(Roles = "Manager,Admin")]

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

    }
}
