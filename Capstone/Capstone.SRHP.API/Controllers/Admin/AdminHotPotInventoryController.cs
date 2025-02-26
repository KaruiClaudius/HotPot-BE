using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/hotpot-inventory")]
    [Authorize(Roles = "Admin")]
    public class AdminHotPotInventoryController : ControllerBase
    {
        private readonly IHotPotInventoryService _inventoryService;
        private readonly IHotpotService _hotpotService;
        private readonly ILogger<AdminHotPotInventoryController> _logger;

        public AdminHotPotInventoryController(
            IHotPotInventoryService inventoryService,
            IHotpotService hotpotService,
            ILogger<AdminHotPotInventoryController> logger)
        {
            _inventoryService = inventoryService;
            _hotpotService = hotpotService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<HotPotInventoryDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<HotPotInventoryDto>>>> GetAllInventory()
        {
            try
            {
                _logger.LogInformation("Admin retrieving all hotpot inventory units");
                var inventories = await _inventoryService.GetAllAsync();
                var inventoryDtos = inventories.Select(MapToInventoryDto);

                return Ok(new ApiResponse<IEnumerable<HotPotInventoryDto>>
                {
                    Success = true,
                    Message = "Hotpot inventory units retrieved successfully",
                    Data = inventoryDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot inventory units");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot inventory units"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<HotPotInventoryDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotPotInventoryDetailDto>>> GetInventoryById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving hotpot inventory unit with ID: {InventoryId}", id);
                var inventory = await _inventoryService.GetByIdAsync(id);

                if (inventory == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot inventory unit with ID {id} not found"
                    });
                }

                var inventoryDto = MapToInventoryDetailDto(inventory);
                return Ok(new ApiResponse<HotPotInventoryDetailDto>
                {
                    Success = true,
                    Message = "Hotpot inventory unit retrieved successfully",
                    Data = inventoryDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot inventory unit with ID: {InventoryId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot inventory unit"
                });
            }
        }

        [HttpGet("hotpot/{hotpotId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<HotPotInventoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IEnumerable<HotPotInventoryDto>>>> GetInventoryByHotpotId(int hotpotId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving inventory units for hotpot with ID: {HotpotId}", hotpotId);

                // First check if the hotpot exists
                var hotpot = await _hotpotService.GetByIdAsync(hotpotId);
                if (hotpot == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot with ID {hotpotId} not found"
                    });
                }

                var inventories = await _inventoryService.GetByHotpotIdAsync(hotpotId);
                var inventoryDtos = inventories.Select(MapToInventoryDto);

                return Ok(new ApiResponse<IEnumerable<HotPotInventoryDto>>
                {
                    Success = true,
                    Message = $"Inventory units for hotpot '{hotpot.Name}' retrieved successfully",
                    Data = inventoryDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving inventory units for hotpot with ID: {HotpotId}", hotpotId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve inventory units"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<HotPotInventoryDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<HotPotInventoryDto>>> CreateInventory([FromBody] CreateHotPotInventoryRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new hotpot inventory unit with series number: {SeriesNumber}", request.SeriesNumber);

                // Create the inventory entity
                var inventory = new HotPotInventory
                {
                    SeriesNumber = request.SeriesNumber,
                    HotpotId = request.HotpotId
                };

                var createdInventory = await _inventoryService.CreateAsync(inventory);
                var inventoryDto = MapToInventoryDto(createdInventory);

                return CreatedAtAction(
                    nameof(GetInventoryById),
                    new { id = createdInventory.HotPotInventoryId },
                    new ApiResponse<HotPotInventoryDto>
                    {
                        Success = true,
                        Message = "Hotpot inventory unit created successfully",
                        Data = inventoryDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating hotpot inventory unit: {SeriesNumber}", request.SeriesNumber);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating hotpot inventory unit: {SeriesNumber}", request.SeriesNumber);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create hotpot inventory unit"
                });
            }
        }

        [HttpPost("bulk")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<HotPotInventoryDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<HotPotInventoryDto>>>> CreateBulkInventory([FromBody] BulkCreateHotPotInventoryRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating {Quantity} new hotpot inventory units for hotpot ID: {HotpotId}",
                    request.Quantity, request.HotpotId);

                var createdInventories = await _inventoryService.CreateBulkAsync(
                    request.HotpotId,
                    request.Quantity,
                    request.SeriesNumberPrefix);

                var inventoryDtos = createdInventories.Select(MapToInventoryDto);

                return CreatedAtAction(
                    nameof(GetInventoryByHotpotId),
                    new { hotpotId = request.HotpotId },
                    new ApiResponse<IEnumerable<HotPotInventoryDto>>
                    {
                        Success = true,
                        Message = $"{request.Quantity} hotpot inventory units created successfully",
                        Data = inventoryDtos
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating bulk hotpot inventory units for hotpot ID: {HotpotId}",
                    request.HotpotId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating bulk hotpot inventory units for hotpot ID: {HotpotId}",
                    request.HotpotId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create hotpot inventory units"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<HotPotInventoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotPotInventoryDto>>> UpdateInventory(int id, [FromBody] UpdateHotPotInventoryRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating hotpot inventory unit with ID: {InventoryId}", id);

                var existingInventory = await _inventoryService.GetByIdAsync(id);
                if (existingInventory == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot inventory unit with ID {id} not found"
                    });
                }

                if (request.SeriesNumber != null)
                {
                    existingInventory.SeriesNumber = request.SeriesNumber;
                }

                await _inventoryService.UpdateAsync(id, existingInventory);

                var updatedInventory = await _inventoryService.GetByIdAsync(id);
                var inventoryDto = MapToInventoryDto(updatedInventory);

                return Ok(new ApiResponse<HotPotInventoryDto>
                {
                    Success = true,
                    Message = "Hotpot inventory unit updated successfully",
                    Data = inventoryDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating hotpot inventory unit with ID: {InventoryId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot inventory unit not found with ID: {InventoryId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot inventory unit with ID: {InventoryId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update hotpot inventory unit"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteInventory(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting hotpot inventory unit with ID: {InventoryId}", id);

                await _inventoryService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Hotpot inventory unit deleted successfully",
                    Data = $"Hotpot inventory unit with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting hotpot inventory unit with ID: {InventoryId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot inventory unit not found with ID: {InventoryId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotpot inventory unit with ID: {InventoryId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete hotpot inventory unit"
                });
            }
        }

        [HttpGet("series/{seriesNumber}")]
        [ProducesResponseType(typeof(ApiResponse<HotPotInventoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotPotInventoryDto>>> GetInventoryBySeriesNumber(string seriesNumber)
        {
            try
            {
                _logger.LogInformation("Admin retrieving hotpot inventory unit with series number: {SeriesNumber}", seriesNumber);

                var inventory = await _inventoryService.GetBySeriesNumberAsync(seriesNumber);

                if (inventory == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot inventory unit with series number '{seriesNumber}' not found"
                    });
                }

                var inventoryDto = MapToInventoryDto(inventory);

                return Ok(new ApiResponse<HotPotInventoryDto>
                {
                    Success = true,
                    Message = "Hotpot inventory unit retrieved successfully",
                    Data = inventoryDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot inventory unit with series number: {SeriesNumber}", seriesNumber);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot inventory unit"
                });
            }
        }

        private static HotPotInventoryDto MapToInventoryDto(HotPotInventory inventory)
        {
            if (inventory == null) return null;

            return new HotPotInventoryDto
            {
                HotPotInventoryId = inventory.HotPotInventoryId,
                SeriesNumber = inventory.SeriesNumber,
                HotpotId = inventory.HotpotId,
                HotpotName = inventory.Hotpot?.Name,
                CreatedAt = inventory.CreatedAt,
                UpdatedAt = inventory.UpdatedAt
            };
        }

        private static HotPotInventoryDetailDto MapToInventoryDetailDto(HotPotInventory inventory)
        {
            if (inventory == null) return null;

            return new HotPotInventoryDetailDto
            {
                HotPotInventoryId = inventory.HotPotInventoryId,
                SeriesNumber = inventory.SeriesNumber,
                HotpotId = inventory.HotpotId,
                HotpotName = inventory.Hotpot?.Name,
                CreatedAt = inventory.CreatedAt,
                UpdatedAt = inventory.UpdatedAt,
                ConditionLogs = inventory.ConditionLogs?
                    .Where(cl => !cl.IsDelete)
                    .Select(cl => new ConditionLogDto
                    {
                        ConditionLogId = cl.ConditionLogId,
                        Name = cl.Name,
                        Description = cl.Description,
                        Status = cl.Status,
                        ScheduleType = cl.ScheduleType,
                        LoggedDate = cl.LoggedDate,
                        HotPotInventoryId = cl.HotPotInventoryId,
                        HotPotInventorySeriesNumber = inventory.SeriesNumber,
                        CreatedAt = cl.CreatedAt,
                        UpdatedAt = cl.UpdatedAt
                    })
                    .ToList()
            };
        }
    }
}
