using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/equipment-condition")]
    [ApiController]
    [Authorize(Roles = "Quản lý")]
    public class ManagerEquipmentConditionsController : ControllerBase
    {
        private readonly IEquipmentConditionService _equipmentConditionService;
        private readonly IHubContext<EquipmentConditionHub> _hubContext;

        public ManagerEquipmentConditionsController(
            IEquipmentConditionService equipmentConditionService,
            IHubContext<EquipmentConditionHub> hubContext)
        {
            _equipmentConditionService = equipmentConditionService;
            _hubContext = hubContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<DamageDevice>>> CreateConditionLog([FromBody] DamageDevice damageDevice)
        {
            try
            {
                var result = await _equipmentConditionService.LogEquipmentConditionAsync(damageDevice);

                return CreatedAtAction(nameof(GetConditionLogById), new { id = result.DamageDeviceId },
                    ApiResponse<DamageDevice>.SuccessResponse(result, "Equipment condition logged successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<DamageDevice>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<DamageDevice>>> GetConditionLogById(int id)
        {
            var conditionLog = await _equipmentConditionService.GetConditionLogByIdAsync(id);
            if (conditionLog == null)
                return NotFound(ApiResponse<DamageDevice>.ErrorResponse($"Condition log with ID {id} not found"));

            return Ok(ApiResponse<DamageDevice>.SuccessResponse(conditionLog, "Condition log retrieved successfully"));
        }

        [HttpGet("by-equipment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DamageDevice>>>> GetConditionLogsByEquipment(
            [FromQuery] string type, [FromQuery] int id)
        {
            if (string.IsNullOrEmpty(type) || (type.ToLower() != "hotpot" && type.ToLower() != "utensil"))
                return BadRequest(ApiResponse<IEnumerable<DamageDevice>>.ErrorResponse("Invalid equipment type. Must be 'hotpot' or 'utensil'."));

            var conditionLogs = await _equipmentConditionService.GetConditionLogsByEquipmentAsync(type, id);
            return Ok(ApiResponse<IEnumerable<DamageDevice>>.SuccessResponse(conditionLogs, "Equipment condition logs retrieved successfully"));
        }

        [HttpGet("by-status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DamageDevice>>>> GetConditionLogsByStatus(MaintenanceStatus status)
        {
            var conditionLogs = await _equipmentConditionService.GetConditionLogsByStatusAsync(status);
            return Ok(ApiResponse<IEnumerable<DamageDevice>>.SuccessResponse(conditionLogs, "Condition logs retrieved successfully"));
        }


        [HttpGet("by-date-range")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DamageDevice>>>> GetConditionLogsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
                return BadRequest(ApiResponse<IEnumerable<DamageDevice>>.ErrorResponse("Start date must be before end date"));

            var conditionLogs = await _equipmentConditionService.GetConditionLogsByDateRangeAsync(startDate, endDate);
            return Ok(ApiResponse<IEnumerable<DamageDevice>>.SuccessResponse(conditionLogs, "Condition logs retrieved successfully"));
        }

        [HttpGet("recent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<DamageDevice>>>> GetRecentConditionLogs([FromQuery] int count = 10)
        {
            var conditionLogs = await _equipmentConditionService.GetRecentConditionLogsAsync(count);
            return Ok(ApiResponse<IEnumerable<DamageDevice>>.SuccessResponse(conditionLogs, "Recent condition logs retrieved successfully"));
        }

        [HttpPut("{id}/update-status")]
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
      

        [HttpPost("notify-administrators")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> NotifyAdministrators([FromBody] NotifyAdminRequest request)
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