using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.Customer;
using Capstone.HPTY.ServiceLayer.Services.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customer/products")]
    [Authorize(Roles = "Customer")]
    public class CustomerProductController : ControllerBase
    {
        private readonly IUnifiedProductService _productService;
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<CustomerProductController> _logger;

        public CustomerProductController(
            IUnifiedProductService productService,
            IIngredientService ingredientService,
            ILogger<CustomerProductController> logger)
        {
            _productService = productService;
            _ingredientService = ingredientService;
            _logger = logger;
        }

        [HttpGet("IngredientsTypes")]
        public async Task<ActionResult<ApiResponse<IEnumerable<IngredientTypeDto>>>> GetAllIngredientTypes()
        {
            try
            {
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

        [HttpGet]
        public async Task<ActionResult<PagedUnifiedProductResult>> GetProducts(
               [FromQuery] string? productType = null,
               [FromQuery] string? searchTerm = null,
               [FromQuery] int? typeId = null,
               [FromQuery] string? material = null,
               [FromQuery] string? size = null,
               [FromQuery] decimal? minPrice = null,
               [FromQuery] decimal? maxPrice = null,
               [FromQuery] bool? onlyAvailable = true,
               [FromQuery] int? minQuantity = null,
               [FromQuery] int pageNumber = 1,
               [FromQuery] int pageSize = 10,
               [FromQuery] string sortBy = "Name",
               [FromQuery] bool ascending = true)
        {
            try
            {
                _logger.LogInformation("Customer retrieving products with filters");

                // Validate pagination parameters
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;

                var result = await _productService.GetAllProductsAsync(
                    productType, searchTerm, typeId, material, size,
                    minPrice, maxPrice, onlyAvailable, minQuantity,
                    pageNumber, pageSize, sortBy, ascending);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving products");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
                return StatusCode(500, new { message = "An error occurred while retrieving products" });
            }
        }

        // GET: api/customer/products/{productType}/{id}
        [HttpGet("{productType}/{id}")]
        public async Task<ActionResult<UnifiedProductDto>> GetProductById(string productType, int id)
        {
            try
            {
                _logger.LogInformation("Customer retrieving {ProductType} with ID {ProductId}", productType, id);

                var product = await _productService.GetProductByIdAsync(productType, id);
                if (product == null)
                    return NotFound(new { message = $"{productType} with ID {id} not found" });

                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid product type: {ProductType}", productType);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving {ProductType} with ID {ProductId}", productType, id);
                return StatusCode(500, new { message = "An error occurred while retrieving the product" });
            }
        }

        // GET: api/customer/products/types/{productType}
        [HttpGet("types/{productType}")]
        public async Task<ActionResult<List<object>>> GetProductTypes(string productType)
        {
            try
            {
                _logger.LogInformation("Customer retrieving types for {ProductType}", productType);

                var types = await _productService.GetProductTypesAsync(productType);
                return Ok(types);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid product type for types request: {ProductType}", productType);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving types for {ProductType}", productType);
                return StatusCode(500, new { message = "An error occurred while retrieving product types" });
            }
        }

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
