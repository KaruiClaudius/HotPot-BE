using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/hotpots")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminHotpotController : ControllerBase
    {
        private readonly IHotpotService _hotpotService;
        private readonly ILogger<AdminHotpotController> _logger;

        public AdminHotpotController(IHotpotService hotpotService, ILogger<AdminHotpotController> logger)
        {
            _hotpotService = hotpotService;
            _logger = logger;
        }

        // GET: api/Hotpot
        // Handles: Getting all hotpots with filtering, searching, and pagination
        [HttpGet]
        public async Task<ActionResult<PagedResult<HotpotDto>>> GetHotpots(
            [FromQuery] string searchTerm = null,
            [FromQuery] bool? isAvailable = null,
            [FromQuery] string material = null,
            [FromQuery] string size = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] int? minQuantity = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Name",
            [FromQuery] bool ascending = true)
        {
            try
            {
                var result = await _hotpotService.GetHotpotsAsync(
                    searchTerm, isAvailable, material, size,
                    minPrice, maxPrice, minQuantity,
                    pageNumber, pageSize, sortBy, ascending);

                var pagedResult = new PagedResult<HotpotDto>
                {
                    Items = result.Items.Select(MapToHotpotDto).ToList(),
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

        // GET: api/Hotpot/{id}
        // Handles: Getting a specific hotpot by ID with its inventory items and condition logs
        [HttpGet("{id}")]
        public async Task<ActionResult<HotpotDetailDto>> GetById(int id)
        {
            try
            {
                var hotpot = await _hotpotService.GetByIdAsync(id);
                if (hotpot == null)
                    return NotFound(new { message = $"Hotpot with ID {id} not found" });

                var hotpotDto = MapToHotpotDetailDto(hotpot);

                return Ok(hotpotDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<HotpotDto>> Create(CreateHotpotRequest request)
        {
            try
            {
                var hotpot = new Hotpot
                {
                    Name = request.Name,
                    Material = request.Material,
                    Size = request.Size,
                    Description = request.Description,
                    ImageURLs = request.ImageURLs,
                    Price = request.Price,
                    BasePrice = request.BasePrice,
                    Status = request.Status,
                    LastMaintainDate = DateTime.UtcNow
                };

                var createdHotpot = await _hotpotService.CreateAsync(hotpot, request.SeriesNumbers);

                return CreatedAtAction(nameof(GetById), new { id = createdHotpot.HotpotId }, MapToHotpotDto(createdHotpot));
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating hotpot");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT: api/Hotpot/{id}
        // Handles: Updating a hotpot with optional inventory items
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateHotpotRequest request)
        {
            try
            {
                var existingHotpot = await _hotpotService.GetByIdAsync(id);
                if (existingHotpot == null)
                    return NotFound(new { message = $"Hotpot with ID {id} not found" });

                // Only update properties that are provided in the request
                if (!string.IsNullOrEmpty(request.Name))
                    existingHotpot.Name = request.Name;

                if (!string.IsNullOrEmpty(request.Material))
                    existingHotpot.Material = request.Material;

                if (!string.IsNullOrEmpty(request.Size))
                    existingHotpot.Size = request.Size;

                // Description can be null
                existingHotpot.Description = request.Description;

                // ImageURLs can be null
                existingHotpot.ImageURLs = request.ImageURLs;

                if (request.Price > 0)
                    existingHotpot.Price = request.Price;

                if (request.BasePrice > 0)
                    existingHotpot.BasePrice = request.BasePrice;

                if (request.Status.HasValue)
                    existingHotpot.Status = request.Status.Value;

                // Don't set Quantity or InventoryID - let the service handle it

                await _hotpotService.UpdateAsync(id, existingHotpot, request.SeriesNumbers);

                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE: api/Hotpot/{id}
        // Handles: Deleting a hotpot
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _hotpotService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/Hotpot/{id}/deposit/{quantity}
        // Handles: Calculating the deposit for a hotpot
        [HttpGet("{id}/deposit/{quantity}")]
        public async Task<ActionResult<DepositDto>> CalculateDeposit(int id, int quantity)
        {
            try
            {
                if (quantity <= 0)
                    return BadRequest(new { message = "Quantity must be greater than 0" });

                var deposit = await _hotpotService.CalculateDepositAsync(id, quantity);

                return Ok(new DepositDto
                {
                    HotpotId = id,
                    Quantity = quantity,
                    DepositAmount = deposit
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating deposit for hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // Helper methods for mapping entities to DTOs
        private HotpotDto MapToHotpotDto(Hotpot hotpot)
        {
            return new HotpotDto
            {
                HotpotId = hotpot.HotpotId,
                Name = hotpot.Name,
                Material = hotpot.Material,
                Size = hotpot.Size,
                Description = hotpot.Description,
                ImageURLs = hotpot.ImageURLs,
                Price = hotpot.Price,
                BasePrice = hotpot.BasePrice,
                Status = hotpot.Status,
                Quantity = hotpot.Quantity, // This now uses the calculated property
                LastMaintainDate = hotpot.LastMaintainDate,
                SeriesNumbers = hotpot.InventoryUnits?.Select(i => i.SeriesNumber).ToArray(),
                CreatedAt = hotpot.CreatedAt,
                UpdatedAt = hotpot.UpdatedAt
            };
        }

        private HotpotDetailDto MapToHotpotDetailDto(Hotpot hotpot)
        {
            if (hotpot == null) return null;

            var baseDto = MapToHotpotDto(hotpot);

            return new HotpotDetailDto
            {
                HotpotId = baseDto.HotpotId,
                Name = baseDto.Name,
                Material = baseDto.Material,
                Size = baseDto.Size,
                Description = baseDto.Description,
                ImageURLs = baseDto.ImageURLs,
                Price = baseDto.Price,
                BasePrice = baseDto.BasePrice,
                Status = baseDto.Status,
                Quantity = baseDto.Quantity,
                LastMaintainDate = baseDto.LastMaintainDate,
                SeriesNumbers = baseDto.SeriesNumbers, // Add this to include series numbers in the detail DTO
                CreatedAt = baseDto.CreatedAt,
                UpdatedAt = baseDto.UpdatedAt,
                InventoryItems = hotpot.InventoryUnits?
                    .Where(i => !i.IsDelete)
                    .Select(i => new InventoryItemDto
                    {
                        HotPotInventoryId = i.HotPotInventoryId,
                        SeriesNumber = i.SeriesNumber,
                        Status = i.Status,
                        CreatedAt = i.CreatedAt,
                        UpdatedAt = i.UpdatedAt,
                        ConditionLogs = i.ConditionLogs?
                            .Where(cl => !cl.IsDelete)
                            .OrderByDescending(cl => cl.CreatedAt) // Order by newest first
                            .Select(cl => new ConditionLogDto
                            {
                                ConditionLogId = cl.DamageDeviceId,
                                Name = cl.Name,
                                Description = cl.Description,
                                CreatedAt = cl.CreatedAt,
                                UpdatedAt = cl.UpdatedAt
                            }).ToList() ?? new List<ConditionLogDto>()
                    }).ToList() ?? new List<InventoryItemDto>()
            };
        }
    }
}