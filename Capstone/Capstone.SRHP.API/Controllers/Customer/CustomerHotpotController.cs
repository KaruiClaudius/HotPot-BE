using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Video;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customer/hotpots")]
    [Authorize(Roles = "Customer")]
    public class CustomerHotpotController : ControllerBase
    {
        private readonly IHotpotService _hotpotService;
        private readonly ILogger<CustomerHotpotController> _logger;

        public CustomerHotpotController(
            IHotpotService hotpotService,
            ILogger<CustomerHotpotController> logger)
        {
            _hotpotService = hotpotService;
            _logger = logger;
        }

        // GET: api/customer/hotpots
        // Combines: GetAll, GetPaged, Search, Filter into one endpoint
        [HttpGet]
        public async Task<ActionResult<PagedResult<CustomerHotpotDto>>> GetHotpots(
            [FromQuery] string searchTerm = null,
            [FromQuery] string material = null,
            [FromQuery] string size = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Name",
            [FromQuery] bool ascending = true)
        {
            try
            {
                // Validate pagination parameters
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                // For customers, we only show available hotpots
                bool? isAvailable = true;

                var result = await _hotpotService.GetHotpotsAsync(
                    searchTerm, isAvailable, material, size,
                    minPrice, maxPrice, null,
                    pageNumber, pageSize, sortBy, ascending);

                var pagedResult = new PagedResult<CustomerHotpotDto>
                {
                    Items = result.Items.Select(MapToCustomerHotpotDto).ToList(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpots");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/customer/hotpots/{id}
        // Gets a specific hotpot by ID with its inventory items
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerHotpotDetailDto>> GetById(int id)
        {
            try
            {
                var hotpot = await _hotpotService.GetByIdAsync(id);
                if (hotpot == null)
                    return NotFound(new { message = $"Hotpot with ID {id} not found" });

                // Only show available hotpots to customers
                if (!hotpot.Status || hotpot.Quantity <= 0)
                    return NotFound(new { message = $"Hotpot with ID {id} is not available" });

                var hotpotDto = MapToCustomerHotpotDetailDto(hotpot);
                return Ok(hotpotDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/customer/hotpots/check-availability/{id}
        // Checks if a specific hotpot is available
        [HttpGet("check-availability/{id}")]
        public async Task<ActionResult<bool>> CheckAvailability(int id)
        {
            try
            {
                var isAvailable = await _hotpotService.IsAvailableAsync(id);
                return Ok(isAvailable);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking availability for hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }
        private CustomerHotpotDto MapToCustomerHotpotDto(Hotpot hotpot)
        {
            if (hotpot == null) return null;

            string[] imageUrls;
            try
            {
                imageUrls = hotpot.ImageURLs ?? new string[0];
            }
            catch (JsonException)
            {
                // Log the error
                _logger.LogWarning($"Failed to deserialize ImageURLs for hotpot {hotpot.HotpotId}");
                imageUrls = new string[0];
            }

            return new CustomerHotpotDto
            {
                HotpotId = hotpot.HotpotId,
                Name = hotpot.Name,
                Material = hotpot.Material,
                Size = hotpot.Size,
                Description = hotpot.Description ?? string.Empty,
                ImageURLs = imageUrls,
                Price = hotpot.Price,
                IsAvailable = hotpot.Status && hotpot.Quantity > 0,
            };
        }

        private CustomerHotpotDetailDto MapToCustomerHotpotDetailDto(Hotpot hotpot)
        {
            if (hotpot == null) return null;

            var baseDto = MapToCustomerHotpotDto(hotpot);

            return new CustomerHotpotDetailDto
            {
                HotpotId = baseDto.HotpotId,
                Name = baseDto.Name,
                Material = baseDto.Material,
                Size = baseDto.Size,
                Description = baseDto.Description,
                ImageURLs = baseDto.ImageURLs,
                Price = baseDto.Price,
                IsAvailable = baseDto.IsAvailable,
                HotpotTypeName = baseDto.HotpotTypeName,
                // Include series numbers for available inventory items
                SeriesNumbers = hotpot.InventoryUnits?
                    .Where(i => !i.IsDelete && i.Status)
                    .Select(i => i.SeriesNumber)
                    .ToArray() ?? new string[0]
            };
        }
    }
}
