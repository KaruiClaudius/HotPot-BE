using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentConditionController : ControllerBase
    {
        private readonly IEquipmentConditionService _equipmentConditionService;
        private readonly IHubContext<EquipmentConditionHub> _hubContext;

        public EquipmentConditionController(
            IEquipmentConditionService equipmentConditionService,
            IHubContext<EquipmentConditionHub> hubContext)
        {
            _equipmentConditionService = equipmentConditionService;
            _hubContext = hubContext;
        }

        [HttpPost("log")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ConditionLog>>> LogEquipmentCondition([FromBody] ConditionLog conditionLog)
        {
            try
            {
                var result = await _equipmentConditionService.LogEquipmentConditionAsync(conditionLog);

                // For emergency or critical conditions, notify administrators immediately
                if (result.ScheduleType == MaintenanceScheduleType.Emergency)
                {
                    string equipmentType = result.HotPotInventoryId.HasValue ? "HotPot" : "Utensil";
                    string equipmentName = result.HotPotInventoryId.HasValue
                        ? result.HotPotInventory?.Hotpot?.Name ?? "Unknown HotPot"
                        : result.Utensil?.Name ?? "Unknown Utensil";

                    await _hubContext.Clients.Group("Administrators").SendAsync("ReceiveConditionAlert",
                        result.ConditionLogId,
                        equipmentType,
                        equipmentName,
                        result.Name,
                        result.Description,
                        result.ScheduleType.ToString(),
                        DateTime.UtcNow);
                }

                return CreatedAtAction(nameof(GetConditionLog), new { id = result.ConditionLogId },
                    ApiResponse<ConditionLog>.SuccessResponse(result, "Equipment condition logged successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ConditionLog>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ConditionLog>>> GetConditionLog(int id)
        {
            var conditionLog = await _equipmentConditionService.GetConditionLogByIdAsync(id);
            if (conditionLog == null)
                return NotFound(ApiResponse<ConditionLog>.ErrorResponse($"Condition log with ID {id} not found"));

            return Ok(ApiResponse<ConditionLog>.SuccessResponse(conditionLog, "Condition log retrieved successfully"));
        }

        [HttpGet("equipment/{type}/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetConditionLogsByEquipment(string type, int id)
        {
            if (string.IsNullOrEmpty(type) || (type.ToLower() != "hotpot" && type.ToLower() != "utensil"))
                return BadRequest(ApiResponse<IEnumerable<ConditionLog>>.ErrorResponse("Invalid equipment type. Must be 'hotpot' or 'utensil'."));

            var conditionLogs = await _equipmentConditionService.GetConditionLogsByEquipmentAsync(type, id);
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Equipment condition logs retrieved successfully"));
        }

        [HttpGet("status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetConditionLogsByStatus(MaintenanceStatus status)
        {
            var conditionLogs = await _equipmentConditionService.GetConditionLogsByStatusAsync(status);
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Condition logs retrieved successfully"));
        }

        [HttpGet("schedule-type/{scheduleType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetConditionLogsByScheduleType(MaintenanceScheduleType scheduleType)
        {
            var conditionLogs = await _equipmentConditionService.GetConditionLogsByScheduleTypeAsync(scheduleType);
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Condition logs retrieved successfully"));
        }

        [HttpGet("date-range")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetConditionLogsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
                return BadRequest(ApiResponse<IEnumerable<ConditionLog>>.ErrorResponse("Start date must be before end date"));

            var conditionLogs = await _equipmentConditionService.GetConditionLogsByDateRangeAsync(startDate, endDate);
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Condition logs retrieved successfully"));
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateConditionStatus(int id, [FromBody] UpdateConditionStatusRequest request)
        {
            try
            {
                var result = await _equipmentConditionService.UpdateConditionStatusAsync(id, request.Status);
                if (!result)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Condition log with ID {id} not found"));

                // Get the updated condition log for notification details
                var conditionLog = await _equipmentConditionService.GetConditionLogByIdAsync(id);

                // Determine equipment type and name for notification
                string equipmentType = conditionLog.HotPotInventoryId.HasValue ? "HotPot" : "Utensil";
                string equipmentName = conditionLog.HotPotInventoryId.HasValue
                    ? conditionLog.HotPotInventory?.Hotpot?.Name ?? "Unknown HotPot"
                    : conditionLog.Utensil?.Name ?? "Unknown Utensil";

                // Notify administrators about the status update
                await _hubContext.Clients.Group("Administrators").SendAsync("ReceiveStatusUpdate",
                    id,
                    equipmentType,
                    equipmentName,
                    conditionLog.Name,
                    request.Status.ToString(),
                    DateTime.UtcNow);

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Condition status updated successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("recent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetRecentConditionLogs([FromQuery] int count = 10)
        {
            var conditionLogs = await _equipmentConditionService.GetRecentConditionLogsAsync(count);
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Recent condition logs retrieved successfully"));
        }

        [HttpPost("notify-admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> NotifyAdminDirectly([FromBody] NotifyAdminRequest request)
        {
            try
            {
                // Notify administrators directly with the provided information
                await _hubContext.Clients.Group("Administrators").SendAsync("ReceiveDirectNotification",
                    request.ConditionLogId,
                    request.EquipmentType,
                    request.EquipmentName,
                    request.IssueName,
                    request.Description,
                    request.ScheduleType.ToString(),
                    DateTime.UtcNow);

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Administrators notified successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }
    }
}
