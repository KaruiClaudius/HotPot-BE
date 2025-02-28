using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Staff")]

    public class StaffReplacementController : ControllerBase
    {
        private readonly IReplacementRequestService _replacementService;
        private readonly IUserService _userService;

        public StaffReplacementController(
            IReplacementRequestService replacementService,
            IUserService userService)
        {
            _replacementService = replacementService;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>>> GetAssignedReplacements()
        {
            // Get the current staff ID from the authenticated user
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var staff = await _userService.GetByIdAsync(userId);

            if (staff == null)
                return BadRequest(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse("User is not a staff member"));

            var requests = await _replacementService.GetAssignedReplacementRequestsAsync(staff.Staff.StaffId);
            var dtos = requests.Select(MapToSummaryDto).ToList();

            return Ok(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.SuccessResponse(
                dtos, "Assigned replacement requests retrieved successfully"));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> GetReplacementRequestById(int id)
        {
            // Get the current staff ID from the authenticated user
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var staff = await _userService.GetByIdAsync(userId);

            if (staff == null)
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("User is not a staff member"));

            var request = await _replacementService.GetReplacementRequestByIdAsync(id);

            if (request == null)
                return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

            // Ensure the staff is assigned to this request
            if (request.AssignedStaffId != staff.Staff.StaffId)
                return Forbid();

            var dto = MapToDetailDto(request);

            return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                dto, "Replacement request retrieved successfully"));
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
                // Get the current staff ID from the authenticated user
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var staff = await _userService.GetByIdAsync(userId);

                if (staff == null)
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("User is not a staff member"));

                var request = await _replacementService.GetReplacementRequestByIdAsync(id);

                if (request == null)
                    return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

                // Ensure the staff is assigned to this request
                if (request.AssignedStaffId != staff.Staff.StaffId)
                    return Forbid();

                var updatedRequest = await _replacementService.UpdateReplacementStatusAsync(
                    id, updateDto.Status, updateDto.Notes);

                var dto = MapToDetailDto(updatedRequest);

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
                // Get the current staff ID from the authenticated user
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var staff = await _userService.GetByIdAsync(userId);

                if (staff == null)
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("User is not a staff member"));

                var request = await _replacementService.GetReplacementRequestByIdAsync(id);

                if (request == null)
                    return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

                // Ensure the staff is assigned to this request
                if (request.AssignedStaffId != staff.Staff.StaffId)
                    return Forbid();

                var updatedRequest = await _replacementService.MarkReplacementAsCompletedAsync(
                    id, completeDto.CompletionNotes);

                var dto = MapToDetailDto(updatedRequest);

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
                CustomerName = request.Customer?.User?.Name ?? "Unknown Customer",
                AssignedStaffName = request.AssignedStaff?.User?.Name
            };
        }

        private ReplacementRequestDetailDto MapToDetailDto(ReplacementRequest request)
        {
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

                CustomerId = request.CustomerId,
                CustomerName = request.Customer?.User?.Name ?? "Unknown Customer",
                CustomerEmail = request.Customer?.User?.Email ?? "Unknown Email",
                CustomerPhone = request.Customer?.User?.PhoneNumber ?? "Unknown Phone",

                AssignedStaffId = request.AssignedStaffId,
                AssignedStaffName = request.AssignedStaff?.User?.Name,

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
