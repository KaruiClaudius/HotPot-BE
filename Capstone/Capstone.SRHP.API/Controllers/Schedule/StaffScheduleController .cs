using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemClaimTypes = System.Security.Claims.ClaimTypes;


namespace Capstone.HPTY.API.Controllers.Schedule
{
    [Route("api/staff/schedule")]
    [ApiController]
    [Authorize(Roles = "Staff")]

    public class StaffScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IUserService _userService;
        private readonly IStaffService _staffService;


        public StaffScheduleController(
            IScheduleService scheduleService,
            IUserService userService,
            IStaffService staffService)
        {
            _scheduleService = scheduleService;
            _userService = userService;
            _staffService = staffService;

        }

        /// <summary>
        /// Get the current staff member's work schedule
        /// </summary>
        [HttpGet("my-schedule")]
        public async Task<ActionResult<IEnumerable<WorkShiftDto>>> GetMySchedule()
        {
            try
            {
                // Get the current user's ID from the claims
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                // Find the staff ID associated with this user ID
                var staff = await _staffService.GetStaffByUserIdAsync(userId);
                if (staff == null)
                    return NotFound($"Staff record not found for user ID {userId}");

                var shifts = await _scheduleService.GetStaffWorkShiftsAsync(staff.StaffId);
                var shiftDtos = shifts.Adapt<IEnumerable<WorkShiftDto>>();
                return Ok(shiftDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
