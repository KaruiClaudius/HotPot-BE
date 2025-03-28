using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/staff/replacement")]
    [ApiController]
    [Authorize(Roles = "Staff")]
    public class StaffReplacementController : ControllerBase
    {
        private readonly IReplacementRequestService _replacementService;
        private readonly IEquipmentService _equipmentService;
        private readonly IUserService _userService;
        private readonly IHubContext<EquipmentHub> _equipmentHubContext;

        public StaffReplacementController(
            IReplacementRequestService replacementService,
            IEquipmentService equipmentService,
            IUserService userService,
            IHubContext<EquipmentHub> equipmentHubContext)
        {
            _replacementService = replacementService;
            _equipmentService = equipmentService;
            _userService = userService;
            _equipmentHubContext = equipmentHubContext;
        }

        #region Assigned Replacements

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>>> GetAssignedReplacements()
        {
            try
            {
                // Get the current user's ID from the claims using the "uid" claim type
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                {
                    return Unauthorized(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse(
                        "User ID not found in claims"));
                }

                if (!int.TryParse(userIdClaim.Value, out var userId))
                {
                    return BadRequest(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse(
                        "Invalid user identity format"));
                }

                var staff = await _userService.GetByIdAsync(userId);

                if (staff == null)
                    return BadRequest(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse("User is not a staff member"));

                var requests = await _replacementService.GetAssignedReplacementRequestsAsync(staff.UserId);
                var dtos = requests.Select(MapToSummaryDto).ToList();

                return Ok(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.SuccessResponse(
                    dtos, "Assigned replacement requests retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse(
                    $"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> GetReplacementRequestById(int id)
        {
            try
            {
                // Get the current user's ID from the claims using the "uid" claim type
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                {
                    return Unauthorized(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                        "User ID not found in claims"));
                }

                if (!int.TryParse(userIdClaim.Value, out var userId))
                {
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                        "Invalid user identity format"));
                }

                var staff = await _userService.GetByIdAsync(userId);

                if (staff == null)
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("User is not a staff member"));

                var request = await _replacementService.GetReplacementRequestByIdAsync(id);

                if (request == null)
                    return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

                // Ensure the staff is assigned to this request
                if (request.AssignedStaffId != staff.UserId)
                    return Forbid();

                var dto = MapToDetailDto(request);

                return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                    dto, "Replacement request retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                    $"An error occurred: {ex.Message}"));
            }
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> UpdateReplacementStatus(
            int id, [FromBody] UpdateReplacementStatusDto updateDto)
        {
            try
            {
                // Get the current user's ID from the claims using the "uid" claim type
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                {
                    return Unauthorized(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                        "User ID not found in claims"));
                }

                if (!int.TryParse(userIdClaim.Value, out var userId))
                {
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                        "Invalid user identity format"));
                }

                var staff = await _userService.GetByIdAsync(userId);

                if (staff == null)
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("User is not a staff member"));

                var request = await _replacementService.GetReplacementRequestByIdAsync(id);

                if (request == null)
                    return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

                // Ensure the staff is assigned to this request
                if (request.AssignedStaffId != staff.UserId)
                    return Forbid();

                var updatedRequest = await _replacementService.UpdateReplacementStatusAsync(
                    id, updateDto.Status, updateDto.Notes);

                var dto = MapToDetailDto(updatedRequest);

                // Notify managers about the status update
                await _equipmentHubContext.Clients.Group("Managers").SendAsync("ReceiveReplacementStatusUpdate",
                    id,
                    updateDto.Status.ToString(),
                    updateDto.Notes,
                    staff.UserId,
                    $"{staff.Name}");

                // Notify the customer if applicable
                if (dto.CustomerId != 0)
                {
                    await _equipmentHubContext.Clients.User(dto.CustomerId.ToString()).SendAsync("ReceiveReplacementUpdate",
                        id,
                        dto.EquipmentName,
                        updateDto.Status.ToString(),
                        updateDto.Notes);
                }

                return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                    dto, "Replacement request status updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpPut("{id}/complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> CompleteReplacement(
            int id, [FromBody] CompleteReplacementDto completeDto)
        {
            try
            {
                // Get the current user's ID from the claims using the "uid" claim type
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                {
                    return Unauthorized(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                        "User ID not found in claims"));
                }

                if (!int.TryParse(userIdClaim.Value, out var userId))
                {
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(
                        "Invalid user identity format"));
                }

                var staff = await _userService.GetByIdAsync(userId);

                if (staff == null)
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("User is not a staff member"));

                var request = await _replacementService.GetReplacementRequestByIdAsync(id);

                if (request == null)
                    return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

                // Ensure the staff is assigned to this request
                if (request.AssignedStaffId != staff.UserId)
                    return Forbid();

                var updatedRequest = await _replacementService.MarkReplacementAsCompletedAsync(
                    id, completeDto.CompletionNotes);

                var dto = MapToDetailDto(updatedRequest);

                // Notify managers about the completion
                await _equipmentHubContext.Clients.Group("Managers").SendAsync("ReceiveReplacementComplete",
                    id,
                    dto.EquipmentName,
                    completeDto.CompletionNotes,
                    staff.UserId,
                    $"{staff.Name}");

                // Notify the customer if applicable
                if (dto.CustomerId != 0)
                {
                    await _equipmentHubContext.Clients.User(dto.CustomerId.ToString()).SendAsync("ReceiveReplacementComplete",
                        id,
                        dto.EquipmentName,
                        "Your equipment has been replaced successfully. " + completeDto.CompletionNotes);
                }

                return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                    dto, "Replacement request completed successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
        }

        #endregion

        #region Equipment Failure Logging

        [HttpPost("failures")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ConditionLogDto>>> LogEquipmentFailure([FromBody] EquipmentFailureDto failureDto)
        {
            try
            {
                // Get the current user's ID from the claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
                {
                    return Unauthorized(ApiResponse<ConditionLogDto>.ErrorResponse("User ID not found in claims"));
                }

                // Validate that exactly one equipment type is specified
                bool hasUtensil = failureDto.UtensilID.HasValue && failureDto.UtensilID.Value > 0;
                bool hasHotPot = failureDto.HotPotInventoryId.HasValue && failureDto.HotPotInventoryId.Value > 0;

                if ((!hasUtensil && !hasHotPot) || (hasUtensil && hasHotPot))
                {
                    return BadRequest(ApiResponse<ConditionLogDto>.ErrorResponse(
                        "Exactly one equipment type (either UtensilId or HotPotInventoryId) must be specified with a valid ID"));
                }

                var result = await _equipmentService.LogEquipmentFailureAsync(failureDto);

                // Notify managers about the new equipment failure
                await _equipmentHubContext.Clients.Group("Managers").SendAsync("ReceiveNewFailure",
                    result.DamageDeviceId,
                    result.Name,
                    result.Description,
                    result.Status,
                    result.LoggedDate);

                return CreatedAtAction(nameof(GetConditionLog), new { id = result.DamageDeviceId },
                    ApiResponse<ConditionLogDto>.SuccessResponse(result, "Equipment failure logged successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ConditionLogDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("failures/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ConditionLogDetailDto>>> GetConditionLog(int id)
        {
            var conditionLog = await _equipmentService.GetConditionLogByIdAsync(id);
            if (conditionLog == null)
                return NotFound(ApiResponse<ConditionLogDetailDto>.ErrorResponse($"Condition log with ID {id} not found"));

            return Ok(ApiResponse<ConditionLogDetailDto>.SuccessResponse(conditionLog, "Condition log retrieved successfully"));
        }

        [HttpGet("failures/active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConditionLogDto>>>> GetActiveConditionLogs()
        {
            var conditionLogs = await _equipmentService.GetActiveConditionLogsAsync();
            return Ok(ApiResponse<IEnumerable<ConditionLogDto>>.SuccessResponse(conditionLogs, "Active condition logs retrieved successfully"));
        }

        [HttpPost("failures/{id}/verify")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ConditionLogDto>>> VerifyEquipmentFailure(
            int id, [FromBody] VerifyEquipmentDto verifyDto)
        {
            try
            {
                // Get the current user's ID from the claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
                {
                    return Unauthorized(ApiResponse<ConditionLogDto>.ErrorResponse("User ID not found in claims"));
                }

                // Verify the equipment failure
                var result = await _equipmentService.VerifyEquipmentFailureAsync(id, verifyDto.IsVerified, verifyDto.VerificationNotes, userId);

                if (result == null)
                    return NotFound(ApiResponse<ConditionLogDto>.ErrorResponse($"Condition log with ID {id} not found"));

                // Notify managers about the verification
                await _equipmentHubContext.Clients.Group("Managers").SendAsync("ReceiveFailureVerification",
                    id,
                    verifyDto.IsVerified,
                    verifyDto.VerificationNotes,
                    userId);

                return Ok(ApiResponse<ConditionLogDto>.SuccessResponse(result,
                    verifyDto.IsVerified ? "Equipment failure verified" : "Equipment failure not verified"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ConditionLogDto>.ErrorResponse(ex.Message));
            }
        }

        #endregion

        #region Helper Methods

        private ReplacementRequestSummaryDto MapToSummaryDto(ReplacementRequest request)
        {
            string equipmentName = "";

            if (request.EquipmentType == EquipmentType.HotPot && request.HotPotInventory != null)
            {
                equipmentName = request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }
            else if (request.EquipmentType == EquipmentType.Utensil && request.Utensil != null)
            {
                equipmentName = request.Utensil.Name;
            }

            return new ReplacementRequestSummaryDto
            {
                ReplacementRequestId = request.ReplacementRequestId,
                RequestReason = request.RequestReason,
                Status = request.Status,
                RequestDate = request.RequestDate,
                ReviewDate = request.ReviewDate,
                CompletionDate = request.CompletionDate,
                EquipmentType = request.EquipmentType,
                EquipmentName = equipmentName,
                CustomerName = request.Customer?.Name ?? "Unknown Customer",
                AssignedStaffName = request.AssignedStaff?.Name
            };
        }

        private ReplacementRequestDetailDto MapToDetailDto(ReplacementRequest request)
        {
            string equipmentName = "";

            if (request.EquipmentType == EquipmentType.HotPot && request.HotPotInventory != null)
            {
                equipmentName = request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }
            else if (request.EquipmentType == EquipmentType.Utensil && request.Utensil != null)
            {
                equipmentName = request.Utensil.Name;
            }

            return new ReplacementRequestDetailDto
            {
                ReplacementRequestId = request.ReplacementRequestId,
                RequestReason = request.RequestReason,
                AdditionalNotes = request.AdditionalNotes,
                Status = request.Status,
                RequestDate = request.RequestDate,
                ReviewDate = request.ReviewDate,
                ReviewNotes = request.ReviewNotes,
                CompletionDate = request.CompletionDate,
                EquipmentType = request.EquipmentType,

                // Set the EquipmentName property
                EquipmentName = equipmentName,

                CustomerId = request.CustomerId,
                CustomerName = request.Customer?.Name ?? "Unknown Customer",
                CustomerEmail = request.Customer?.Email ?? "Unknown Email",
                CustomerPhone = request.Customer?.PhoneNumber ?? "Unknown Phone",

                AssignedStaffId = request.AssignedStaffId,
                AssignedStaffName = request.AssignedStaff?.Name,

                HotPotInventoryId = request.HotPotInventoryId,
                HotPotSeriesNumber = request.HotPotInventory?.SeriesNumber,
                HotPotName = request.HotPotInventory?.Hotpot?.Name,

                UtensilId = request.UtensilId,
                UtensilName = request.Utensil?.Name,
                UtensilType = request.Utensil?.UtensilType?.Name
            };
        }

        #endregion
    }
}