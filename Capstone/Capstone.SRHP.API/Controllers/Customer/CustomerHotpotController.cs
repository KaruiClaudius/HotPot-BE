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
    //[Authorize(Roles = "Customer")]
    public class CustomerHotpotController : ControllerBase
    {
        private readonly IHotpotService _hotpotService;
        private readonly IHotpotTypeService _hotpotTypeService;
        private readonly ILogger<CustomerHotpotController> _logger;

        public CustomerHotpotController(
            IHotpotService hotpotService,
            IHotpotTypeService hotpotTypeService,
            ILogger<CustomerHotpotController> logger)
        {
            _hotpotService = hotpotService;
            _hotpotTypeService = hotpotTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerHotpotDto>>> GetAll()
        {
            try
            {
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();
                var hotpotDtos = hotpots.Select(MapToCustomerHotpotDto);
                return Ok(hotpotDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<CustomerHotpotDto>>> GetPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                var pagedResult = await _hotpotService.GetPagedAsync(pageNumber, pageSize);

                // Filter to only show available hotpots to customers
                var filteredItems = pagedResult.Items
                    .Where(h => h.Status && h.Quantity > 0)
                    .ToList();

                var hotpotDtos = filteredItems.Select(MapToCustomerHotpotDto).ToList();

                return Ok(new PagedResult<CustomerHotpotDto>
                {
                    Items = hotpotDtos,
                    TotalCount = pagedResult.TotalCount,
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

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
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<CustomerHotpotTypeDto>>> GetHotpotTypes()
        {
            try
            {
                var types = await _hotpotTypeService.GetAllAsync();
                var typeDtos = types.Select(MapToCustomerHotpotTypeDto);
                return Ok(typeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("by-type/{typeId}")]
        public async Task<ActionResult<IEnumerable<CustomerHotpotDto>>> GetByType(int typeId)
        {
            try
            {
                var hotpots = await _hotpotService.GetByTypeAsync(typeId);

                // Filter to only show available hotpots to customers
                var availableHotpots = hotpots.Where(h => h.Status && h.Quantity > 0);

                var hotpotDtos = availableHotpots.Select(MapToCustomerHotpotDto);
                return Ok(hotpotDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

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
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("search")]
        public async Task<ActionResult<PagedResult<CustomerHotpotDto>>> Search(
            [FromQuery] string searchTerm,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                var pagedResult = await _hotpotService.SearchAsync(searchTerm, pageNumber, pageSize);

                var hotpotDtos = pagedResult.Items.Select(MapToCustomerHotpotDto).ToList();

                return Ok(new PagedResult<CustomerHotpotDto>
                {
                    Items = hotpotDtos,
                    TotalCount = pagedResult.TotalCount,
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<PagedResult<CustomerHotpotDto>>> Filter(
    [FromQuery] decimal? minPrice,
    [FromQuery] decimal? maxPrice,
    [FromQuery] int? typeId,
    [FromQuery] int? size,
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                // Get all available hotpots
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();

                // Apply filters
                var filteredHotpots = hotpots.AsQueryable();

                if (minPrice.HasValue)
                    filteredHotpots = filteredHotpots.Where(h => h.Price >= minPrice.Value);

                if (maxPrice.HasValue)
                    filteredHotpots = filteredHotpots.Where(h => h.Price <= maxPrice.Value);

                if (typeId.HasValue)
                    filteredHotpots = filteredHotpots.Where(h => h.HotpotTypeID == typeId.Value);

                if (size.HasValue)
                    filteredHotpots = filteredHotpots.Where(h => h.Size == size.Value);

                // Calculate total count
                var totalCount = filteredHotpots.Count();

                // Apply pagination
                var pagedHotpots = filteredHotpots
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var hotpotDtos = pagedHotpots.Select(MapToCustomerHotpotDto).ToList();

                return Ok(new PagedResult<CustomerHotpotDto>
                {
                    Items = hotpotDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("materials")]
        public async Task<ActionResult<IEnumerable<string>>> GetAvailableMaterials()
        {
            try
            {
                // Get all available hotpots
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();

                // Extract unique materials
                var materials = hotpots
                    .Select(h => h.Material)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                return Ok(materials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("price-range")]
        public async Task<ActionResult<PriceRangeDto>> GetPriceRange()
        {
            try
            {
                // Get all available hotpots
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();

                if (!hotpots.Any())
                {
                    return Ok(new PriceRangeDto { MinPrice = 0, MaxPrice = 0 });
                }

                var minPrice = hotpots.Min(h => h.Price);
                var maxPrice = hotpots.Max(h => h.Price);

                return Ok(new PriceRangeDto
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("tutorials")]
        public async Task<ActionResult<IEnumerable<TutorialVideoDto>>> GetTutorialVideos()
        {
            try
            {
                // Get all available hotpots with their tutorial videos
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();

                // Extract unique tutorial videos
                var tutorialVideos = hotpots
                    .Where(h => h.TurtorialVideo != null)
                    .Select(h => h.TurtorialVideo)
                .DistinctBy(v => v.TurtorialVideoId)
                    .Select(v => new TutorialVideoDto
                    {
                        TutorialVideoId = v.TurtorialVideoId,
                        Title = v.Name,
                        Description = v.Description,
                        VideoUrl = v.VideoURL
                    })
                    .ToList();

                return Ok(tutorialVideos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        public class PriceRangeDto
        {
            public decimal MinPrice { get; set; }
            public decimal MaxPrice { get; set; }
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
                ImageURLs = hotpot.ImageURLs ?? new string[0],
                Price = hotpot.Price,
                IsAvailable = hotpot.Status && hotpot.Quantity > 0,
                HotpotTypeName = hotpot.HotpotType?.Name ?? "Unknown"
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
                TurtorialVideoID = hotpot.TurtorialVideoID,
                TurtorialVideoUrl = hotpot.TurtorialVideo?.VideoURL ?? string.Empty,
                TurtorialVideoTitle = hotpot.TurtorialVideo?.Name ?? string.Empty
            };
        }

        private CustomerHotpotTypeDto MapToCustomerHotpotTypeDto(HotpotType hotpotType)
        {
            if (hotpotType == null) return null;

            return new CustomerHotpotTypeDto
            {
                HotpotTypeId = hotpotType.HotpotTypeId,
                Name = hotpotType.Name,
            };
        }
    }
}
