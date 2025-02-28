using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]

    public class ManagerReplacementController : ControllerBase
    {
        private readonly IReplacementRequestService _replacementService;

        public ManagerReplacementController(IReplacementRequestService replacementService)
        {
            _replacementService = replacementService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>>> GetAllReplacementRequests()
        {
            var requests = await _replacementService.GetAllReplacementRequestsAsync();
            var dtos = requests.Select(MapToSummaryDto).ToList();

            return Ok(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.SuccessResponse(
                dtos, "Replacement requests retrieved successfully"));
        }

        [HttpGet("status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>>> GetReplacementRequestsByStatus(ReplacementRequestStatus status)
        {
            if (!Enum.IsDefined(typeof(ReplacementRequestStatus), status))
                return BadRequest(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse("Invalid status value"));

            var requests = await _replacementService.GetReplacementRequestsByStatusAsync(status);
            var dtos = requests.Select(MapToSummaryDto).ToList();

            return Ok(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.SuccessResponse(
                dtos, $"Replacement requests with status '{status}' retrieved successfully"));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> GetReplacementRequestById(int id)
        {
            var request = await _replacementService.GetReplacementRequestByIdAsync(id);

            if (request == null)
                return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Replacement request with ID {id} not found"));

            var dto = MapToDetailDto(request);

            return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                dto, "Replacement request retrieved successfully"));
        }

        [HttpPut("{id}/review")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> ReviewReplacementRequest(
            int id, [FromBody] ReviewReplacementRequestDto reviewDto)
        {
            try
            {
                var request = await _replacementService.ReviewReplacementRequestAsync(
                    id, reviewDto.IsApproved, reviewDto.ReviewNotes);

                var dto = MapToDetailDto(request);

                return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                    dto, $"Replacement request {(reviewDto.IsApproved ? "approved" : "rejected")} successfully"));
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

        [HttpPut("{id}/assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> AssignStaffToReplacement(
            int id, [FromBody] AssignStaffDto assignDto)
        {
            try
            {
                var request = await _replacementService.AssignStaffToReplacementAsync(
                    id, assignDto.StaffId);

                var dto = MapToDetailDto(request);

                return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                    dto, "Staff assigned to replacement request successfully"));
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> MarkReplacementAsCompleted(
            int id, [FromBody] CompleteReplacementDto completeDto)
        {
            try
            {
                var request = await _replacementService.MarkReplacementAsCompletedAsync(
                    id, completeDto.CompletionNotes);

                var dto = MapToDetailDto(request);

                return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                    dto, "Replacement request marked as completed successfully"));
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

        [HttpGet("dashboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<ReplacementDashboardDto>>> GetReplacementDashboard()
        {
            var allRequests = await _replacementService.GetAllReplacementRequestsAsync();

            var dashboard = new ReplacementDashboardDto
            {
                TotalRequests = allRequests.Count(),
                PendingRequests = allRequests.Count(r => r.Status == ReplacementRequestStatus.Pending),
                ApprovedRequests = allRequests.Count(r => r.Status == ReplacementRequestStatus.Approved),
                InProgressRequests = allRequests.Count(r => r.Status == ReplacementRequestStatus.InProgress),
                CompletedRequests = allRequests.Count(r => r.Status == ReplacementRequestStatus.Completed),
                RejectedRequests = allRequests.Count(r => r.Status == ReplacementRequestStatus.Rejected),
                CancelledRequests = allRequests.Count(r => r.Status == ReplacementRequestStatus.Cancelled),

                HotPotRequests = allRequests.Count(r => r.EquipmentType == EquipmentType.HotPot),
                UtensilRequests = allRequests.Count(r => r.EquipmentType == EquipmentType.Utensil),

                RecentRequests = allRequests
                    .OrderByDescending(r => r.RequestDate)
                    .Take(5)
                    .Select(MapToSummaryDto)
                    .ToList()
            };

            return Ok(ApiResponse<ReplacementDashboardDto>.SuccessResponse(
                dashboard, "Replacement dashboard data retrieved successfully"));
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

