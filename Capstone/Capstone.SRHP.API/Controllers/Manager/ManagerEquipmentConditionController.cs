using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/equipment-condition")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerEquipmentConditionsController : ControllerBase
    {
        private readonly IEquipmentConditionService _equipmentConditionService;
        private readonly INotificationService _notificationService;
        private readonly IHotpotService _hotpotService;
        private readonly IUtensilService _utensilService;

        public ManagerEquipmentConditionsController(
            IEquipmentConditionService equipmentConditionService,
            INotificationService notificationService, IHotpotService hotpotService, IUtensilService utensilService)
        {
            _equipmentConditionService = equipmentConditionService;
            _notificationService = notificationService;
            _hotpotService = hotpotService;
            _utensilService = utensilService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<EquipmentConditionDetailDto>>> CreateConditionLog(
    [FromBody] CreateEquipmentConditionRequest request)
        {
            try
            {
                var result = await _equipmentConditionService.LogEquipmentConditionAsync(request);

                // Get equipment name for the notification
                string equipmentName = await GetEquipmentNameAsync(request);

                // Notify administrators about the new condition log
                await _notificationService.NotifyRoleAsync(
                      "Admin",
                      "EquipmentCondition",
                      "Vấn Đề Mới Về Tình Trạng Nồi Lẩu",
                      $"Vấn đề mới được báo cáo cho {equipmentName}: {request.Name}",
                      new Dictionary<string, object>
                      {
                        { "ConditionLogId", result.DamageDeviceId },
                        { "HotPotName", equipmentName },
                        { "IssueName", request.Name },
                        { "Description", request.Description },
                        { "Status", request.Status.ToString() },
                        { "ReportTime", DateTime.UtcNow.AddHours(7) },
                      });

                return CreatedAtAction(nameof(GetConditionLogById), new { id = result.DamageDeviceId },
                    ApiResponse<EquipmentConditionDetailDto>.SuccessResponse(result, "HotPot condition logged successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<EquipmentConditionDetailDto>.ErrorResponse(ex.Message));
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<EquipmentConditionDetailDto>>> GetConditionLogById(int id)
        {
            var conditionLog = await _equipmentConditionService.GetConditionLogByIdAsync(id);
            if (conditionLog == null)
                return NotFound(ApiResponse<EquipmentConditionDetailDto>.ErrorResponse($"Condition log with ID {id} not found"));

            return Ok(ApiResponse<EquipmentConditionDetailDto>.SuccessResponse(conditionLog, "Condition log retrieved successfully"));
        }

        [HttpGet("by-equipment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PagedResult<EquipmentConditionListItemDto>>>> GetConditionLogsByEquipment(
           [FromQuery] string type,
           [FromQuery] int id,
           [FromQuery] PaginationParams paginationParams)
        {
            if (string.IsNullOrEmpty(type) || (type.ToLower() != "hotpot" && type.ToLower() != "utensil"))
                return BadRequest(ApiResponse<PagedResult<EquipmentConditionListItemDto>>.ErrorResponse("Invalid equipment type. Must be 'hotpot' or 'utensil'."));

            var conditionLogs = await _equipmentConditionService.GetConditionLogsByEquipmentAsync(type, id, paginationParams);
            return Ok(ApiResponse<PagedResult<EquipmentConditionListItemDto>>.SuccessResponse(conditionLogs, "Equipment condition logs retrieved successfully"));
        }

        // Similarly update other collection-returning endpoints to use the DTO mapping

        [HttpGet("by-status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<EquipmentConditionListItemDto>>>> GetConditionLogsByStatus(
            MaintenanceStatus status,
            [FromQuery] PaginationParams paginationParams)
        {
            var conditionLogs = await _equipmentConditionService.GetConditionLogsByStatusAsync(status, paginationParams);
            return Ok(ApiResponse<PagedResult<EquipmentConditionListItemDto>>.SuccessResponse(conditionLogs, "Condition logs retrieved successfully"));
        }

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<EquipmentConditionListItemDto>>>> GetFilteredConditionLogs(
           [FromQuery] EquipmentConditionFilterDto filterParams)
        {
            var conditionLogs = await _equipmentConditionService.GetFilteredConditionLogsAsync(filterParams);
            return Ok(ApiResponse<PagedResult<EquipmentConditionListItemDto>>.SuccessResponse(conditionLogs, "Filtered condition logs retrieved successfully"));
        }

        [HttpPut("{id}/update-status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<EquipmentConditionDetailDto>>> UpdateConditionStatus(
     int id,
     [FromBody] UpdateConditionStatusRequest request)
        {
            try
            {
                var result = await _equipmentConditionService.UpdateConditionStatusAsync(id, request);
                if (result == null)
                    return NotFound(ApiResponse<EquipmentConditionDetailDto>.ErrorResponse($"Condition log with ID {id} not found"));

                // Notify administrators about the status update using the simplified notification service
                await _notificationService.NotifyRoleAsync(
                     "Admin",
                     "EquipmentCondition",
                     "Đã Cập Nhật Trạng Thái Thiết Bị",
                     $"Trạng thái đã được cập nhật thành {request.Status} cho {result.EquipmentName}: {result.Name}",
                     new Dictionary<string, object>
                     {
                        { "ConditionLogId", id },
                        { "EquipmentName", result.EquipmentName },
                        { "IssueName", result.Name },
                        { "Description", result.Description },
                        { "NewStatus", request.Status.ToString() },
                        { "UpdateTime", DateTime.UtcNow.AddHours(7) }
                     });

                return Ok(ApiResponse<EquipmentConditionDetailDto>.SuccessResponse(result, "Condition status updated successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<EquipmentConditionDetailDto>.ErrorResponse(ex.Message));
            }
        }

        private async Task<string> GetEquipmentNameAsync(CreateEquipmentConditionRequest request)
        {
            try
            {
                var hotpot = await _hotpotService.GetByInvetoryIdAsync(request.HotPotInventoryId);
                return hotpot?.Hotpot.Name ?? $"HotPot #{request.HotPotInventoryId}";
            }
            catch
            {
                return $"HotPot #{request.HotPotInventoryId}";
            }
        }

    }
}