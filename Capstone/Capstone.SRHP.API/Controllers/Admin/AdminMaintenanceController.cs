using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
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


        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<DamageDeviceDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<DamageDeviceDto>>>> GetAllLogs(
       [FromQuery] string searchTerm = null,
       [FromQuery] MaintenanceStatus? status = null,
       [FromQuery] int? hotPotInventoryId = null,
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

                _logger.LogInformation($"Admin retrieving damage devices - Page {pageNumber}, Size {pageSize}");

                var request = new DamageDeviceFilterRequest
                {
                    SearchTerm = searchTerm,
                    Status = status,
                    HotPotInventoryId = hotPotInventoryId,
                    UtensilId = utensilId,
                    FromDate = fromDate,
                    ToDate = toDate,
                    SortBy = sortBy,
                    Ascending = ascending,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                var pagedDevices = await _damageDeviceService.GetAllAsync(request);
                var deviceDtos = pagedDevices.Items.Select(MapToDamageDeviceDto).ToList();

                var result = new PagedResult<DamageDeviceDto>
                {
                    Items = deviceDtos,
                    PageNumber = pagedDevices.PageNumber,
                    PageSize = pagedDevices.PageSize,
                    TotalCount = pagedDevices.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<DamageDeviceDto>>
                {
                    Success = true,
                    Message = "Damage devices retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving damage devices");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve damage devices"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DamageDeviceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DamageDeviceDto>>> GetDeviceById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving damage device with ID: {DeviceId}", id);
                var device = await _damageDeviceService.GetByIdAsync(id);

                var deviceDto = MapToDamageDeviceDto(device);
                return Ok(new ApiResponse<DamageDeviceDto>
                {
                    Success = true,
                    Message = "Maintenance log retrieved successfully",
                    Data = logDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance log with ID: {LogId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve maintenance log"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ConditionLogDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ConditionLogDto>>> CreateLog([FromBody] CreateConditionLogRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new maintenance log: {LogName}", request.Name);

                // Validate that either UtensilID or HotPotInventoryId is provided, but not both
                if ((request.UtensilID.HasValue && request.HotPotInventoryId.HasValue) ||
                    (!request.UtensilID.HasValue && !request.HotPotInventoryId.HasValue))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Either UtensilId or HotPotInventoryId must be provided, but not both"
                    });
                }

                // Validate that the referenced item exists
                if (request.UtensilID.HasValue)
                {
                    var utensil = await _utensilService.GetUtensilByIdAsync(request.UtensilID.Value);
                    if (utensil == null)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Validation Error",
                            Message = $"Utensil with ID {request.UtensilID.Value} not found"
                        });
                    }
                }
                else if (request.HotPotInventoryId.HasValue)
                {
                    // Assuming you have a method to get HotPotInventory by ID
                    var hotPotInventory = await _hotpotService.GetByIdAsync(request.HotPotInventoryId.Value);
                    if (hotPotInventory == null)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Validation Error",
                            Message = $"HotPot Inventory with ID {request.HotPotInventoryId.Value} not found"
                        });
                    }
                }

                var conditionLog = new DamageDevice
                {
                    Name = request.Name,
                    Description = request.Description,
                    Status = request.Status,
                    ScheduleType = request.ScheduleType,
                    LoggedDate = DateTime.UtcNow,
                    UtensilId = request.UtensilID,
                    HotPotInventoryId = request.HotPotInventoryId
                };

                var createdLog = await _conditionLogService.CreateAsync(conditionLog);
                var logDto = MapToConditionLogDto(createdLog);

                return CreatedAtAction(
                    nameof(GetLogById),
                    new { id = createdLog.DamageDeviceId },
                    new ApiResponse<ConditionLogDto>
                    {
                        Success = true,
                        Message = "Maintenance log created successfully",
                        Data = logDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating maintenance log: {LogName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating maintenance log: {LogName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create maintenance log"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ConditionLogDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ConditionLogDto>>> UpdateLog(int id, [FromBody] UpdateConditionLogRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating maintenance log with ID: {LogId}", id);

                var existingLog = await _conditionLogService.GetByIdAsync(id);
                if (existingLog == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Maintenance log with ID {id} not found"
                    });
                }

                // Update only the properties that are provided
                if (request.Name != null) existingLog.Name = request.Name;
                if (request.Description != null) existingLog.Description = request.Description;
                if (request.Status.HasValue) existingLog.Status = request.Status.Value;
                if (request.ScheduleType.HasValue) existingLog.ScheduleType = request.ScheduleType.Value;

                await _conditionLogService.UpdateAsync(id, existingLog);
                var updatedLog = await _conditionLogService.GetByIdAsync(id);
                var logDto = MapToConditionLogDto(updatedLog);

                return Ok(new ApiResponse<ConditionLogDto>
                {
                    Success = true,
                    Message = "Maintenance log updated successfully",
                    Data = logDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating maintenance log with ID: {LogId}", id);
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
        public async Task<ActionResult<ApiResponse<DamageDeviceDto>>> CreateDevice([FromBody] CreateConditionLogRequest request)
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
        public async Task<ActionResult<ApiResponse<DamageDeviceDto>>> UpdateDevice(int id, [FromBody] UpdateConditionLogRequest request)
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
                _logger.LogInformation("Admin retrieving maintenance logs by status: {Status}", status);
                var logs = await _conditionLogService.GetByStatusAsync(status);
                var logDtos = logs.Select(MapToConditionLogDto);

                return Ok(new ApiResponse<IEnumerable<ConditionLogDto>>
                {
                    Success = true,
                    Message = "Maintenance logs retrieved successfully",
                    Data = logDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance logs by status: {Status}", status);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve maintenance logs"
                });
            }
        }

        [HttpGet("schedule-type/{scheduleType}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ConditionLogDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLogDto>>>> GetLogsByScheduleType(MaintenanceScheduleType scheduleType)
        {
            try
            {
                _logger.LogInformation("Admin retrieving maintenance logs by schedule type: {ScheduleType}", scheduleType);
                var logs = await _conditionLogService.GetByScheduleTypeAsync(scheduleType);
                var logDtos = logs.Select(MapToConditionLogDto);

                return Ok(new ApiResponse<IEnumerable<ConditionLogDto>>
                {
                    Success = true,
                    Message = "Maintenance logs retrieved successfully",
                    Data = logDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance logs by schedule type: {ScheduleType}", scheduleType);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve maintenance logs"
                });
            }
        }

        [HttpGet("date-range")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ConditionLogDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLogDto>>>> GetLogsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                var end = endDate ?? DateTime.UtcNow;
                _logger.LogInformation("Admin retrieving maintenance logs from {StartDate} to {EndDate}", startDate, end);

                var logs = await _conditionLogService.GetByDateRangeAsync(startDate, end);
                var logDtos = logs.Select(MapToConditionLogDto);

                return Ok(new ApiResponse<IEnumerable<ConditionLogDto>>
                {
                    Success = true,
                    Message = "Maintenance logs retrieved successfully",
                    Data = logDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance logs by date range");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve maintenance logs"
                });
            }
        }

        [HttpGet("utensil/{utensilId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ConditionLogDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLogDto>>>> GetLogsByUtensil(int utensilId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving maintenance logs for utensil with ID: {UtensilId}", utensilId);

                // First check if the utensil exists
                var utensil = await _utensilService.GetUtensilByIdAsync(utensilId);
                if (utensil == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Utensil with ID {utensilId} not found"
                    });
                }

                var logs = await _conditionLogService.GetByItemAsync(MaintenanceItemType.Utensil, utensilId);
                var logDtos = logs.Select(MapToConditionLogDto);

                return Ok(new ApiResponse<IEnumerable<ConditionLogDto>>
                {
                    Success = true,
                    Message = $"Maintenance logs for utensil '{utensil.Name}' retrieved successfully",
                    Data = logDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance logs for utensil with ID: {UtensilId}", utensilId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve maintenance logs"
                });
            }
        }

        [HttpGet("hotpot/{hotpotId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ConditionLogDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLogDto>>>> GetLogsByHotpot(int hotpotId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving maintenance logs for hotpot with ID: {HotpotId}", hotpotId);

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

                var logs = await _conditionLogService.GetByItemAsync(MaintenanceItemType.Hotpot, hotpotId);
                var logDtos = logs.Select(MapToConditionLogDto);

                return Ok(new ApiResponse<IEnumerable<ConditionLogDto>>
                {
                    Success = true,
                    Message = $"Maintenance logs for hotpot '{hotpot.Name}' retrieved successfully",
                    Data = logDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving maintenance logs for hotpot with ID: {HotpotId}", hotpotId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve maintenance logs"
                });
            }
        }

        private static ConditionLogDto MapToConditionLogDto(DamageDevice log)
        {
            if (log == null) return null;

            return new ConditionLogDto
            {
                ConditionLogId = log.DamageDeviceId,
                Name = log.Name,
                Description = log.Description,
                Status = log.Status,
                ScheduleType = log.ScheduleType,
                LoggedDate = log.LoggedDate,
                UtensilID = log.UtensilId,
                HotPotInventoryId = log.HotPotInventoryId,
                UtensilName = log.Utensil?.Name,
                HotPotInventorySeriesNumber = log.HotPotInventory?.SeriesNumber,
                CreatedAt = log.CreatedAt,
                UpdatedAt = log.UpdatedAt
            };
        }
    }
}
