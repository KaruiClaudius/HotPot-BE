using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
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
        private readonly IIngredientTypeService _ingredientTypeService;
        private readonly ILogger<AdminIngredientController> _logger;

        public AdminIngredientController(
            IIngredientService ingredientService,
            IIngredientTypeService ingredientTypeService,
            ILogger<AdminIngredientController> logger)
        {
            _ingredientService = ingredientService;
            _ingredientTypeService = ingredientTypeService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<IngredientDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<IngredientDto>>>> GetAllIngredients(
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

                _logger.LogInformation($"Admin retrieving ingredients - Page {pageNumber}, Size {pageSize}");

                var pagedIngredients = await _ingredientService.GetPagedAsync(pageNumber, pageSize);

                // Get all ingredient IDs from the current page
                var ingredientIds = pagedIngredients.Items.Select(i => i.IngredientId).ToList();

                // Get all current prices in a single query
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = pagedIngredients.Items.Select(ingredient =>
                {
                    var dto = MapToIngredientDto(ingredient);
                    // Override the CurrentPrice with the actual price from our bulk query
                    if (currentPrices.ContainsKey(ingredient.IngredientId))
                    {
                        dto.CurrentPrice = currentPrices[ingredient.IngredientId];
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
        [ProducesResponseType(typeof(ApiResponse<IngredientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientDto>>> GetIngredientById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving ingredient with ID: {IngredientId}", id);

                var ingredient = await _ingredientService.GetByIdAsync(id);

                if (ingredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                var currentPrice = await _ingredientService.GetCurrentPriceAsync(id);
                var ingredientDto = MapToIngredientDto(ingredient);
                ingredientDto.CurrentPrice = currentPrice;

                return Ok(new ApiResponse<IngredientDto>
                {
                    Success = true,
                    Message = "Ingredient retrieved successfully",
                    Data = ingredientDto
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
        public async Task<ActionResult<ApiResponse<IngredientDto>>> CreateIngredient([FromBody] IngredientRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new ingredient: {IngredientName}", request.Name);

                var ingredient = new Ingredient
                {
                    Name = request.Name,
                    Description = request.Description,
                    ImageURL = request.ImageURL,
                    MinStockLevel = request.MinStockLevel,
                    Quantity = request.Quantity,
                    IngredientTypeID = request.IngredientTypeID
                };

                var createdIngredient = await _ingredientService.CreateAsync(ingredient, request.Price);
                var ingredientDto = MapToIngredientDto(createdIngredient);
                ingredientDto.CurrentPrice = request.Price;

                return CreatedAtAction(
                    nameof(GetIngredientById),
                    new { id = createdIngredient.IngredientId },
                    new ApiResponse<IngredientDto>
                    {
                        Success = true,
                        Message = "Ingredient created successfully",
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
        public async Task<ActionResult<ApiResponse<IngredientDto>>> UpdateIngredient(int id, [FromBody] IngredientRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating ingredient with ID: {IngredientId}", id);

                var existingIngredient = await _ingredientService.GetByIdAsync(id);
                if (existingIngredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                existingIngredient.Name = request.Name;
                existingIngredient.Description = request.Description;
                existingIngredient.ImageURL = request.ImageURL;
                existingIngredient.MinStockLevel = request.MinStockLevel;
                existingIngredient.Quantity = request.Quantity;
                existingIngredient.IngredientTypeID = request.IngredientTypeID;

                await _ingredientService.UpdateAsync(id, existingIngredient);

                // Add new price if it's different from current price
                var currentPrice = await _ingredientService.GetCurrentPriceAsync(id);
                if (currentPrice != request.Price)
                {
                    var newPrice = new IngredientPrice
                    {
                        IngredientID = id,
                        Price = request.Price,
                        EffectiveDate = DateTime.UtcNow
                    };

                    await _ingredientService.AddPriceAsync(newPrice);
                }

                var updatedIngredient = await _ingredientService.GetByIdAsync(id);
                var ingredientDto = MapToIngredientDto(updatedIngredient);
                ingredientDto.CurrentPrice = request.Price;

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

                await _ingredientService.DeleteAsync(id);

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
                        dto.CurrentPrice = currentPrices[ingredient.IngredientId];
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

        [HttpGet("by-type/{typeId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<IngredientDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientDto>>>> GetIngredientsByType(int typeId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving ingredients by type ID: {TypeId}", typeId);

                var ingredients = await _ingredientService.GetByTypeAsync(typeId);
                var ingredientIds = ingredients.Select(i => i.IngredientId).ToList();
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = ingredients.Select(ingredient =>
                {
                    var dto = MapToIngredientDto(ingredient);
                    if (currentPrices.ContainsKey(ingredient.IngredientId))
                    {
                        dto.CurrentPrice = currentPrices[ingredient.IngredientId];
                    }
                    return dto;
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<IngredientDto>>
                {
                    Success = true,
                    Message = "Ingredients by type retrieved successfully",
                    Data = ingredientDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients by type ID: {TypeId}", typeId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredients by type"
                });
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<IngredientDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<IngredientDto>>>> SearchIngredients(
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

                _logger.LogInformation($"Admin searching ingredients with term: {searchTerm} - Page {pageNumber}, Size {pageSize}");

                var pagedIngredients = await _ingredientService.SearchAsync(searchTerm, pageNumber, pageSize);

                var ingredientIds = pagedIngredients.Items.Select(i => i.IngredientId).ToList();
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = pagedIngredients.Items.Select(ingredient =>
                {
                    var dto = MapToIngredientDto(ingredient);
                    if (currentPrices.ContainsKey(ingredient.IngredientId))
                    {
                        dto.CurrentPrice = currentPrices[ingredient.IngredientId];
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
                    Message = "Ingredients search completed successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching ingredients with term: {SearchTerm}", searchTerm);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to search ingredients"
                });
            }
        }

        [HttpGet("{id}/price-history")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<IngredientPriceDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientPriceDto>>>> GetIngredientPriceHistory(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving price history for ingredient with ID: {IngredientId}", id);

                var ingredient = await _ingredientService.GetByIdAsync(id);
                if (ingredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                var priceHistory = await _ingredientService.GetPriceHistoryAsync(id);
                var priceDtos = priceHistory.Select(price => new IngredientPriceDto
                {
                    IngredientPriceId = price.IngredientPriceId,
                    Price = price.Price,
                    EffectiveDate = price.EffectiveDate,
                    IngredientID = price.IngredientID,
                    IngredientName = price.Ingredient?.Name ?? "Unknown",
                    CreatedAt = price.CreatedAt,
                    UpdatedAt = price.UpdatedAt
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
                _logger.LogError(ex, "Error retrieving price history for ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient price history"
                });
            }
        }

        [HttpPost("{id}/prices")]
        [ProducesResponseType(typeof(ApiResponse<IngredientPriceDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IngredientPriceDto>>> AddIngredientPrice(int id, [FromBody] IngredientPriceRequest request)
        {
            try
            {
                _logger.LogInformation("Admin adding new price for ingredient with ID: {IngredientId}", id);

                // Override the ingredient ID from the route
                request.IngredientID = id;

                var ingredient = await _ingredientService.GetByIdAsync(id);
                if (ingredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                var price = new IngredientPrice
                {
                    IngredientID = id,
                    Price = request.Price,
                    EffectiveDate = request.EffectiveDate
                };

                var createdPrice = await _ingredientService.AddPriceAsync(price);

                var priceDto = new IngredientPriceDto
                {
                    IngredientPriceId = createdPrice.IngredientPriceId,
                    Price = createdPrice.Price,
                    EffectiveDate = createdPrice.EffectiveDate,
                    IngredientID = createdPrice.IngredientID,
                    IngredientName = ingredient.Name,
                    CreatedAt = createdPrice.CreatedAt,
                    UpdatedAt = createdPrice.UpdatedAt
                };

                return CreatedAtAction(
                    nameof(GetIngredientPriceHistory),
                    new { id = id },
                    new ApiResponse<IngredientPriceDto>
                    {
                        Success = true,
                        Message = "Ingredient price added successfully",
                        Data = priceDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error adding price for ingredient with ID: {IngredientId}", id);
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
                _logger.LogError(ex, "Error adding price for ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to add ingredient price"
                });
            }
        }

        [HttpPut("update-stock/{id}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientDto>>> UpdateIngredientStock(
            int id,
            [FromBody] int quantity)
        {
            try
            {
                _logger.LogInformation("Admin updating stock for ingredient with ID: {IngredientId} to {Quantity}", id, quantity);

                if (quantity < 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Quantity cannot be negative"
                    });
                }

                var existingIngredient = await _ingredientService.GetByIdAsync(id);
                if (existingIngredient == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient with ID {id} not found"
                    });
                }

                existingIngredient.Quantity = quantity;
                await _ingredientService.UpdateAsync(id, existingIngredient);

                var currentPrice = await _ingredientService.GetCurrentPriceAsync(id);
                var ingredientDto = MapToIngredientDto(existingIngredient);
                ingredientDto.CurrentPrice = currentPrice;

                return Ok(new ApiResponse<IngredientDto>
                {
                    Success = true,
                    Message = "Ingredient stock updated successfully",
                    Data = ingredientDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating stock for ingredient with ID: {IngredientId}", id);
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
                _logger.LogError(ex, "Error updating stock for ingredient with ID: {IngredientId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update ingredient stock"
                });
            }
        }

        // Helper method to map Ingredient to IngredientDto
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
                IngredientTypeID = ingredient.IngredientTypeID,
                IngredientTypeName = ingredient.IngredientType?.Name ?? "Unknown",
                CurrentPrice = 0, // This will be set by the caller
                CreatedAt = ingredient.CreatedAt,
                UpdatedAt = ingredient.UpdatedAt,
                IsLowStock = ingredient.Quantity <= ingredient.MinStockLevel
            };
        }
    }
}