using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/staff-assignment-history")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerStaffAssignmentHistory : ControllerBase
    {
        private readonly IStaffAssignmentService _staffAssignmentService;

        public ManagerStaffAssignmentHistory(
            IStaffAssignmentService staffAssignmentService)
        {
            _staffAssignmentService = staffAssignmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<StaffAssignmentHistoryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMyStaffAssignments(
    [FromQuery] StaffAssignmentHistoryFilterRequest filter)
        {
            var userIdClaim = User.FindFirst(AuthenTools.ClaimTypes.UserId);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int managerId))
            {
                return Unauthorized(new ApiErrorResponse
                {
                    Status = "Unauthorized",
                    Message = "User ID not found in token or is invalid"
                });
            }

            var result = await _staffAssignmentService.GetStaffAssignmentHistoryAsync(filter, managerId);
            return Ok(result);
        }

    }
}
