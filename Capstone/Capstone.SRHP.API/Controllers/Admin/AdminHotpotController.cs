using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using DamageDeviceDto = Capstone.HPTY.ServiceLayer.DTOs.Hotpot.DamageDeviceDto;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/hotpots")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminHotpotController : ControllerBase
    {
        private readonly IHotpotService _hotpotService;
        private readonly IDamageDeviceService _damageDeviceService;
        private readonly ILogger<AdminHotpotController> _logger;

        public AdminHotpotController(IHotpotService hotpotService, ILogger<AdminHotpotController> logger, IDamageDeviceService damageDeviceService)
        {
            _hotpotService = hotpotService;
            _logger = logger;
            _damageDeviceService = damageDeviceService;
        }

        // GET: api/Hotpot
        // Handles: Getting all hotpots with filtering, searching, and pagination
        [HttpGet]
        public async Task<ActionResult<HotpotPagedResult>> GetHotpots(
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

                DamageDeviceFilterRequest damageDeviceFilterRequest = new DamageDeviceFilterRequest
                {
                    SearchTerm = searchTerm,
                    Status = MaintenanceStatus.Pending, 
                    HotPotInventoryId = null, // Not filtering by inventory ID here
                    FromDate = null, // No date filtering
                    ToDate = null, // No date filtering
                    SortBy = "LoggedDate", // Default sort by logged date
                    Ascending = false, // Default descending order
                    PageNumber = 1, // Single page for count
                    PageSize = int.MaxValue // Get all for count
                };

                var damageDevices = await _damageDeviceService.GetAllAsync(damageDeviceFilterRequest);
                var pagedResult = new HotpotPagedResult
                {
                    Items = result.Items.Select(MapToHotpotDto).ToList(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize,
                    DamageDeviceCount = damageDevices.TotalCount
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
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = $"Không tìm thấy nồi lẩu với ID {id}"
                    });
                }

                var hotpotDto = MapToHotpotDetailDto(hotpot);

                return Ok(new ApiResponse<HotpotDetailDto>
                {
                    Success = true,
                    Message = "Đã lấy thông tin nồi lẩu thành công",
                    Data = hotpotDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot with ID {HotpotId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy thông tin nồi lẩu"
                });
            }
        }

        [HttpGet("inventory/{inventoryId}")]
        [ProducesResponseType(typeof(ApiResponse<InventoryItemDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<InventoryItemDetailDto>>> GetInventoryMaintenanceLogs(int inventoryId)
        {
            try
            {
                var inventoryItem = await _hotpotService.GetByInvetoryIdAsync(inventoryId);

                if (inventoryItem == null || inventoryItem.IsDelete)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Lỗi",
                        Message = $"Không tìm thấy mục tồn kho với ID {inventoryId}"
                    });
                }

                var inventoryDetailDto = MapToInventoryItemDetailDto(inventoryItem);

                return Ok(new ApiResponse<InventoryItemDetailDto>
                {
                    Success = true,
                    Message = "Đã lấy nhật ký bảo trì thành công",
                    Data = inventoryDetailDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance logs for inventory item with ID {InventoryId}", inventoryId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy nhật ký bảo trì"
                });
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
                    LastMaintainDate = DateTime.UtcNow.AddHours(7)
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
                    return NotFound(new { message = $"Không tìm thấy nồi lẩu với ID {id}" });

                // Only update properties that are provided in the request
                if (!string.IsNullOrEmpty(request.Name))
                    existingHotpot.Name = request.Name;

                if (!string.IsNullOrEmpty(request.Material))
                    existingHotpot.Material = request.Material;

                if (!string.IsNullOrEmpty(request.Size))
                    existingHotpot.Size = request.Size;

                if (!string.IsNullOrEmpty(request.Description))
                    existingHotpot.Description = request.Description;

                if (request.ImageURLs != null && request.ImageURLs.Any())
                    existingHotpot.ImageURLs = request.ImageURLs;

                if (request.Price > 0)
                    existingHotpot.Price = request.Price;

                if (request.BasePrice > 0)
                    existingHotpot.BasePrice = request.BasePrice;


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

        // DELETE: api/Hotpot/inventory/{inventoryId}
        // Handles: Deleting a hotpot inventory item
        [HttpDelete("inventory/{inventoryId}")]
        public async Task<ActionResult> DeleteHotpotInventory(int inventoryId)
        {
            try
            {
                await _hotpotService.DeleteHotpotInventory(inventoryId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotpot inventory item with ID {InventoryId}", inventoryId);
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
                    return BadRequest(new { message = "Số lượng phải lớn hơn 0" });

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
                Quantity = hotpot.Quantity, // This now uses the calculated property
            };
        }

        private HotpotDetailDto MapToHotpotDetailDto(Hotpot hotpot)
        {
            if (hotpot == null) return null;

            var dto = new HotpotDetailDto
            {
                HotpotId = hotpot.HotpotId,
                Name = hotpot.Name,
                Material = hotpot.Material,
                Size = hotpot.Size,
                Description = hotpot.Description,
                ImageURLs = hotpot.ImageURLs,
                Price = hotpot.Price,
                BasePrice = hotpot.BasePrice,
                Quantity = hotpot.Quantity,
                LastMaintainDate = hotpot.LastMaintainDate,
                CreatedAt = hotpot.CreatedAt,
                UpdatedAt = hotpot.UpdatedAt
            };

            // Add inventory items without maintenance logs
            if (hotpot.InventoryUnits != null)
            {
                dto.InventoryItems = hotpot.InventoryUnits
                    .Where(i => !i.IsDelete)
                    .Select(i => new InventoryItemDto
                    {
                        HotPotInventoryId = i.HotPotInventoryId,
                        SeriesNumber = i.SeriesNumber,
                        Status = i.Status.GetDisplayName(),
                    })
                    .ToList();
            }

            return dto;
        }

        private InventoryItemDetailDto MapToInventoryItemDetailDto(HotPotInventory inventoryItem)
        {
            if (inventoryItem == null) return null;

            var dto = new InventoryItemDetailDto
            {
                HotPotInventoryId = inventoryItem.HotPotInventoryId,
                SeriesNumber = inventoryItem.SeriesNumber,
                Status = inventoryItem.Status.GetDisplayName(), 
                CreatedAt = inventoryItem.CreatedAt,
                UpdatedAt = inventoryItem.UpdatedAt
            };

            // Add maintenance logs
            if (inventoryItem.ConditionLogs != null)
            {
                dto.ConditionLogs = inventoryItem.ConditionLogs
                    .Where(cl => !cl.IsDelete)
                    .OrderByDescending(cl => cl.LoggedDate)
                    .Select(cl => new DamageDeviceDto
                    {
                        DamageDeviceId = cl.DamageDeviceId,
                        Name = cl.Name,
                        Description = cl.Description,
                        StatusName = cl.Status.GetDisplayName(), 
                        CreatedAt = cl.CreatedAt,
                        UpdatedAt = cl.UpdatedAt
                    })
                    .ToList();
            }

            return dto;
        }
    }
}