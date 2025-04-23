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

                // Determine equipment type and name for the notification
                string equipmentType = DetermineEquipmentType(request);
                string equipmentName = await GetEquipmentNameAsync(request);

                // Notify administrators about the new condition log
                await _notificationService.NotifyRole(
                    "Administrators",
                    "ConditionIssue",
                    "New Equipment Condition Issue",
                    $"New issue reported for {equipmentName}: {request.Name}",
                    new Dictionary<string, object>
                    {
                { "ConditionLogId", result.DamageDeviceId },
                { "EquipmentType", equipmentType },
                { "EquipmentName", equipmentName },
                { "IssueName", request.Name },
                { "Description", request.Description },
                { "Status", request.Status.ToString() },
                { "ReportTime", DateTime.UtcNow },
                    });


                return CreatedAtAction(nameof(GetConditionLogById), new { id = result.DamageDeviceId },
                    ApiResponse<EquipmentConditionDetailDto>.SuccessResponse(result, "Equipment condition logged successfully"));
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
                await _notificationService.NotifyRole(
                    "Administrators",
                    "EquipmentStatusUpdate",
                    "Equipment Status Updated",
                    $"Status updated to {request.Status} for {result.EquipmentName}: {result.Name}",
                    new Dictionary<string, object>
                    {
                { "ConditionLogId", id },
                { "EquipmentType", result.EquipmentType },
                { "EquipmentName", result.EquipmentName },
                { "IssueName", result.Name },
                { "Description", result.Description },
                { "NewStatus", request.Status.ToString() },

                { "UpdateTime", DateTime.UtcNow }
                    });

                return Ok(ApiResponse<EquipmentConditionDetailDto>.SuccessResponse(result, "Condition status updated successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<EquipmentConditionDetailDto>.ErrorResponse(ex.Message));
            }
        }

        private string DetermineEquipmentType(CreateEquipmentConditionRequest request)
        {
            if (request.HotPotInventoryId.HasValue)
                return "HotPot";
            else if (request.UtensilId.HasValue)
                return "Utensil";
            else
                return "Unknown";
        }

        private async Task<string> GetEquipmentNameAsync(CreateEquipmentConditionRequest request)
        {
            try
            {
                if (request.HotPotInventoryId.HasValue)
                {
                    var hotpot = await _hotpotService.GetByInvetoryIdAsync(request.HotPotInventoryId.Value);
                    return hotpot?.Hotpot.Name ?? $"HotPot #{request.HotPotInventoryId.Value}";
                }
                else if (request.UtensilId.HasValue)
                {
                    var utensil = await _utensilService.GetUtensilByIdAsync(request.UtensilId.Value);
                    return utensil?.Name ?? $"Utensil #{request.UtensilId.Value}";
                }

                return "Unknown Equipment";
            }
            catch
            {
                return "Unknown Equipment";
            }
        }

        //private string DeterminePriority(CreateEquipmentConditionRequest request)
        //{
        //    // Logic to determine priority based on the issue type, description, or status
        //    if (request.Status == MaintenanceStatus.InProgress)
        //        return "High";       
        //    else if (request.Status == MaintenanceStatus.InProgress)
        //        return "Medium";
        //    else
        //        return "Normal";
        //}

    }
}