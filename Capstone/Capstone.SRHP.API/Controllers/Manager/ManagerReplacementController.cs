using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/replacement")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerReplacementController : ControllerBase
    {
        private readonly IReplacementRequestService _replacementService;
        private readonly INotificationService _notificationService;

        public ManagerReplacementController(
            IReplacementRequestService replacementService,
            INotificationService notificationService)
        {
            _replacementService = replacementService;
            _notificationService = notificationService;
        }


        #region Replacement Request Management

        [HttpGet("all")]
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

        [HttpGet("id/{id}")]
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

                // Notify staff about the review decision
                await _notificationService.NotifyReplacementStatusChangeAsync(request);

                // Notify the customer if applicable
                if (dto.CustomerId != 0)
                {
                    await _notificationService.NotifyCustomerAboutReplacementAsync(request);
                }

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

        #endregion

        #region Staff Allocation and Resolution Timeline

        [HttpPut("{id}/assign-staff")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> AssignStaffToReplacement(
         int id, [FromBody] AssignStaffRequest assignDto)
        {
            try
            {
                var request = await _replacementService.AssignStaffToReplacementAsync(
                    id, assignDto.StaffId);

                var dto = MapToDetailDto(request);

                // Notify staff about the assignment
                await _notificationService.NotifyReplacementStatusChangeAsync(request);

                // Notify the specific staff member who was assigned
                if (request.AssignedStaffId.HasValue)
                {
                    await _notificationService.NotifyStaffReplacementAssignmentAsync(
                        request.AssignedStaffId.Value,
                        request.ReplacementRequestId,
                        GetEquipmentName(request), // Use helper method
                        dto.RequestReason,
                        dto.Status.ToString());
                }

                // Notify the customer if applicable
                if (dto.CustomerId != 0)
                {
                    await _notificationService.NotifyCustomerAboutReplacementAsync(request);
                }

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

        [HttpPost("notify-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> NotifyCustomerDirectly([FromBody] NotifyCustomerRequest request)
        {
            try
            {
                // Validate the request
                if (request.CustomerId <= 0)
                {
                    return BadRequest(ApiResponse<bool>.ErrorResponse("Invalid customer ID"));
                }

                // Send a direct notification to the customer
                await _notificationService.NotifyCustomerDirectlyAsync(
                    request.CustomerId,
                    request.ConditionLogId,
                    request.Message,
                    request.EstimatedResolutionTime);

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Customer notified successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        #endregion

        #region Dashboard and Reporting

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

                // Count HotPot requests (those with HotPotInventoryId)
                HotPotRequests = allRequests.Count(r => r.HotPotInventoryId.HasValue),

                RecentRequests = allRequests
                    .OrderByDescending(r => r.RequestDate)
                    .Take(5)
                    .Select(MapToSummaryDto)
                    .ToList()
            };

            return Ok(ApiResponse<ReplacementDashboardDto>.SuccessResponse(
                dashboard, "Replacement dashboard data retrieved successfully"));
        }

        #endregion

        #region Helper Methods

        private string GetEquipmentName(ReplacementRequest request)
        {
            if (request.HotPotInventory != null)
            {
                return request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }
            return "Unknown Equipment";
        }

        private ReplacementRequestSummaryDto MapToSummaryDto(ReplacementRequest request)
        {
            string equipmentName = GetEquipmentName(request);

            return new ReplacementRequestSummaryDto
            {
                ReplacementRequestId = request.ReplacementRequestId,
                RequestReason = request.RequestReason,
                Status = request.Status,
                RequestDate = request.RequestDate,
                ReviewDate = request.ReviewDate,
                CompletionDate = request.CompletionDate,
                EquipmentName = equipmentName,
                CustomerName = request.Customer?.Name ?? "Unknown Customer",
                AssignedStaffName = request.AssignedStaff?.Name
            };
        }

        private ReplacementRequestDetailDto MapToDetailDto(ReplacementRequest request)
        {
            string equipmentName = GetEquipmentName(request);

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
                HotPotName = request.HotPotInventory?.Hotpot?.Name
            };
        }

        #endregion
    }
}