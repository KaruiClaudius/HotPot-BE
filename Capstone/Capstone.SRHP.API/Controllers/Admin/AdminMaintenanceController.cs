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
                        Status = "Lỗi",
                        Message = "Số trang và kích thước trang phải lớn hơn 0"
                    });
                }

                _logger.LogInformation($"Admin retrieving hotpot damage logs - Page {pageNumber}, Size {pageSize}");

                var request = new DamageDeviceFilterRequest
                {
                    SearchTerm = searchTerm,
                    Status = status,
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
                    Message = "Lấy danh sách thiết bị hư hỏng thành công",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot damage logs");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy danh sách thiết bị hư hỏng"
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
                    Message = "Lấy thông tin thiết bị hư hỏng thành công",
                    Data = deviceDto
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Damage device not found with ID: {DeviceId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy thông tin thiết bị hư hỏng"
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
                    LoggedDate = DateTime.UtcNow.AddHours(7),
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
                    Message = "Tạo thiết bị hư hỏng thành công",
                    Data = deviceDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating damage device: {DeviceName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating damage device: {DeviceName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể tạo thiết bị hư hỏng"
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

                // Get the existing device to ensure it exists and to get current values
                var partialUpdate = new DamageDevice
                {
                    DamageDeviceId = id // Include the ID for reference
                };

               
                if (request.Name != null)
                    partialUpdate.Name = request.Name;

                if (request.Description != null)
                    partialUpdate.Description = request.Description;

                if (request.Status != null && Enum.TryParse(request.Status, true, out MaintenanceStatus status))
                    partialUpdate.Status = status;

                // Pass the new entity to the service
                await _damageDeviceService.UpdateAsync(id, partialUpdate);

                // Get the updated entity
                var updatedDevice = await _damageDeviceService.GetByIdAsync(id);
                var deviceDto = MapToDamageDeviceDto(updatedDevice);

                return Ok(new ApiResponse<DamageDeviceDto>
                {
                    Success = true,
                    Message = "Cập nhật thiết bị hư hỏng thành công",
                    Data = deviceDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Damage device not found with ID: {DeviceId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể cập nhật thiết bị hư hỏng"
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
                    Message = "Xóa thiết bị hư hỏng thành công",
                    Data = $"Thiết bị hư hỏng với ID {id} đã được xóa"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Damage device not found with ID: {DeviceId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting damage device with ID: {DeviceId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể xóa thiết bị hư hỏng"
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
                StatusName = device.Status.ToString(),
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
                StatusName = device.Status.ToString(),
                LoggedDate = device.LoggedDate,
                HotPotInventoryId = device.HotPotInventoryId,
                HotPotInventorySeriesNumber = device.HotPotInventory?.SeriesNumber
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
                StatusName = device.Status.ToString(),
                LoggedDate = device.LoggedDate,
                HotPotInventoryId = device.HotPotInventoryId,
                HotPotInventorySeriesNumber = device.HotPotInventory?.SeriesNumber,

                // Add the detail-specific properties
                CreatedAt = device.CreatedAt,
                UpdatedAt = device.UpdatedAt
            };

            return detailDto;
        }
    }
}
