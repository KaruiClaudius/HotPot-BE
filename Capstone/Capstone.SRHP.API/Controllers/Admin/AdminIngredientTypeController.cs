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
    [Route("api/admin/ingredient-types")]
    [Authorize(Roles = "Admin")]
    public class AdminIngredientTypeController : ControllerBase
    {
        private readonly IIngredientTypeService _ingredientTypeService;
        private readonly ILogger<AdminIngredientTypeController> _logger;

        public AdminIngredientTypeController(
            IIngredientTypeService ingredientTypeService,
            ILogger<AdminIngredientTypeController> logger)
        {
            _ingredientTypeService = ingredientTypeService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<IngredientTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<IngredientTypeDto>>>> GetAllIngredientTypes(
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

                _logger.LogInformation($"Admin retrieving ingredient types - Page {pageNumber}, Size {pageSize}");

                var pagedTypes = await _ingredientTypeService.GetPagedAsync(pageNumber, pageSize);

                // Get all type IDs from the current page
                var typeIds = pagedTypes.Items.Select(t => t.IngredientTypeId).ToList();

                // Get all ingredient counts in a single query
                var ingredientCounts = await _ingredientTypeService.GetIngredientCountsByTypesAsync(typeIds);

                var typeDtos = pagedTypes.Items.Select(type =>
                {
                    var dto = MapToIngredientTypeDto(type);
                    // Override the IngredientCount with the actual count from our bulk query
                    dto.IngredientCount = ingredientCounts.ContainsKey(type.IngredientTypeId) ?
                        ingredientCounts[type.IngredientTypeId] : 0;
                    return dto;
                }).ToList();

                var result = new PagedResult<IngredientTypeDto>
                {
                    Items = typeDtos,
                    PageNumber = pagedTypes.PageNumber,
                    PageSize = pagedTypes.PageSize,
                    TotalCount = pagedTypes.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<IngredientTypeDto>>
                {
                    Success = true,
                    Message = "Ingredient types retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient types");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient types"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientTypeDto>>> GetIngredientTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving ingredient type with ID: {TypeId}", id);

                var type = await _ingredientTypeService.GetByIdAsync(id);

                if (type == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient type with ID {id} not found"
                    });
                }

                var ingredientCount = await _ingredientTypeService.GetIngredientCountByTypeAsync(id);
                var typeDto = MapToIngredientTypeDto(type);
                typeDto.IngredientCount = ingredientCount;

                return Ok(new ApiResponse<IngredientTypeDto>
                {
                    Success = true,
                    Message = "Ingredient type retrieved successfully",
                    Data = typeDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient type"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<IngredientTypeDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IngredientTypeDto>>> CreateIngredientType([FromBody] IngredientTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new ingredient type: {TypeName}", request.Name);

                var type = new IngredientType
                {
                    Name = request.Name
                };

                var createdType = await _ingredientTypeService.CreateAsync(type);
                var typeDto = MapToIngredientTypeDto(createdType);
                typeDto.IngredientCount = 0; // New type has no ingredients

                return CreatedAtAction(
                    nameof(GetIngredientTypeById),
                    new { id = createdType.IngredientTypeId },
                    new ApiResponse<IngredientTypeDto>
                    {
                        Success = true,
                        Message = "Ingredient type created successfully",
                        Data = typeDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating ingredient type: {TypeName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ingredient type: {TypeName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create ingredient type"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientTypeDto>>> UpdateIngredientType(int id, [FromBody] IngredientTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating ingredient type with ID: {TypeId}", id);

                var existingType = await _ingredientTypeService.GetByIdAsync(id);
                if (existingType == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Ingredient type with ID {id} not found"
                    });
                }

                existingType.Name = request.Name;

                await _ingredientTypeService.UpdateAsync(id, existingType);

                var ingredientCount = await _ingredientTypeService.GetIngredientCountByTypeAsync(id);
                var typeDto = MapToIngredientTypeDto(existingType);
                typeDto.IngredientCount = ingredientCount;

                return Ok(new ApiResponse<IngredientTypeDto>
                {
                    Success = true,
                    Message = "Ingredient type updated successfully",
                    Data = typeDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating ingredient type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient type not found with ID: {TypeId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update ingredient type"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteIngredientType(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting ingredient type with ID: {TypeId}", id);

                await _ingredientTypeService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Ingredient type deleted successfully",
                    Data = $"Ingredient type with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting ingredient type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient type not found with ID: {TypeId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting ingredient type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete ingredient type"
                });
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<IngredientTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<IngredientTypeDto>>>> SearchIngredientTypes(
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

                _logger.LogInformation($"Admin searching ingredient types with term: {searchTerm} - Page {pageNumber}, Size {pageSize}");

                var pagedTypes = await _ingredientTypeService.SearchAsync(searchTerm, pageNumber, pageSize);

                var typeIds = pagedTypes.Items.Select(t => t.IngredientTypeId).ToList();
                var ingredientCounts = await _ingredientTypeService.GetIngredientCountsByTypesAsync(typeIds);

                var typeDtos = pagedTypes.Items.Select(type =>
                {
                    var dto = MapToIngredientTypeDto(type);
                    dto.IngredientCount = ingredientCounts.ContainsKey(type.IngredientTypeId) ?
                        ingredientCounts[type.IngredientTypeId] : 0;
                    return dto;
                }).ToList();

                var result = new PagedResult<IngredientTypeDto>
                {
                    Items = typeDtos,
                    PageNumber = pagedTypes.PageNumber,
                    PageSize = pagedTypes.PageSize,
                    TotalCount = pagedTypes.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<IngredientTypeDto>>
                {
                    Success = true,
                    Message = "Ingredient types search completed successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching ingredient types with term: {SearchTerm}", searchTerm);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to search ingredient types"
                });
            }
        }

        [HttpGet("with-ingredients")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<IngredientTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientTypeDto>>>> GetTypesWithIngredients()
        {
            try
            {
                _logger.LogInformation("Admin retrieving ingredient types with ingredients");

                var types = await _ingredientTypeService.GetAllAsync();
                var typeIds = types.Select(t => t.IngredientTypeId).ToList();
                var ingredientCounts = await _ingredientTypeService.GetIngredientCountsByTypesAsync(typeIds);

                var typesWithIngredients = types
                    .Where(t => ingredientCounts.ContainsKey(t.IngredientTypeId) && ingredientCounts[t.IngredientTypeId] > 0)
                    .Select(type =>
                    {
                        var dto = MapToIngredientTypeDto(type);
                        dto.IngredientCount = ingredientCounts.ContainsKey(type.IngredientTypeId) ?
                            ingredientCounts[type.IngredientTypeId] : 0;
                        return dto;
                    })
                    .ToList();

                return Ok(new ApiResponse<IEnumerable<IngredientTypeDto>>
                {
                    Success = true,
                    Message = "Ingredient types with ingredients retrieved successfully",
                    Data = typesWithIngredients
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient types with ingredients");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient types with ingredients"
                });
            }
        }

        // Helper method to map IngredientType to IngredientTypeDto
        private static IngredientTypeDto MapToIngredientTypeDto(IngredientType type)
        {
            if (type == null) return null;

            return new IngredientTypeDto
            {
                IngredientTypeId = type.IngredientTypeId,
                Name = type.Name,
                CreatedAt = type.CreatedAt,
                UpdatedAt = type.UpdatedAt,
                IngredientCount = type.Ingredients?.Count(i => !i.IsDelete) ?? 0
            };
        }
    }
}
