using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Capstone.HPTY.API.Controllers.Schedule
{
    [Route("api/staff/schedule")]
    [ApiController]
    [Authorize(Roles = "Staff")]

    public class StaffScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IStaffService _staffService;


        public StaffScheduleController(
            IScheduleService scheduleService,
            IStaffService staffService)
        {
            _scheduleService = scheduleService;
            _staffService = staffService;
        }

        /// <summary>
        /// Get the current staff member's work schedule
        /// </summary>
        [HttpGet("my-schedule")]
        public async Task<ActionResult<StaffScheduleDto>> GetMySchedule()
        {
            try
            {
                // Get the current user's ID from the claims
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                // Find the staff member
                var staff = await _staffService.GetStaffByIdAsync(userId);
                if (staff == null)
                    return NotFound($"Staff record not found for user ID {userId}");

                // Create a staff DTO with work days
                var staffDto = new StaffSDto
                {
                    UserId = staff.UserId,
                    Name = staff.Name,
                    Email = staff.Email,
                    DaysOfWeek = staff.WorkDays ?? WorkDays.None
                };

                var staffSchedule = new StaffScheduleDto
                {
                    Staff = staffDto
                };

                return Ok(staffSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
