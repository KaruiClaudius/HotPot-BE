using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Use the fully qualified name for System.Security.Claims.ClaimTypes
using SystemClaimTypes = System.Security.Claims.ClaimTypes;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.API.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Schedule
{
    [Route("api/manager/schedule")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IManagerService _managerService;
        private readonly IStaffService _staffService;
        private readonly IHubContext<ScheduleHub> _scheduleHubContext;


        public ManagerScheduleController(
            IScheduleService scheduleService,
            IManagerService managerService,
            IStaffService staffService,
            IHubContext<ScheduleHub> scheduleHubContext)
        {
            _scheduleService = scheduleService;
            _managerService = managerService;
            _staffService = staffService;
            _scheduleHubContext = scheduleHubContext;
        }

        /// <summary>
        /// Get the current manager's work schedule
        /// </summary>
        [HttpGet("my-schedule")]
        public async Task<ActionResult<IEnumerable<ManagerWorkShiftDto>>> GetMySchedule()
        {
            try
            {
                // Get the current user's ID from the claims
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                // Find the manager ID associated with this user ID
                var manager = await _managerService.GetManagerByIdAsync(userId);
                if (manager == null)
                    return NotFound($"Manager record not found for user ID {userId}");

                var shifts = await _scheduleService.GetManagerWorkShiftsAsync(userId);
                var shiftDtos = shifts.Adapt<List<ManagerWorkShiftDto>>();

                return Ok(shiftDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all staff schedules
        /// </summary>
        [HttpGet("staff-schedules")]
        public async Task<ActionResult<IEnumerable<StaffScheduleDto>>> GetAllStaffSchedules()
        {
            try
            {
                // Get all staff members
                var staffMembers = await _staffService.GetAllStaffAsync();

                var staffSchedules = new List<StaffScheduleDto>();

                foreach (var staff in staffMembers)
                {
                    var shifts = await _scheduleService.GetStaffWorkShiftsAsync(staff.UserId);

                    staffSchedules.Add(new StaffScheduleDto
                    {
                        Staff = staff.Adapt<StaffSDto>(),
                    });
                }

                return Ok(staffSchedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get schedule for a specific staff member
        /// </summary>
        [HttpGet("staff-schedules/{staffId}")]
        public async Task<ActionResult<StaffScheduleDto>> GetStaffSchedule(int staffId)
        {
            try
            {
                // Get the staff member
                var staff = await _staffService.GetStaffByIdAsync(staffId);
                if (staff == null)
                    return NotFound($"Staff with ID {staffId} not found");

                // Get the staff member's shifts
                var shifts = await _scheduleService.GetStaffWorkShiftsAsync(staffId);

                var staffSchedule = new StaffScheduleDto
                {
                    Staff = staff.Adapt<StaffSDto>(),
                };

                return Ok(staffSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get staff members working on a specific day
        /// </summary>
        [HttpGet("staff-by-day")]
        public async Task<ActionResult<IEnumerable<StaffDto>>> GetStaffByDay([FromQuery] WorkDays day)
        {
            try
            {
                // Validate the day parameter
                if (day == WorkDays.None)
                {
                    return Ok(Array.Empty<StaffDto>());
                }

                // Get all staff members
                var allStaff = await _staffService.GetAllStaffAsync();

                // Filter staff members who work on the specified day
                // Safely handle null WorkDays values
                var staffOnDay = allStaff.Where(s =>
                    s.WorkDays.HasValue && // Check if WorkDays has a value
                    (s.WorkDays.Value & day) != 0 // Use .Value to safely access the value
                ).ToList();

                var staffDtos = staffOnDay.Adapt<List<StaffDto>>();

                return Ok(staffDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Assign work days to a staff member
        /// </summary>
        [HttpPost("assign-staff")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> AssignStaffWorkDays([FromBody] AssignStaffWorkDaysDto assignDto)
        {
            try
            {
                // Validate request
                if (assignDto == null || assignDto.StaffId <= 0)
                {
                    return BadRequest("Staff ID and work days are required");
                }

                var staff = await _scheduleService.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays);

                // Notify the staff member about their schedule update
                await _scheduleHubContext.Clients.Group($"User_{staff.UserId}").SendAsync(
                    "ReceiveScheduleUpdate",
                    staff.UserId,
                    DateTime.Now);

                return Ok(staff.Adapt<UserDto>());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while assigning staff work days. Please try again later.");
            }
        }
    }
}