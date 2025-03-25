using Capstone.HPTY.ServiceLayer.DTOs.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customer/products")]
    [Authorize(Roles = "Khách hàng")]
    public class CustomerProductController : ControllerBase
    {
        private readonly IUnifiedProductService _productService;
        private readonly ILogger<CustomerProductController> _logger;

        public CustomerProductController(
            IUnifiedProductService productService,
            ILogger<CustomerProductController> logger)
        {
            _productService = productService;
            _logger = logger;
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
                if (pageSize > 50) pageSize = 50;

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
    }
}
