using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]

    public class ManagerEquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IHubContext<EquipmentHub> _equipmentHubContext;

        public ManagerEquipmentController(IEquipmentService equipmentService, IHubContext<EquipmentHub> equipmentHubContext)
        {
            _equipmentService = equipmentService;
            _equipmentHubContext = equipmentHubContext;
        }

        [HttpPost("failures")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ConditionLog>>> LogEquipmentFailure([FromBody] EquipmentFailureDto failureDto)
        {
            try
            {
                // Validate that exactly one equipment type is specified
                bool hasUtensil = failureDto.UtensilID.HasValue && failureDto.UtensilID.Value > 0;
                bool hasHotPot = failureDto.HotPotInventoryId.HasValue && failureDto.HotPotInventoryId.Value > 0;

                if ((!hasUtensil && !hasHotPot) || (hasUtensil && hasHotPot))
                {
                    return BadRequest(ApiResponse<ConditionLog>.ErrorResponse(
                        "Exactly one equipment type (either UtensilID or HotPotInventoryId) must be specified with a valid ID"));
                }


                // Map DTO to entity using Mapster
                var conditionLog = failureDto.Adapt<ConditionLog>();

                var result = await _equipmentService.LogEquipmentFailureAsync(conditionLog);

                // Notify staff about the new equipment failure
                await _equipmentHubContext.Clients.Group("Staff").SendAsync("ReceiveNewFailure",
                    result.ConditionLogId,
                    result.Name,
                    result.Description,
                    result.Status,
                    result.LoggedDate);

                return CreatedAtAction(nameof(GetConditionLog), new { id = result.ConditionLogId },
                    ApiResponse<ConditionLog>.SuccessResponse(result, "Equipment failure logged successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ConditionLog>.ErrorResponse(ex.Message));
            }
        }

        [HttpPut("failures/{id}/timeline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ConditionLog>>> UpdateResolutionTimeline(
            int id,
            [FromBody] UpdateResolutionTimelineRequest request)
        {
            try
            {
                var result = await _equipmentService.UpdateResolutionTimelineAsync(
                    id,
                    request.Status,
                    request.EstimatedResolutionTime,
                    request.Message);

                // Get equipment name for notifications
                string equipmentName = result.Name;

                // Notify staff about the updated timeline
                await _equipmentHubContext.Clients.Group("Staff").SendAsync("ReceiveResolutionUpdate",
                    result.ConditionLogId,
                    result.Status.ToString(),
                    request.EstimatedResolutionTime,
                    request.Message);

                // Notify affected customers
                var affectedCustomerIds = await _equipmentService.GetAffectedCustomerIdsAsync(id);
                foreach (var customerId in affectedCustomerIds)
                {
                    await _equipmentHubContext.Clients.User(customerId.ToString()).SendAsync("ReceiveEquipmentUpdate",
                        result.ConditionLogId,
                        equipmentName,
                        result.Status.ToString(),
                        request.EstimatedResolutionTime,
                        request.Message);
                }

                return Ok(ApiResponse<ConditionLog>.SuccessResponse(result, "Resolution timeline updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ConditionLog>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ConditionLog>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("failures/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ConditionLog>>> GetConditionLog(int id)
        {
            var conditionLog = await _equipmentService.GetConditionLogByIdAsync(id);
            if (conditionLog == null)
                return NotFound(ApiResponse<ConditionLog>.ErrorResponse($"Condition log with ID {id} not found"));

            return Ok(ApiResponse<ConditionLog>.SuccessResponse(conditionLog, "Condition log retrieved successfully"));
        }

        [HttpGet("failures/active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetActiveConditionLogs()
        {
            var conditionLogs = await _equipmentService.GetActiveConditionLogsAsync();
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Active condition logs retrieved successfully"));
        }

        [HttpGet("failures/status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetConditionLogsByStatus(MaintenanceStatus status)
        {
            var conditionLogs = await _equipmentService.GetConditionLogsByStatusAsync(status);
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, $"Condition logs with status {status} retrieved successfully"));
        }

        [HttpPost("failures/{id}/assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> AssignStaffToResolution(int id, [FromBody] AssignStaffRequest request)
        {
            try
            {
                var result = await _equipmentService.AssignStaffToResolutionAsync(id, request.StaffId);
                if (!result)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Condition log with ID {id} not found"));

                // Get the condition log for notification details
                var conditionLog = await _equipmentService.GetConditionLogByIdAsync(id);

                // Notify staff about the assignment
                await _equipmentHubContext.Clients.Group("Staff").SendAsync("ReceiveAssignmentUpdate",
                    id,
                    request.StaffId,
                    conditionLog.Name,
                    conditionLog.Status.ToString(),
                    DateTime.UtcNow);

                // Notify the specific staff member who was assigned
                await _equipmentHubContext.Clients.User(request.StaffId.ToString()).SendAsync("ReceiveNewAssignment",
                    id,
                    conditionLog.Name,
                    conditionLog.Description,
                    conditionLog.Status.ToString());

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Staff assigned to resolution successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost("failures/{id}/resolve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> MarkAsResolved(int id, [FromBody] ResolveEquipmentRequest request)
        {
            try
            {
                var result = await _equipmentService.MarkAsResolvedAsync(id, request.ResolutionNotes);
                if (!result)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Condition log with ID {id} not found"));

                // Get the condition log for notification details
                var conditionLog = await _equipmentService.GetConditionLogByIdAsync(id);

                // Notify staff about the resolution
                await _equipmentHubContext.Clients.Group("Staff").SendAsync("ReceiveResolutionComplete",
                    id,
                    conditionLog.Name,
                    request.ResolutionNotes,
                    DateTime.UtcNow);

                // Notify affected customers
                var affectedCustomerIds = await _equipmentService.GetAffectedCustomerIdsAsync(id);
                foreach (var customerId in affectedCustomerIds)
                {
                    await _equipmentHubContext.Clients.User(customerId.ToString()).SendAsync("ReceiveEquipmentResolved",
                        id,
                        conditionLog.Name,
                        "The equipment issue has been resolved. " + request.ResolutionNotes);
                }

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Equipment marked as resolved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("failures/customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLog>>>> GetCustomerAffectedEquipment(int customerId)
        {
            var conditionLogs = await _equipmentService.GetActiveConditionLogsAsync();
            return Ok(ApiResponse<IEnumerable<ConditionLog>>.SuccessResponse(conditionLogs, "Customer affected equipment retrieved successfully"));
        }

        [HttpPost("failures/notify-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> NotifyCustomerDirectly([FromBody] NotifyCustomerRequest request)
        {
            try
            {
                // Get the condition log for notification details
                var conditionLog = await _equipmentService.GetConditionLogByIdAsync(request.ConditionLogId);
                if (conditionLog == null)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Condition log with ID {request.ConditionLogId} not found"));

                // Send a direct notification to the customer
                await _equipmentHubContext.Clients.User(request.CustomerId.ToString()).SendAsync("ReceiveDirectNotification",
                    request.ConditionLogId,
                    conditionLog.Name,
                    request.Message,
                    request.EstimatedResolutionTime);

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Customer notified successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }
    }
}
