using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customer/ingredients")]
    [Authorize(Roles = "Customer")]
    public class CustomerIngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<CustomerIngredientController> _logger;

        public CustomerIngredientController(
            IIngredientService ingredientService,
            ILogger<CustomerIngredientController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<CustomerIngredientDto>>> GetIngredients(
             [FromQuery] string searchTerm = null,
             [FromQuery] int? typeId = null,
             [FromQuery] bool? onlyAvailable = false,
             [FromQuery] int pageNumber = 1,
             [FromQuery] int pageSize = 10,
             [FromQuery] string sortBy = "Name",
             [FromQuery] bool ascending = true)
        {
            try
            {
                _logger.LogInformation("Customer retrieving ingredients with filters");

                // If pageSize is -1, return all results
                if (pageSize == -1)
                {
                    pageSize = int.MaxValue;
                }

                var result = await _ingredientService.GetIngredientsAsync(
                    searchTerm: searchTerm,
                    typeId: typeId,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    sortBy: sortBy,
                    ascending: ascending);

                var ingredients = result.Items;

                // Apply availability filter if requested
                if (onlyAvailable == true)
                {
                    ingredients = ingredients.Where(i => i.Quantity > 0).ToList();
                }

                // Get all ingredient IDs
                var ingredientIds = ingredients.Select(i => i.IngredientId).ToList();

                // Get all current prices in a single query
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = ingredients.Select(ingredient =>
                {
                    var dto = MapToCustomerIngredientDto(ingredient);

                    // Set price from our bulk query
                    if (currentPrices.ContainsKey(ingredient.IngredientId))
                    {
                        dto.Price = currentPrices[ingredient.IngredientId];
                    }

                    return dto;
                }).ToList();

                var pagedResult = new PagedResult<CustomerIngredientDto>
                {
                    Items = ingredientDtos,
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients for customer");
                return StatusCode(500, new { message = "An error occurred while retrieving ingredients" });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerIngredientDto>> GetIngredientById(int id)
        {
            try
            {
                _logger.LogInformation("Customer retrieving ingredient with ID: {IngredientId}", id);

                var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                if (ingredient == null)
                    return NotFound(new { message = $"Ingredient with ID {id} not found" });

                var currentPrice = await _ingredientService.GetCurrentPriceAsync(id);
                var ingredientDto = MapToCustomerIngredientDto(ingredient);
                ingredientDto.Price = currentPrice;

                return Ok(ingredientDto);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient with ID: {IngredientId} for customer", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the ingredient" });
            }
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<CustomerIngredientTypeDto>>> GetIngredientTypes()
        {
            try
            {
                _logger.LogInformation("Customer retrieving all ingredient types");

                var types = await _ingredientService.GetAllIngredientTypesAsync();
                var typeDtos = types.Select(t => new CustomerIngredientTypeDto
                {
                    IngredientTypeId = t.IngredientTypeId,
                    Name = t.Name
                }).ToList();

                return Ok(typeDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient types for customer");
                return StatusCode(500, new { message = "An error occurred while retrieving ingredient types" });
            }
        }

        [HttpGet("broths")]
        public async Task<ActionResult<IEnumerable<CustomerIngredientDto>>> GetBroths()
        {
            try
            {
                _logger.LogInformation("Customer retrieving all broths");

                // Assuming broth type ID is 1
                const int BROTH_TYPE_ID = 1;

                // Use the combined endpoint logic with typeId filter
                var result = await _ingredientService.GetIngredientsAsync(
                    typeId: BROTH_TYPE_ID,
                    pageSize: int.MaxValue);

                var broths = result.Items;

                // Get all broth IDs
                var brothIds = broths.Select(i => i.IngredientId).ToList();

                // Get all current prices in a single query
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(brothIds);

                var brothDtos = broths.Select(broth =>
                {
                    var dto = MapToCustomerIngredientDto(broth);

                    // Set price from our bulk query
                    if (currentPrices.ContainsKey(broth.IngredientId))
                    {
                        dto.Price = currentPrices[broth.IngredientId];
                    }

                    return dto;
                }).ToList();

                return Ok(brothDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving broths for customer");
                return StatusCode(500, new { message = "An error occurred while retrieving broths" });
            }
        }


        // Helper method for mapping entities to DTOs
        private CustomerIngredientDto MapToCustomerIngredientDto(Ingredient ingredient)
        {
            if (ingredient == null) return null;

            return new CustomerIngredientDto
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name,
                Description = ingredient.Description ?? string.Empty,
                Price = 0, // This will be set by the caller
                IngredientTypeID = ingredient.IngredientTypeID,
                IngredientTypeName = ingredient.IngredientType?.Name ?? "Unknown",
                ImageURL = ingredient.ImageURL ?? string.Empty,
                IsAvailable = ingredient.Quantity > 0
            };
        }
    }
}
