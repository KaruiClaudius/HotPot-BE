using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Discount;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/discounts")]
    [Authorize(Roles = "Admin")]
    public class AdminDiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ILogger<AdminDiscountController> _logger;

        public AdminDiscountController(
            IDiscountService discountService,
            ILogger<AdminDiscountController> logger)
        {
            _discountService = discountService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DiscountDto>>>> GetDiscounts(
        [FromQuery] string searchTerm = null,
        [FromQuery] decimal? minDiscountPercentage = null,
        [FromQuery] decimal? maxDiscountPercentage = null,
        [FromQuery] double? minPointCost = null,
        [FromQuery] double? maxPointCost = null,
        [FromQuery] DateTime? startDateFrom = null,
        [FromQuery] DateTime? startDateTo = null,
        [FromQuery] DateTime? endDateFrom = null,
        [FromQuery] DateTime? endDateTo = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] bool? isUpcoming = null,
        [FromQuery] bool? isExpired = null,
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

                _logger.LogInformation("Admin retrieving discounts with filters");

                var pagedDiscounts = await _discountService.GetDiscountsAsync(
                    searchTerm, minDiscountPercentage, maxDiscountPercentage,
                    minPointCost, maxPointCost, startDateFrom, startDateTo,
                    endDateFrom, endDateTo, isActive, isUpcoming, isExpired,
                    pageNumber, pageSize, sortBy, ascending);

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
                _logger.LogInformation("Admin retrieving discount with ID: {DiscountId}", id);

                var discount = await _discountService.GetByIdAsync(id);

                if (discount == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = $"Không tìm thấy mã giảm giá với ID {id}"
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


        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<DiscountDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<DiscountDto>>> CreateDiscount([FromBody] DiscountRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new discount: {DiscountTitle}", request.Title);

                var discount = new Discount
                {
                    Title = request.Title,
                    Description = request.Description,
                    DiscountPercentage = request.DiscountPercentage,
                    Date = request.Date,
                    Duration = request.Duration, // Now nullable
                    PointCost = request.PointCost // Now nullable
                };

                var createdDiscount = await _discountService.CreateAsync(discount);
                var discountDto = MapToDiscountDto(createdDiscount);
                discountDto.OrderCount = 0; // New discount has no orders

                return CreatedAtAction(
                    nameof(GetDiscountById),
                    new { id = createdDiscount.DiscountId },
                    new ApiResponse<DiscountDto>
                    {
                        Success = true,
                        Message = "Tạo mã giảm giá thành công",
                        Data = discountDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi tạo mã giảm giá: {DiscountTitle}", request.Title);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo mã giảm giá: {DiscountTitle}", request.Title);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể tạo mã giảm giá"
                });

            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DiscountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DiscountDto>>> UpdateDiscount(int id, [FromBody] DiscountUpdateRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating discount with ID: {DiscountId}", id);

                var existingDiscount = await _discountService.GetByIdAsync(id);
                if (existingDiscount == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = $"Không tìm thấy mã giảm giá với ID {id}"
                    });
                }

                // Only update fields that are not null in the request
                if (request.Title != null)
                {
                    existingDiscount.Title = request.Title;
                }

                if (request.Description != null)
                {
                    existingDiscount.Description = request.Description;
                }

                if (request.DiscountPercentage.HasValue)
                {
                    existingDiscount.DiscountPercentage = request.DiscountPercentage.Value;
                }

                if (request.Date.HasValue)
                {
                    existingDiscount.Date = request.Date.Value;
                }

                if (request.UpdateDuration)
                {
                    existingDiscount.Duration = request.Duration;
                }

                if (request.UpdatePointCost)
                {
                    existingDiscount.PointCost = request.PointCost;
                }

                await _discountService.UpdateAsync(id, existingDiscount);

                var orderCount = await _discountService.GetOrderCountByDiscountAsync(id);
                var discountDto = MapToDiscountDto(existingDiscount);
                discountDto.OrderCount = orderCount;

                return Ok(new ApiResponse<DiscountDto>
                {
                    Success = true,
                    Message = "Cập nhật mã giảm giá thành công",
                    Data = discountDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi cập nhật mã giảm giá với ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy mã giảm giá với ID: {DiscountId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật mã giảm giá với ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể cập nhật mã giảm giá"
                });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteDiscount(int id)
        {
            try
            {
                _logger.LogInformation("Quản trị viên xóa mã giảm giá với ID: {DiscountId}", id);

                await _discountService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Xóa mã giảm giá thành công",
                    Data = $"Mã giảm giá với ID {id} đã được xóa"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi xóa mã giảm giá với ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy mã giảm giá với ID: {DiscountId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa mã giảm giá với ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể xóa mã giảm giá"
                });
            }
        }

        [HttpGet("check-points")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> CheckSufficientPoints(
     [FromQuery] int discountId,
     [FromQuery] double userPoints)
        {
            try
            {
                _logger.LogInformation("Quản trị viên kiểm tra điểm của người dùng cho mã giảm giá ID: {DiscountId}, Điểm: {Points}",
                    discountId, userPoints);

                if (userPoints < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = "Điểm của người dùng không được âm"
                    });
                }

                var hasSufficientPoints = await _discountService.HasSufficientPointsAsync(discountId, userPoints);

                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = hasSufficientPoints ?
                        "Người dùng có đủ điểm để áp dụng mã giảm giá này" :
                        "Người dùng k`hông đủ điểm để áp dụng mã giảm giá này",
                    Data = hasSufficientPoints
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy mã giảm giá với ID: {DiscountId}", discountId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi kiểm tra điểm cho mã giảm giá ID: {DiscountId}", discountId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể kiểm tra điểm của người dùng"
                });
            }

        }
        private static DiscountDto MapToDiscountDto(Discount discount)
        {
            if (discount == null) return null;

            var now = DateTime.UtcNow.AddHours(7);

            // Calculate if the discount is active based on the new rules:
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
