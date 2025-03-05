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

        public AdminDiscountController(IDiscountService discountService, ILogger<AdminDiscountController> logger)
        {
            _discountService = discountService;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DiscountDto>>>> GetAllDiscounts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
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

                _logger.LogInformation($"Admin retrieving discounts - Page {pageNumber}, Size {pageSize}");

                var pagedDiscounts = await _discountService.GetPagedAsync(pageNumber, pageSize);

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
                    Message = "Discounts retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving discounts");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve discounts"
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
                        Status = "Error",
                        Message = $"Discount with ID {id} not found"
                    });
                }

                var orderCount = await _discountService.GetOrderCountByDiscountAsync(id);
                var discountDto = MapToDiscountDto(discount);
                discountDto.OrderCount = orderCount;

                return Ok(new ApiResponse<DiscountDto>
                {
                    Success = true,
                    Message = "Discount retrieved successfully",
                    Data = discountDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving discount with ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve discount"
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
                    Duration = request.Duration,
                    PointCost = request.PointCost
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
                        Message = "Discount created successfully",
                        Data = discountDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating discount: {DiscountTitle}", request.Title);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating discount: {DiscountTitle}", request.Title);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create discount"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DiscountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DiscountDto>>> UpdateDiscount(int id, [FromBody] DiscountRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating discount with ID: {DiscountId}", id);

                var existingDiscount = await _discountService.GetByIdAsync(id);
                if (existingDiscount == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Discount with ID {id} not found"
                    });
                }

                existingDiscount.Title = request.Title;
                existingDiscount.Description = request.Description;
                existingDiscount.DiscountPercentage = request.DiscountPercentage;
                existingDiscount.Date = request.Date;
                existingDiscount.Duration = request.Duration;
                existingDiscount.PointCost = request.PointCost;

                await _discountService.UpdateAsync(id, existingDiscount);

                var orderCount = await _discountService.GetOrderCountByDiscountAsync(id);
                var discountDto = MapToDiscountDto(existingDiscount);
                discountDto.OrderCount = orderCount;

                return Ok(new ApiResponse<DiscountDto>
                {
                    Success = true,
                    Message = "Discount updated successfully",
                    Data = discountDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating discount with ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Discount not found with ID: {DiscountId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating discount with ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update discount"
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
                _logger.LogInformation("Admin deleting discount with ID: {DiscountId}", id);

                await _discountService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Discount deleted successfully",
                    Data = $"Discount with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting discount with ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Discount not found with ID: {DiscountId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting discount with ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete discount"
                });
            }
        }

        [HttpGet("active")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DiscountDto>>>> GetActiveDiscounts()
        {
            try
            {
                _logger.LogInformation("Admin retrieving active discounts");

                var activeDiscounts = await _discountService.GetActiveDiscountsAsync();
                var discountIds = activeDiscounts.Select(d => d.DiscountId).ToList();
                var orderCounts = await _discountService.GetOrderCountsByDiscountsAsync(discountIds);

                var discountDtos = activeDiscounts.Select(discount =>
                {
                    var dto = MapToDiscountDto(discount);
                    dto.OrderCount = orderCounts.ContainsKey(discount.DiscountId) ?
                        orderCounts[discount.DiscountId] : 0;
                    return dto;
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<DiscountDto>>
                {
                    Success = true,
                    Message = "Active discounts retrieved successfully",
                    Data = discountDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving active discounts");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve active discounts"
                });
            }
        }
        [HttpGet("upcoming")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DiscountDto>>>> GetUpcomingDiscounts()
        {
            try
            {
                _logger.LogInformation("Admin retrieving upcoming discounts");

                var upcomingDiscounts = await _discountService.GetUpcomingDiscountsAsync();
                var discountIds = upcomingDiscounts.Select(d => d.DiscountId).ToList();
                var orderCounts = await _discountService.GetOrderCountsByDiscountsAsync(discountIds);

                var discountDtos = upcomingDiscounts.Select(discount =>
                {
                    var dto = MapToDiscountDto(discount);
                    dto.OrderCount = orderCounts.ContainsKey(discount.DiscountId) ?
                        orderCounts[discount.DiscountId] : 0;
                    return dto;
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<DiscountDto>>
                {
                    Success = true,
                    Message = "Upcoming discounts retrieved successfully",
                    Data = discountDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving upcoming discounts");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve upcoming discounts"
                });
            }
        }

        [HttpGet("expired")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DiscountDto>>>> GetExpiredDiscounts()
        {
            try
            {
                _logger.LogInformation("Admin retrieving expired discounts");

                var expiredDiscounts = await _discountService.GetExpiredDiscountsAsync();
                var discountIds = expiredDiscounts.Select(d => d.DiscountId).ToList();
                var orderCounts = await _discountService.GetOrderCountsByDiscountsAsync(discountIds);

                var discountDtos = expiredDiscounts.Select(discount =>
                {
                    var dto = MapToDiscountDto(discount);
                    dto.OrderCount = orderCounts.ContainsKey(discount.DiscountId) ?
                        orderCounts[discount.DiscountId] : 0;
                    return dto;
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<DiscountDto>>
                {
                    Success = true,
                    Message = "Expired discounts retrieved successfully",
                    Data = discountDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving expired discounts");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve expired discounts"
                });
            }
        }

        [HttpGet("validate/{id}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<bool>>> ValidateDiscount(int id)
        {
            try
            {
                _logger.LogInformation("Admin validating discount with ID: {DiscountId}", id);

                var discount = await _discountService.GetByIdAsync(id);
                if (discount == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Discount with ID {id} not found"
                    });
                }

                var isValid = await _discountService.IsDiscountValidAsync(id);

                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = isValid ?
                        "Discount is valid and can be used" :
                        "Discount is not valid (expired, not started yet, or already in use)",
                    Data = isValid
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating discount with ID: {DiscountId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to validate discount"
                });
            }
        }

        [HttpGet("calculate")]
        [ProducesResponseType(typeof(ApiResponse<decimal>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<decimal>>> CalculateDiscountAmount(
            [FromQuery] int discountId,
            [FromQuery] decimal originalPrice)
        {
            try
            {
                _logger.LogInformation("Admin calculating discount amount for discount ID: {DiscountId} and price: {Price}",
                    discountId, originalPrice);

                if (originalPrice < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Original price cannot be negative"
                    });
                }

                var discountAmount = await _discountService.CalculateDiscountAmountAsync(discountId, originalPrice);

                return Ok(new ApiResponse<decimal>
                {
                    Success = true,
                    Message = "Discount amount calculated successfully",
                    Data = discountAmount
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Discount not found with ID: {DiscountId}", discountId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error calculating discount amount for discount ID: {DiscountId}", discountId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating discount amount for discount ID: {DiscountId}", discountId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to calculate discount amount"
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
                _logger.LogInformation("Admin checking if user has sufficient points for discount ID: {DiscountId}, Points: {Points}",
                    discountId, userPoints);

                if (userPoints < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "User points cannot be negative"
                    });
                }

                var hasSufficientPoints = await _discountService.HasSufficientPointsAsync(discountId, userPoints);

                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = hasSufficientPoints ?
                        "User has sufficient points for this discount" :
                        "User does not have sufficient points for this discount",
                    Data = hasSufficientPoints
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Discount not found with ID: {DiscountId}", discountId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking points for discount ID: {DiscountId}", discountId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to check if user has sufficient points"
                });
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DiscountDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DiscountDto>>>> SearchDiscounts(
            [FromQuery] string searchTerm,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
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

                _logger.LogInformation($"Admin searching discounts with term: {searchTerm} - Page {pageNumber}, Size {pageSize}");

                // Implement search functionality in your service
                var pagedDiscounts = await _discountService.SearchAsync(searchTerm, pageNumber, pageSize);

                var discountIds = pagedDiscounts.Items.Select(d => d.DiscountId).ToList();
                var orderCounts = await _discountService.GetOrderCountsByDiscountsAsync(discountIds);

                var discountDtos = pagedDiscounts.Items.Select(discount =>
                {
                    var dto = MapToDiscountDto(discount);
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
                    Message = "Discounts search completed successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching discounts with term: {SearchTerm}", searchTerm);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to search discounts"
                });
            }
        }

        private static DiscountDto MapToDiscountDto(Discount discount)
        {
            if (discount == null) return null;

            var now = DateTime.UtcNow;
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
                IsActive = discount.Date <= now && discount.Duration >= now,
                OrderCount = discount.Order != null ? 1 : 0
            };
        }
    }
}
