using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/hotpots")]
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

        public async Task<ActionResult<ApiResponse<PagedResult<HotpotDto>>>> GetAllHotpots(
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

                _logger.LogInformation($"Admin retrieving hotpots - Page {pageNumber}, Size {pageSize}");
                var pagedHotpots = await _hotpotService.GetPagedAsync(pageNumber, pageSize);
                var hotpotDtos = pagedHotpots.Items.Select(MapToHotpotDto).ToList();

                var result = new PagedResult<HotpotDto>
                {
                    Items = hotpotDtos,
                    PageNumber = pagedHotpots.PageNumber,
                    PageSize = pagedHotpots.PageSize,
                    TotalCount = pagedHotpots.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<HotpotDto>>
                {
                    Success = true,
                    Message = "Hotpots retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpots");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpots"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<HotpotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotpotDto>>> GetHotpotById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving hotpot with ID: {HotpotId}", id);
                var hotpot = await _hotpotService.GetByIdAsync(id);

                if (hotpot == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot with ID {id} not found"
                    });
                }

                var hotpotDto = MapToHotpotDto(hotpot);
                return Ok(new ApiResponse<HotpotDto>
                {
                    Success = true,
                    Message = "Hotpot retrieved successfully",
                    Data = hotpotDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<HotpotDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<HotpotDto>>> CreateHotpot([FromBody] CreateHotpotRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new hotpot: {HotpotName}", request.Name);

                var hotpot = new Hotpot
                {
                    Name = request.Name,
                    Material = request.Material,
                    Size = request.Size,
                    Description = request.Description,
                    ImageURL = request.ImageURL,
                    Price = request.Price,
                    Status = request.Status,
                    Quantity = request.Quantity,
                    HotpotTypeID = request.HotpotTypeID,
                    TurtorialVideoID = request.TurtorialVideoID
                };

                var createdHotpot = await _hotpotService.CreateAsync(hotpot);
                var hotpotDto = MapToHotpotDto(createdHotpot);

                return CreatedAtAction(
                    nameof(GetHotpotById),
                    new { id = createdHotpot.HotpotId },
                    new ApiResponse<HotpotDto>
                    {
                        Success = true,
                        Message = "Hotpot created successfully",
                        Data = hotpotDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating hotpot: {HotpotName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating hotpot: {HotpotName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create hotpot"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<HotPotInventoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotpotDto>>> UpdateHotpot(int id, [FromBody] UpdateHotpotRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating hotpot with ID: {HotpotId}", id);

                var existingHotpot = await _hotpotService.GetByIdAsync(id);
                if (existingHotpot == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot with ID {id} not found"
                    });
                }

                // Update only the properties that are provided
                if (request.Name != null) existingHotpot.Name = request.Name;
                if (request.Material != null) existingHotpot.Material = request.Material;
                if (request.Size.HasValue) existingHotpot.Size = request.Size.Value;
                if (request.Description != null) existingHotpot.Description = request.Description;
                if (request.ImageURL != null) existingHotpot.ImageURL = request.ImageURL;
                if (request.Price.HasValue) existingHotpot.Price = request.Price.Value;
                if (request.Status.HasValue) existingHotpot.Status = request.Status.Value;
                if (request.Quantity.HasValue) existingHotpot.Quantity = request.Quantity.Value;
                if (request.HotpotTypeID.HasValue) existingHotpot.HotpotTypeID = request.HotpotTypeID.Value;
                if (request.TurtorialVideoID.HasValue) existingHotpot.TurtorialVideoID = request.TurtorialVideoID.Value;

                await _hotpotService.UpdateAsync(id, existingHotpot);
                var updatedHotpot = await _hotpotService.GetByIdAsync(id);
                var hotpotDto = MapToHotpotDto(updatedHotpot);

                return Ok(new ApiResponse<HotpotDto>
                {
                    Success = true,
                    Message = "Hotpot updated successfully",
                    Data = hotpotDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot not found with ID: {HotpotId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update hotpot"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteHotpot(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting hotpot with ID: {HotpotId}", id);
                await _hotpotService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Hotpot deleted successfully",
                    Data = $"Hotpot with ID {id} has been deleted"
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot not found with ID: {HotpotId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete hotpot"
                });
            }
        }

        [HttpGet("available")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<HotpotDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<HotpotDto>>>> GetAvailableHotpots()
        {
            try
            {
                _logger.LogInformation("Admin retrieving available hotpots");
                var hotpots = await _hotpotService.GetAvailableHotpotsAsync();
                var hotpotDtos = hotpots.Select(MapToHotpotDto);

                return Ok(new ApiResponse<IEnumerable<HotpotDto>>
                {
                    Success = true,
                    Message = "Available hotpots retrieved successfully",
                    Data = hotpotDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving available hotpots");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve available hotpots"
                });
            }
        }

        [HttpGet("type/{typeId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<HotpotDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IEnumerable<HotpotDto>>>> GetHotpotsByType(int typeId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving hotpots by type ID: {TypeId}", typeId);
                var hotpots = await _hotpotService.GetByTypeAsync(typeId);
                var hotpotDtos = hotpots.Select(MapToHotpotDto);

                return Ok(new ApiResponse<IEnumerable<HotpotDto>>
                {
                    Success = true,
                    Message = "Hotpots retrieved successfully",
                    Data = hotpotDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpots by type ID: {TypeId}", typeId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpots by type"
                });
            }
        }

        [HttpPatch("{id}/status")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateHotpotStatus(int id, [FromBody] bool status)
        {
            try
            {
                _logger.LogInformation("Admin updating status for hotpot with ID: {HotpotId} to {Status}", id, status);
                await _hotpotService.UpdateStatusAsync(id, status);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Hotpot status updated successfully",
                    Data = $"Hotpot with ID {id} status set to {status}"
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot not found with ID: {HotpotId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update hotpot status"
                });
            }
        }

        [HttpPatch("{id}/quantity")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateHotpotQuantity(int id, [FromBody] int quantityChange)
        {
            try
            {
                _logger.LogInformation("Admin updating quantity for hotpot with ID: {HotpotId} by {QuantityChange}", id, quantityChange);
                await _hotpotService.UpdateQuantityAsync(id, quantityChange);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Hotpot quantity updated successfully",
                    Data = $"Hotpot with ID {id} quantity changed by {quantityChange}"
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot not found with ID: {HotpotId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating quantity for hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating quantity for hotpot with ID: {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update hotpot quantity"
                });
            }
        }

        private static HotpotDto MapToHotpotDto(Hotpot hotpot)
        {
            if (hotpot == null) return null;

            return new HotpotDto
            {
                HotpotId = hotpot.HotpotId,
                Name = hotpot.Name,
                Material = hotpot.Material,
                Size = hotpot.Size,
                Description = hotpot.Description,
                ImageURL = hotpot.ImageURL,
                Price = hotpot.Price,
                Status = hotpot.Status,
                Quantity = hotpot.Quantity,
                HotpotTypeName = hotpot.HotpotType?.Name,
                HotpotTypeID = hotpot.HotpotTypeID,
                TurtorialVideoID = hotpot.TurtorialVideoID,
                TurtorialVideoName = hotpot.TurtorialVideo?.Name,
                LastMaintainDate = hotpot.LastMaintainDate,
                CreatedAt = hotpot.CreatedAt,
                UpdatedAt = hotpot.UpdatedAt,
                InventoryUnits = hotpot.InventoryUnits?.Select(i => new HotPotInventoryDto
                {
                    HotPotInventoryId = i.HotPotInventoryId,
                    SeriesNumber = i.SeriesNumber,
                    HotpotId = i.HotpotId,
                    HotpotName = hotpot.Name,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt
                }).ToList()
            };
        }
    }
}