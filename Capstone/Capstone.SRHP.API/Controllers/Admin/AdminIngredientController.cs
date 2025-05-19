using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Extensions;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/ingredients")]
    [Authorize(Roles = "Admin")]
    public class AdminIngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<AdminIngredientController> _logger;

        public AdminIngredientController(
            IIngredientService ingredientService,
            ILogger<AdminIngredientController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<IngredientDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<IngredientDto>>>> GetAllIngredients(
            [FromQuery] string searchTerm = null,
            [FromQuery] int? typeId = null,
            [FromQuery] bool? isLowStock = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] string sortBy = "Name",
            [FromQuery] bool ascending = true)
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

                _logger.LogInformation("Admin retrieving ingredients with filters");

                var pagedIngredients = await _ingredientService.GetIngredientsAsync(
                    searchTerm, typeId, isLowStock, minPrice, maxPrice, pageNumber, pageSize, sortBy, ascending);

                // Get all ingredient IDs from the current page
                var ingredientIds = pagedIngredients.Items.Select(i => i.IngredientId).ToList();

                // Get all current prices in a single query
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = pagedIngredients.Items.Select(ingredient =>
                {
                    var dto = MapToIngredientDto(ingredient);
                    // Override the Price with the actual price from our bulk query
                    if (currentPrices.ContainsKey(ingredient.IngredientId))
                    {
                        dto.Price = currentPrices[ingredient.IngredientId];
                    }
                    return dto;
                }).ToList();

                var result = new PagedResult<IngredientDto>
                {
                    Items = ingredientDtos,
                    PageNumber = pagedIngredients.PageNumber,
                    PageSize = pagedIngredients.PageSize,
                    TotalCount = pagedIngredients.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<IngredientDto>>
                {
                    Success = true,
                    Message = "Ingredients retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredients"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientDetailDto>>> GetIngredientById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving ingredient with ID: {IngredientId}", id);

                var ingredient = await _ingredientService.GetIngredientByIdAsync(id);

                if (ingredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                // Get current price
                var currentPrice = await _ingredientService.GetCurrentPriceAsync(id);

                // Get batches for this ingredient
                var batches = await _ingredientService.GetIngredientBatchesAsync(id);

                // Map to detailed DTO including batches
                var ingredientDetailDto = await MapToIngredientDetailDto(ingredient, batches);
                ingredientDetailDto.Price = currentPrice;

                return Ok(new ApiResponse<IngredientDetailDto>
                {
                    Success = true,
                    Message = "Ingredient retrieved successfully",
                    Data = ingredientDetailDto
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<IngredientDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IngredientDto>>> CreateIngredient([FromBody] CreateIngredientRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new ingredient: {IngredientName}", request.Name);

                // Validate request
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Ingredient name cannot be empty"
                    });
                }

                if (request.MinStockLevel < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Minimum stock level cannot be negative"
                    });
                }

                if (request.Price < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Price cannot be negative"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.Unit))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Unit cannot be empty"
                    });
                }

                if (request.MeasurementValue <= 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Measurement value must be greater than 0"
                    });
                }

                // Create ingredient entity
                var ingredient = new Ingredient
                {
                    Name = request.Name,
                    Description = request.Description,
                    ImageURL = request.ImageURL,
                    MinStockLevel = request.MinStockLevel,
                    IngredientTypeId = request.IngredientTypeID,
                    Unit = request.Unit,
                    MeasurementValue = request.MeasurementValue
                };

                // Create ingredient with initial price
                var createdIngredient = await _ingredientService.CreateIngredientAsync(ingredient, request.Price);


                // Map to DTO
                var ingredientDto = MapToIngredientDto(createdIngredient);
                ingredientDto.Price = request.Price;


                return CreatedAtAction(
                    nameof(GetIngredientById),
                    new { id = createdIngredient.IngredientId },
                    new ApiResponse<IngredientDto>
                    {
                        Success = true,
                        Message = "Ingredient created successfully.",
                        Data = ingredientDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating ingredient: {IngredientName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ingredient: {IngredientName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create ingredient"
                });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientDto>>> UpdateIngredient(int id, [FromBody] UpdateIngredientRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating ingredient with ID: {IngredientId}", id);

                // Get existing ingredient
                var existingIngredient = await _ingredientService.GetIngredientByIdAsync(id);
                if (existingIngredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                // Validate request
                if (request.MinStockLevel.HasValue && request.MinStockLevel.Value < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Minimum stock level cannot be negative"
                    });
                }

                if (request.Price.HasValue && request.Price.Value < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Price cannot be negative"
                    });
                }

                if (request.MeasurementValue.HasValue && request.MeasurementValue.Value <= 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Measurement value must be greater than 0"
                    });
                }

                // Update properties that are provided in the request
                if (!string.IsNullOrEmpty(request.Name))
                    existingIngredient.Name = request.Name;

                if (!string.IsNullOrEmpty(request.Description))
                    existingIngredient.Description = request.Description;

                if (!string.IsNullOrEmpty(request.ImageURL))
                    existingIngredient.ImageURL = request.ImageURL;

                if (!string.IsNullOrEmpty(request.Unit))
                    existingIngredient.Unit = request.Unit;

                if (request.MeasurementValue.HasValue)
                    existingIngredient.MeasurementValue = request.MeasurementValue.Value;

                if (request.MinStockLevel.HasValue)
                    existingIngredient.MinStockLevel = request.MinStockLevel.Value;

                if (request.IngredientTypeID.HasValue && request.IngredientTypeID > 0)
                    existingIngredient.IngredientTypeId = request.IngredientTypeID.Value;

                // Update ingredient
                await _ingredientService.UpdateIngredientAsync(id, existingIngredient);

                // Add new price if it's provided and different from current price
                if (request.Price.HasValue)
                {
                    try
                    {
                        var currentPrice = await _ingredientService.GetCurrentPriceAsync(id);
                        if (currentPrice != request.Price.Value)
                        {
                            await _ingredientService.AddPriceAsync(id, request.Price.Value, DateTime.UtcNow.AddHours(7));
                        }
                    }
                    catch (NotFoundException)
                    {
                        // No current price found, add the new price
                        await _ingredientService.AddPriceAsync(id, request.Price.Value, DateTime.UtcNow.AddHours(7));
                    }
                }

                // Get updated ingredient
                var updatedIngredient = await _ingredientService.GetIngredientByIdAsync(id);
                var ingredientDto = MapToIngredientDto(updatedIngredient);

                // Set price in DTO if provided in request, otherwise get current price
                if (request.Price.HasValue)
                {
                    ingredientDto.Price = request.Price.Value;
                }
                else
                {
                    try
                    {
                        ingredientDto.Price = await _ingredientService.GetCurrentPriceAsync(id);
                    }
                    catch (NotFoundException)
                    {
                        // No price found, leave as 0
                    }
                }

                return Ok(new ApiResponse<IngredientDto>
                {
                    Success = true,
                    Message = "Ingredient updated successfully",
                    Data = ingredientDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update ingredient"
                });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteIngredient(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting ingredient with ID: {IngredientId}", id);

                await _ingredientService.DeleteIngredientAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Ingredient deleted successfully",
                    Data = $"Ingredient with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete ingredient"
                });
            }
        }

        [HttpGet("low-stock")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<IngredientDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientDto>>>> GetLowStockIngredients()
        {
            try
            {
                _logger.LogInformation("Admin retrieving low stock ingredients");

                var lowStockIngredients = await _ingredientService.GetLowStockIngredientsAsync();
                var ingredientIds = lowStockIngredients.Select(i => i.IngredientId).ToList();
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = lowStockIngredients.Select(ingredient =>
                {
                    var dto = MapToIngredientDto(ingredient);
                    if (currentPrices.ContainsKey(ingredient.IngredientId))
                    {
                        dto.Price = currentPrices[ingredient.IngredientId];
                    }
                    return dto;
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<IngredientDto>>
                {
                    Success = true,
                    Message = "Low stock ingredients retrieved successfully",
                    Data = ingredientDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving low stock ingredients");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve low stock ingredients"
                });
            }
        }


        private static IngredientDto MapToIngredientDto(Ingredient ingredient)
        {
            if (ingredient == null) return null;

            return new IngredientDto
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name,
                Description = ingredient.Description ?? string.Empty,
                ImageURL = ingredient.ImageURL ?? string.Empty,
                MinStockLevel = ingredient.MinStockLevel,
                Quantity = ingredient.Quantity,
                Unit = ingredient.Unit,
                MeasurementValue = ingredient.MeasurementValue != 0 ? ingredient.MeasurementValue : 1.0, // Default to 1.0 if zero
                IngredientTypeID = ingredient.IngredientTypeId,
                IngredientTypeName = ingredient.IngredientType?.Name ?? "Unknown",
                Price = 0, // This will be set later from the current price
                CreatedAt = ingredient.CreatedAt,
                UpdatedAt = ingredient.UpdatedAt,
                IsLowStock = ingredient.Quantity <= ingredient.MinStockLevel
            };
        }

        private async Task<IngredientDetailDto> MapToIngredientDetailDto(Ingredient ingredient, IEnumerable<IngredientBatch> batches)
        {
            if (ingredient == null) return null;

            // First map the base ingredient properties
            var detailDto = new IngredientDetailDto
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name,
                Description = ingredient.Description ?? string.Empty,
                ImageURL = ingredient.ImageURL ?? string.Empty,
                MinStockLevel = ingredient.MinStockLevel,
                Quantity = ingredient.Quantity,
                Unit = ingredient.Unit,
                MeasurementValue = ingredient.MeasurementValue != 0 ? ingredient.MeasurementValue : 1.0, // Default to 1.0 if zero
                IngredientTypeID = ingredient.IngredientTypeId,
                IngredientTypeName = ingredient.IngredientType?.Name ?? "Unknown",
                Price = 0, // This will be set later from the current price
                CreatedAt = ingredient.CreatedAt,
                UpdatedAt = ingredient.UpdatedAt,
                IsLowStock = ingredient.Quantity <= ingredient.MinStockLevel
            };

            // Map batches
            if (batches != null)
            {
                detailDto.Batches = batches.Select(b => new IngredientBatchDto
                {
                    IngredientBatchId = b.IngredientBatchId,
                    IngredientId = b.IngredientId,
                    IngredientName = ingredient.Name,
                    InitialQuantity = b.InitialQuantity,
                    RemainingQuantity = b.RemainingQuantity,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = b.BestBeforeDate,
                    BatchNumber = b.BatchNumber ?? string.Empty,
                    ReceivedDate = b.ReceivedDate
                }).ToList();
            }

            return detailDto;
        }
    }
}