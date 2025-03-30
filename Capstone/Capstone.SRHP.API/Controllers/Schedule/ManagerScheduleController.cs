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

        public ManagerScheduleController(
            IScheduleService scheduleService,
            IManagerService managerService,
            IStaffService staffService)
        {
            _scheduleService = scheduleService;
            _managerService = managerService;
            _staffService = staffService;
        }

        /// <summary>
        /// Get the current manager's work schedule
        /// </summary>
        [HttpGet("my-schedule")]
        public async Task<ActionResult<IEnumerable<WorkShiftDto>>> GetMySchedule()
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
                var shiftDtos = shifts.Adapt<List<WorkShiftDto>>();

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
                        Staff = staff.Adapt<StaffDto>(),
                        WorkShifts = shifts.Adapt<List<WorkShiftDto>>()
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
                    Staff = staff.Adapt<StaffDto>(),
                    WorkShifts = shifts.Adapt<List<WorkShiftDto>>()
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
                // Get all staff members
                var allStaff = await _staffService.GetAllStaffAsync();

                // Filter staff members who work on the specified day
                var staffOnDay = allStaff.Where(s => (s.WorkDays & day) != 0).ToList();

                var staffDtos = staffOnDay.Adapt<List<StaffDto>>();

                return Ok(staffDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get work shifts for a specific day
        /// </summary>
        [HttpGet("shifts-by-day")]
        public async Task<ActionResult<IEnumerable<WorkShiftDto>>> GetShiftsByDay([FromQuery] WorkDays day)
        {
            try
            {
                // Get all work shifts
                var allShifts = await _scheduleService.GetAllWorkShiftsAsync();

                // Filter shifts that occur on the specified day
                var shiftsOnDay = allShifts.Where(s => (s.DaysOfWeek & day) != 0).ToList();
                var shiftDtos = shiftsOnDay.Adapt<List<WorkShiftDto>>();

                return Ok(shiftDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}