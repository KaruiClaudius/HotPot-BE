using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/maintenance")]
    [Authorize(Roles = "Admin")]
    public class AdminMaintenanceController : ControllerBase
    {
        private readonly IDamageDeviceService _damageDeviceService;
        private readonly IUtensilService _utensilService;
        private readonly IHotpotService _hotpotService;
        private readonly ILogger<AdminMaintenanceController> _logger;

        public AdminMaintenanceController(
            IDamageDeviceService damageDeviceService,
            IUtensilService utensilService,
            IHotpotService hotpotService,
            ILogger<AdminMaintenanceController> logger)
        {
            _damageDeviceService = damageDeviceService;
            _utensilService = utensilService;
            _hotpotService = hotpotService;
            _logger = logger;
        }


        [HttpGet("hotpots")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DamageHotpotDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DamageHotpotDto>>>> GetHotpotLogs(
     [FromQuery] string searchTerm = null,
     [FromQuery] MaintenanceStatus? status = null,
     [FromQuery] int? hotPotInventoryId = null,
     [FromQuery] DateTime? fromDate = null,
     [FromQuery] DateTime? toDate = null,
     [FromQuery] string sortBy = "LoggedDate",
     [FromQuery] bool ascending = false,
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

                _logger.LogInformation($"Admin retrieving hotpot damage logs - Page {pageNumber}, Size {pageSize}");

                var request = new DamageDeviceFilterRequest
                {
                    SearchTerm = searchTerm,
                    Status = status,
                    DeviceType = DeviceType.Hotpot,
                    HotPotInventoryId = hotPotInventoryId,
                    FromDate = fromDate,
                    ToDate = toDate,
                    SortBy = sortBy,
                    Ascending = ascending,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                var pagedDevices = await _damageDeviceService.GetAllAsync(request);
                var deviceDtos = pagedDevices.Items.Select(MapToDamageHotpotDto).ToList();

                var result = new PagedResult<DamageHotpotDto>
                {
                    Items = deviceDtos,
                    PageNumber = pagedDevices.PageNumber,
                    PageSize = pagedDevices.PageSize,
                    TotalCount = pagedDevices.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<DamageHotpotDto>>
                {
                    Success = true,
                    Message = "Hotpot damage logs retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot damage logs");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot damage logs"
                });
            }
        }

        [HttpGet("utensils")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DamageUtensilDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DamageUtensilDto>>>> GetUtensilLogs(
            [FromQuery] string searchTerm = null,
            [FromQuery] MaintenanceStatus? status = null,
            [FromQuery] int? utensilId = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string sortBy = "LoggedDate",
            [FromQuery] bool ascending = false,
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

                _logger.LogInformation($"Admin retrieving utensil damage logs - Page {pageNumber}, Size {pageSize}");

                var request = new DamageDeviceFilterRequest
                {
                    SearchTerm = searchTerm,
                    Status = status,
                    DeviceType = DeviceType.Utensil,
                    UtensilId = utensilId,
                    FromDate = fromDate,
                    ToDate = toDate,
                    SortBy = sortBy,
                    Ascending = ascending,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                var pagedDevices = await _damageDeviceService.GetAllAsync(request);
                var deviceDtos = pagedDevices.Items.Select(MapToDamageUtensilDto).ToList();

                var result = new PagedResult<DamageUtensilDto>
                {
                    Items = deviceDtos,
                    PageNumber = pagedDevices.PageNumber,
                    PageSize = pagedDevices.PageSize,
                    TotalCount = pagedDevices.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<DamageUtensilDto>>
                {
                    Success = true,
                    Message = "Utensil damage logs retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil damage logs");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve utensil damage logs"
                });
            }
        }




        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DamageDeviceDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DamageDeviceDetailDto>>> GetDeviceById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving damage device with ID: {DeviceId}", id);
                var device = await _damageDeviceService.GetByIdAsync(id);

                var deviceDto = MapToDetailDto(device);
                return Ok(new ApiResponse<DamageDeviceDetailDto>
                {
                    Success = true,
                    Message = "Damage device retrieved successfully",
                    Data = deviceDto
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Damage device not found with ID: {DeviceId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve damage device"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<DamageDeviceDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<DamageDeviceDto>>> CreateDevice([FromBody] CreateDamageDeviceRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new damage device: {DeviceName}", request.Name);

                var damageDevice = new DamageDevice
                {
                    Name = request.Name,
                    Description = request.Description,
                    Status = request.Status,
                    LoggedDate = DateTime.UtcNow,
                    UtensilId = request.UtensilID,
                    HotPotInventoryId = request.HotPotInventoryId
                };

                var createdDevice = await _damageDeviceService.CreateAsync(damageDevice);
                var deviceDto = MapToDamageDeviceDto(createdDevice);

                return CreatedAtAction(
                    nameof(GetDeviceById),
                    new { id = createdDevice.DamageDeviceId },
                    new ApiResponse<DamageDeviceDto>
                    {
                        Success = true,
                        Message = "Damage device created successfully",
                        Data = deviceDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating damage device: {DeviceName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating damage device: {DeviceName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create damage device"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DamageDeviceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DamageDeviceDto>>> UpdateDevice(int id, [FromBody] UpdateDamageDeviceRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating damage device with ID: {DeviceId}", id);

                var existingDevice = await _damageDeviceService.GetByIdAsync(id);

                // Update only the properties that are provided
                if (request.Name != null) existingDevice.Name = request.Name;
                if (request.Description != null) existingDevice.Description = request.Description;
                if (request.Status.HasValue) existingDevice.Status = request.Status.Value;

                await _damageDeviceService.UpdateAsync(id, existingDevice);
                var updatedDevice = await _damageDeviceService.GetByIdAsync(id);
                var deviceDto = MapToDamageDeviceDto(updatedDevice);

                return Ok(new ApiResponse<DamageDeviceDto>
                {
                    Success = true,
                    Message = "Damage device updated successfully",
                    Data = deviceDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Damage device not found with ID: {DeviceId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update damage device"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteDevice(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting damage device with ID: {DeviceId}", id);
                await _damageDeviceService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Damage device deleted successfully",
                    Data = $"Damage device with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Damage device not found with ID: {DeviceId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete damage device"
                });
            }
        }


        private static DamageDeviceDto MapToDamageDeviceDto(DamageDevice device)
        {
            if (device == null) return null;

            return new DamageDeviceDto
            {
                DamageDeviceId = device.DamageDeviceId,
                Name = device.Name,
                Description = device.Description,
                StatusName = device.Status.GetDisplayName(),
                LoggedDate = device.LoggedDate,
            };
        }

        private static DamageHotpotDto MapToDamageHotpotDto(DamageDevice device)
        {
            if (device == null) return null;

            return new DamageHotpotDto
            {
                DamageDeviceId = device.DamageDeviceId,
                Name = device.Name,
                Description = device.Description,
                StatusName = device.Status.GetDisplayName(),
                LoggedDate = device.LoggedDate,
                HotPotInventoryId = device.HotPotInventoryId,
                HotPotInventorySeriesNumber = device.HotPotInventory?.SeriesNumber
            };
        }

        private static DamageUtensilDto MapToDamageUtensilDto(DamageDevice device)
        {
            if (device == null) return null;

            return new DamageUtensilDto
            {
                DamageDeviceId = device.DamageDeviceId,
                Name = device.Name,
                Description = device.Description,
                StatusName = device.Status.GetDisplayName(),
                LoggedDate = device.LoggedDate,
                UtensilID = device.UtensilId,
                UtensilName = device.Utensil?.Name
            };
        }


        private static DamageDeviceDetailDto MapToDetailDto(DamageDevice device)
        {
            if (device == null) return null;

            // First create the base DTO properties
            var detailDto = new DamageDeviceDetailDto
            {
                DamageDeviceId = device.DamageDeviceId,
                Name = device.Name,
                Description = device.Description,
                StatusName = device.Status.GetDisplayName(),
                LoggedDate = device.LoggedDate,
                UtensilID = device.UtensilId,
                HotPotInventoryId = device.HotPotInventoryId,
                UtensilName = device.Utensil?.Name,
                HotPotInventorySeriesNumber = device.HotPotInventory?.SeriesNumber,

                // Add the detail-specific properties
                CreatedAt = device.CreatedAt,
                UpdatedAt = device.UpdatedAt
            };

            return detailDto;
        }
    }
}
