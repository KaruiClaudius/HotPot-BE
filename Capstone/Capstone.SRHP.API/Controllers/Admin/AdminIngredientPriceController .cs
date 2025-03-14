using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/ingredient-price")]
    [Authorize(Roles = "Admin")]
    public class AdminIngredientPriceController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<AdminIngredientPriceController> _logger;

        public AdminIngredientPriceController(
            IIngredientService ingredientService,
            ILogger<AdminIngredientPriceController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        [HttpGet("ingredient/{ingredientId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<IngredientPriceDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientPriceDto>>>> GetIngredientPriceHistory(int ingredientId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving price history for ingredient with ID: {IngredientId}", ingredientId);

                var ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);
                if (ingredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {ingredientId} not found"
                    });
                }

                var priceHistory = await _ingredientService.GetPriceHistoryAsync(ingredientId);
                var priceDtos = priceHistory.Select(price => new IngredientPriceDto
                {
                    IngredientPriceId = price.IngredientPriceId,
                    Price = price.Price,
                    EffectiveDate = price.EffectiveDate,
                    IngredientID = price.IngredientID,
                    IngredientName = price.Ingredient?.Name ?? "Unknown"
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<IngredientPriceDto>>
                {
                    Success = true,
                    Message = "Ingredient price history retrieved successfully",
                    Data = priceDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving price history for ingredient with ID: {IngredientId}", ingredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient price history"
                });
            }
        }

        [HttpPost("ingredient/{ingredientId}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientPriceDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IngredientPriceDto>>> AddIngredientPrice(
            int ingredientId,
            [FromBody] IngredientPriceRequest request)
        {
            try
            {
                _logger.LogInformation("Admin adding new price for ingredient with ID: {IngredientId}", ingredientId);

                var ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);
                if (ingredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {ingredientId} not found"
                    });
                }

                var createdPrice = await _ingredientService.AddPriceAsync(
                    ingredientId,
                    request.Price,
                    request.EffectiveDate);

                var priceDto = new IngredientPriceDto
                {
                    IngredientPriceId = createdPrice.IngredientPriceId,
                    Price = createdPrice.Price,
                    EffectiveDate = createdPrice.EffectiveDate,
                    IngredientID = createdPrice.IngredientID,
                    IngredientName = ingredient.Name
                };

                return CreatedAtAction(
                    nameof(GetIngredientPriceHistory),
                    new { ingredientId = ingredientId },
                    new ApiResponse<IngredientPriceDto>
                    {
                        Success = true,
                        Message = "Ingredient price added successfully",
                        Data = priceDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error adding price for ingredient with ID: {IngredientId}", ingredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", ingredientId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding price for ingredient with ID: {IngredientId}", ingredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to add ingredient price"
                });
            }
        }

        [HttpGet("current/{ingredientId}")]
        [ProducesResponseType(typeof(ApiResponse<decimal>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<decimal>>> GetCurrentPrice(int ingredientId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving current price for ingredient with ID: {IngredientId}", ingredientId);

                var currentPrice = await _ingredientService.GetCurrentPriceAsync(ingredientId);

                return Ok(new ApiResponse<decimal>
                {
                    Success = true,
                    Message = "Current price retrieved successfully",
                    Data = currentPrice
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "No price found for ingredient with ID: {IngredientId}", ingredientId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving current price for ingredient with ID: {IngredientId}", ingredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve current price"
                });
            }
        }
    }
}
