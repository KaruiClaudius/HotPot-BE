using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Discount;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customer/discounts")]
    [Authorize] // Allow any authenticated user (customer)
    public class CustomerDiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ILogger<CustomerDiscountController> _logger;

        public CustomerDiscountController(
            IDiscountService discountService,
            ILogger<CustomerDiscountController> logger)
        {
            _discountService = discountService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DiscountDto>>>> GetDiscounts(
            [FromQuery] string searchTerm = null,
            [FromQuery] bool? isActive = true, // Default to active discounts for customers
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "CreatedAt",
            [FromQuery] bool ascending = false)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = "Số trang và kích thước trang phải lớn hơn 0"
                    });
                }

                _logger.LogInformation("Customer retrieving discounts");

                // For customers, we only show active discounts by default
                var pagedDiscounts = await _discountService.GetDiscountsAsync(
                    searchTerm,
                    null, // minDiscountPercentage
                    null, // maxDiscountPercentage
                    null, // minPointCost
                    null, // maxPointCost
                    null, // startDateFrom
                    null, // startDateTo
                    null, // endDateFrom
                    null, // endDateTo
                    isActive, // Only active discounts for customers by default
                    null, // isUpcoming
                    null, // isExpired
                    pageNumber,
                    pageSize,
                    sortBy,
                    ascending);

                // Get all discount IDs from the current page
                var discountIds = pagedDiscounts.Items.Select(d => d.DiscountId).ToList();

                // Get all order counts in a single query
                var orderCounts = await _discountService.GetOrderCountsByDiscountsAsync(discountIds);

                var discountDtos = pagedDiscounts.Items.Select(discount =>
                {
                    var dto = MapToDiscountDto(discount);
                    // Override the OrderCount with the actual count from our bulk query
                    dto.OrderCount = orderCounts.ContainsKey(discount.DiscountId) ?
                        orderCounts[discount.DiscountId] : 0;
                    return dto;
                }).ToList();

                var result = new PagedResult<DiscountDto>
                {
                    Items = discountDtos,
                    PageNumber = pagedDiscounts.PageNumber,
                    PageSize = pagedDiscounts.PageSize,
                    TotalCount = pagedDiscounts.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<DiscountDto>>
                {
                    Success = true,
                    Message = "Lấy danh sách mã giảm giá thành công",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách mã giảm giá");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy danh sách mã giảm giá"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DiscountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DiscountDto>>> GetDiscountById(int id)
        {
            try
            {
                _logger.LogInformation("Customer retrieving discount with ID: {DiscountId}", id);

                var discount = await _discountService.GetByIdAsync(id);

                if (discount == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = $"Không tìm thấy mã giảm giá với ID {id}"
                    });
                }

                // For customers, we might want to check if the discount is active
                var now = DateTime.UtcNow.AddHours(7);
                bool isActive = discount.Date <= now &&
                    (!discount.Duration.HasValue || discount.Duration.Value >= now);

                if (!isActive)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = $"Mã giảm giá với ID {id} không còn hiệu lực"
                    });
                }

                var orderCount = await _discountService.GetOrderCountByDiscountAsync(id);
                var discountDto = MapToDiscountDto(discount);
                discountDto.OrderCount = orderCount;

                return Ok(new ApiResponse<DiscountDto>
                {
                    Success = true,
                    Message = "Lấy mã giảm giá thành công",
                    Data = discountDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy mã giảm giá với ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy mã giảm giá"
                });
            }
        }

        private static DiscountDto MapToDiscountDto(Discount discount)
        {
            if (discount == null) return null;

            var now = DateTime.UtcNow.AddHours(7);

            // Calculate if the discount is active based on the rules:
            // 1. Start date has passed
            // 2. Either Duration is null (never expires) OR Duration is in the future
            bool isActive = discount.Date <= now &&
                (!discount.Duration.HasValue || discount.Duration.Value >= now);

            return new DiscountDto
            {
                DiscountId = discount.DiscountId,
                Title = discount.Title,
                Description = discount.Description,
                DiscountPercentage = discount.DiscountPercentage,
                Date = discount.Date,
                Duration = discount.Duration,
                PointCost = discount.PointCost,
                CreatedAt = discount.CreatedAt,
                UpdatedAt = discount.UpdatedAt,
                IsActive = isActive,
                // Add properties to indicate special cases
                IsNeverExpiring = !discount.Duration.HasValue,
                IsFreeForAll = !discount.PointCost.HasValue || discount.PointCost.Value == 0,
                OrderCount = discount.Orders != null ? 1 : 0
            };
        }
    }
}
