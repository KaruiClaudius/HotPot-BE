using Capstone.HPTY.ModelLayer.Entities;
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


        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<CustomerIngredientDto>>> GetPagedIngredients(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _ingredientService.GetPagedAsync(pageNumber, pageSize);

                var pagedResult = new PagedResult<CustomerIngredientDto>
                {
                    Items = result.Items.Select(MapToCustomerIngredientDto).ToList(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerIngredientDto>> GetIngredientById(int id)
        {
            try
            {
                var ingredient = await _ingredientService.GetByIdAsync(id);
                if (ingredient == null)
                    return NotFound(new { message = $"Ingredient with ID {id} not found" });

                var ingredientDto = MapToCustomerIngredientDto(ingredient);

                return Ok(ingredientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<CustomerIngredientTypeDto>>> GetIngredientTypes()
        {
            try
            {
                var types = await _ingredientTypeService.GetAllAsync();
                var typeDtos = types.Select(t => new CustomerIngredientTypeDto
                {
                    IngredientTypeId = t.IngredientTypeId,
                    Name = t.Name
                }).ToList();

                return Ok(typeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("by-type/{typeId}")]
        public async Task<ActionResult<IEnumerable<CustomerIngredientDto>>> GetIngredientsByType(int typeId)
        {
            try
            {
                var ingredients = await _ingredientService.GetByTypeAsync(typeId);
                var ingredientDtos = ingredients.Select(MapToCustomerIngredientDto).ToList();

                return Ok(ingredientDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedResult<CustomerIngredientDto>>> SearchIngredients(
            [FromQuery] string searchTerm = "",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _ingredientService.SearchAsync(searchTerm, pageNumber, pageSize);

                var pagedResult = new PagedResult<CustomerIngredientDto>
                {
                    Items = result.Items.Select(MapToCustomerIngredientDto).ToList(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("broths")]
        public async Task<ActionResult<IEnumerable<CustomerIngredientDto>>> GetBroths()
        {
            try
            {
                // Assuming broth type ID is 1
                const int BROTH_TYPE_ID = 1;

                var broths = await _ingredientService.GetByTypeAsync(BROTH_TYPE_ID);
                var brothDtos = broths.Select(MapToCustomerIngredientDto).ToList();

                return Ok(brothDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<CustomerIngredientDto>>> GetAvailableIngredients()
        {
            try
            {
                var allIngredients = await _ingredientService.GetAllAsync();
                var availableIngredients = allIngredients.Where(i => i.Quantity > 0).ToList();
                var ingredientDtos = availableIngredients.Select(MapToCustomerIngredientDto).ToList();

                return Ok(ingredientDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Helper method for mapping entities to DTOs
        private CustomerIngredientDto MapToCustomerIngredientDto(Ingredient ingredient)
        {
            if (ingredient == null) return null;

            // Get current price
            decimal price = 0;
            if (ingredient.IngredientPrices != null && ingredient.IngredientPrices.Any())
            {
                price = ingredient.IngredientPrices
                    .OrderByDescending(p => p.EffectiveDate)
                    .FirstOrDefault()?.Price ?? 0;
            }

            return new CustomerIngredientDto
            {
                IngredientId = ingredient.IngredientId,
                Name = ingredient.Name,
                Description = ingredient.Description ?? string.Empty,
                Price = price,
                IngredientTypeID = ingredient.IngredientTypeID,
                IngredientTypeName = ingredient.IngredientType?.Name ?? "Unknown",
                ImageURL = ingredient.ImageURL ?? string.Empty,
                IsAvailable = ingredient.Quantity > 0
            };
        }
    }
}
