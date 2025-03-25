using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/ingredient-types")]
    [Authorize(Roles = "Admin")]
    public class AdminIngredientTypeController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<AdminIngredientTypeController> _logger;

        public AdminIngredientTypeController(
            IIngredientService ingredientService,
            ILogger<AdminIngredientTypeController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<IngredientTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientTypeDto>>>> GetAllIngredientTypes()
        {
            try
            {
                _logger.LogInformation("Admin retrieving all ingredient types");

                var types = await _ingredientService.GetAllIngredientTypesAsync();
                var typeDtos = types.Select(MapToIngredientTypeDto).ToList();

                return Ok(new ApiResponse<IEnumerable<IngredientTypeDto>>
                {
                    Success = true,
                    Message = "Ingredient types retrieved successfully",
                    Data = typeDtos
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

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<IngredientTypeDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IngredientTypeDto>>> CreateIngredientType([FromBody] IngredientTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new ingredient type: {TypeName}", request.Name);

                var createdType = await _ingredientService.CreateIngredientTypeAsync(request.Name);
                var typeDto = MapToIngredientTypeDto(createdType);

                return CreatedAtAction(
                    nameof(GetAllIngredientTypes),
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteIngredientType(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting ingredient type with ID: {TypeId}", id);

                await _ingredientService.DeleteIngredientTypeAsync(id);

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

        // Helper method to map IngredientType to IngredientTypeDto
        private static IngredientTypeDto MapToIngredientTypeDto(IngredientType type)
        {
            if (type == null) return null;

            return new IngredientTypeDto
            {
                IngredientTypeId = type.IngredientTypeId,
                Name = type.Name,
                IngredientCount = type.Ingredients?.Count(i => !i.IsDelete) ?? 0
            };
        }
    }
}
