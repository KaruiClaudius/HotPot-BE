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
    [Route("api/hotpots")]
    [ApiController]
    public class HotpotController : ControllerBase
    {
        private readonly IHotpotService _hotpotService;
        private readonly ILogger<HotpotController> _logger;

        public HotpotController(IHotpotService hotpotService, ILogger<HotpotController> logger)
        {
            _hotpotService = hotpotService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotpotDto>>> GetAll()
        {
            try
            {
                var hotpots = await _hotpotService.GetAllAsync();
                var response = hotpots.Select(MapToResponse).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all hotpots");
                return StatusCode(500, new { message = "An error occurred while retrieving hotpots" });
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<HotpotDto>>> GetPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                var pagedResult = await _hotpotService.GetPagedAsync(pageNumber, pageSize);

                var items = pagedResult.Items.Select(MapToResponse).ToList();

                return Ok(new PagedResult<HotpotDto>
                {
                    Items = items,
                    TotalCount = pagedResult.TotalCount,
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged hotpots");
                return StatusCode(500, new { message = "An error occurred while retrieving hotpots" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotpotDto>> GetById(int id)
        {
            try
            {
                var hotpot = await _hotpotService.GetByIdAsync(id);
                if (hotpot == null)
                    return NotFound(new { message = $"Hotpot with ID {id} not found" });

                var response = MapToResponse(hotpot);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the hotpot" });
            }
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<HotpotDto>>> GetAvailable()
        {
            try
            {
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();
                var response = hotpots.Select(MapToResponse).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving available hotpots");
                return StatusCode(500, new { message = "An error occurred while retrieving available hotpots" });
            }
        }

        [HttpGet("type/{typeId}")]
        public async Task<ActionResult<IEnumerable<HotpotDto>>> GetByType(int typeId)
        {
            try
            {
                var hotpots = await _hotpotService.GetByTypeAsync(typeId);
                var response = hotpots.Select(MapToResponse).ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpots by type ID {TypeId}", typeId);
                return StatusCode(500, new { message = "An error occurred while retrieving hotpots by type" });
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedResult<HotpotDto>>> Search(
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

                var items = pagedResult.Items.Select(MapToResponse).ToList();

                return Ok(new PagedResult<HotpotDto>
                {
                    Items = items,
                    TotalCount = pagedResult.TotalCount,
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching hotpots with term {SearchTerm}", searchTerm);
                return StatusCode(500, new { message = "An error occurred while searching hotpots" });
            }
        }

        [HttpGet("{id}/deposit")]
        public async Task<ActionResult<DepositResponse>> CalculateDeposit(int id, [FromQuery] int quantity = 1)
        {
            try
            {
                if (quantity < 1)
                    return BadRequest(new { message = "Quantity must be at least 1" });

                var deposit = await _hotpotService.CalculateDepositAsync(id, quantity);

                return Ok(new DepositResponse
                {
                    HotpotId = id,
                    Quantity = quantity,
                    DepositAmount = deposit,
                    DepositPercentage = 70 // 70% of base price
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating deposit for hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = "An error occurred while calculating the deposit" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<HotpotDto>> Create([FromBody] CreateHotpotRequest request)
        {
            try
            {
                var hotpot = new Hotpot
                {
                    Name = request.Name,
                    Material = request.Material,
                    Size = request.Size,
                    Description = request.Description,
                    ImageURL = request.ImageURLs != null ? JsonSerializer.Serialize(request.ImageURLs) : null,
                    Price = request.Price,
                    BasePrice = request.BasePrice,
                    Status = request.Status,
                    Quantity = request.Quantity,
                    LastMaintainDate = DateTime.UtcNow,
                    HotpotTypeID = request.HotpotTypeID,
                    TurtorialVideoID = request.TurtorialVideoID,
                    InventoryID = request.InventoryID
                };

                var createdHotpot = await _hotpotService.CreateAsync(hotpot);
                var response = MapToResponse(createdHotpot);

                return CreatedAtAction(nameof(GetById), new { id = createdHotpot.HotpotId }, response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating hotpot");
                return StatusCode(500, new { message = "An error occurred while creating the hotpot" });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateHotpotRequest request)
        {
            try
            {
                var existingHotpot = await _hotpotService.GetByIdAsync(id);
                if (existingHotpot == null)
                    return NotFound(new { message = $"Hotpot with ID {id} not found" });

                existingHotpot.Name = request.Name;
                existingHotpot.Material = request.Material;
                existingHotpot.Size = request.Size;
                existingHotpot.Description = request.Description;
                existingHotpot.ImageURL = request.ImageURLs != null ? JsonSerializer.Serialize(request.ImageURLs) : null;
                existingHotpot.Price = request.Price;
                existingHotpot.BasePrice = request.BasePrice;
                existingHotpot.Status = request.Status;
                existingHotpot.Quantity = request.Quantity;
                existingHotpot.HotpotTypeID = request.HotpotTypeID;
                existingHotpot.TurtorialVideoID = request.TurtorialVideoID;
                existingHotpot.InventoryID = request.InventoryID;

                await _hotpotService.UpdateAsync(id, existingHotpot);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the hotpot" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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
                return StatusCode(500, new { message = "An error occurred while deleting the hotpot" });
            }
        }

        [HttpPut("{id}/status/{status}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateStatus(int id, bool status)
        {
            try
            {
                await _hotpotService.UpdateStatusAsync(id, status);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the hotpot status" });
            }
        }

        [HttpPut("{id}/quantity/{quantityChange}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateQuantity(int id, int quantityChange)
        {
            try
            {
                await _hotpotService.UpdateQuantityAsync(id, quantityChange);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating quantity for hotpot with ID {HotpotId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the hotpot quantity" });
            }
        }

        // Helper methods
        private HotpotDto MapToResponse(Hotpot hotpot)
        {
            if (hotpot == null) return null;

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
                DepositAmount = Math.Round(hotpot.BasePrice * 0.7m, 2), // Calculate deposit amount (70% of base price)
                Status = hotpot.Status,
                Quantity = hotpot.Quantity,
                LastMaintainDate = hotpot.LastMaintainDate,
                HotpotType = hotpot.HotpotType != null ? new HotpotTypeDto
                {
                    HotpotTypeId = hotpot.HotpotType.HotpotTypeId,
                    Name = hotpot.HotpotType.Name
                } : null,
                TurtorialVideo = hotpot.TurtorialVideo != null ? new TurtorialVideoResponse
                {
                    TurtorialVideoId = hotpot.TurtorialVideo.TurtorialVideoId,
                    Title = hotpot.TurtorialVideo.Name,
                    Description = hotpot.TurtorialVideo.Description,
                    VideoUrl = hotpot.TurtorialVideo.VideoURL
                } : null,
                CreatedAt = hotpot.CreatedAt,
                UpdatedAt = hotpot.UpdatedAt
            };
        }
    }
}