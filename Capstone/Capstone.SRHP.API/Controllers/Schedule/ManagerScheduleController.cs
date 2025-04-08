using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.User;
// Use the fully qualified name for System.Security.Claims.ClaimTypes
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly INotificationService _notificationService;

        public ManagerScheduleController(
            IScheduleService scheduleService,
            IManagerService managerService,
            IStaffService staffService,
            INotificationService notificationService)
        {
            _scheduleService = scheduleService;
            _managerService = managerService;
            _staffService = staffService;
            _notificationService = notificationService;
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

                // Get the manager's work shifts
                var shifts = await _scheduleService.GetManagerWorkShiftsAsync(userId);

                if (shifts == null || !shifts.Any())
                {
                    return Ok(new List<ManagerWorkShiftDto>());
                }

                // Get the manager to access their WorkDays
                var manager = await _managerService.GetManagerByIdAsync(userId);

                // Manually map to DTO to ensure all properties are correctly mapped
                var shiftDtos = shifts.Select(shift => new ManagerWorkShiftDto
                {
                    WorkShiftId = shift.WorkShiftId,
                    ShiftStartTime = shift.ShiftStartTime ?? TimeSpan.Zero,
                    ShiftEndTime = shift.ShiftEndTime ?? TimeSpan.Zero,
                    ShiftName = shift.ShiftName,
                    // Set DaysOfWeek from the manager's WorkDays if available
                    DaysOfWeek = manager?.WorkDays ?? WorkDays.None,
                    // Filter the Managers collection to only include the current manager
                    Managers = shift.Managers?
                        .Where(m => m.UserId == userId)
                        .Select(m => new ManagerSDto
                        {
                            UserId = m.UserId,
                            Name = m.Name,
                            Email = m.Email,
                        })
                        .ToList() ?? new List<ManagerSDto>()
                }).ToList();

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

                if (staffMembers == null || !staffMembers.Any())
                {
                    return Ok(new List<StaffScheduleDto>());
                }

                var staffSchedules = new List<StaffScheduleDto>();

                foreach (var staff in staffMembers)
                {
                    // Get the staff member's shifts
                    var shifts = await _scheduleService.GetStaffWorkShiftsAsync(staff.UserId);

                    // Create a staff DTO with work shifts
                    var staffDto = new StaffSDto
                    {
                        UserId = staff.UserId,
                        Name = staff.Name,
                        Email = staff.Email,
                        DaysOfWeek = staff.WorkDays ?? WorkDays.None
                    };

                    staffSchedules.Add(new StaffScheduleDto
                    {
                        Staff = staffDto
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

                // Create a staff DTO with work shifts
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

        /// <summary>
        /// Get staff members working on a specific day
        /// </summary>
        [HttpGet("staff-by-day")]
        public async Task<ActionResult<IEnumerable<StaffSDto>>> GetStaffByDay([FromQuery] WorkDays day = WorkDays.None)
        {
            try
            {
                // Get all staff members
                var allStaff = await _staffService.GetAllStaffAsync();

                // If day is None (0), return all staff members
                if (day == WorkDays.None)
                {
                    // Map all staff to DTOs
                    var allStaffDtos = allStaff.Select(s => new StaffSDto
                    {
                        UserId = s.UserId,
                        Name = s.Name,
                        Email = s.Email,
                        DaysOfWeek = s.WorkDays.GetValueOrDefault()
                    }).ToList();

                    return Ok(allStaffDtos);
                }

                // Filter staff members who work on the specified day
                // Safely handle null WorkDays values
                var staffOnDay = allStaff.Where(s =>
                    s.WorkDays.HasValue && // Check if WorkDays has a value
                    (s.WorkDays.Value & day) != 0 // Use .Value to safely access the value
                ).ToList();

                // Map filtered staff to DTOs
                var staffDtos = staffOnDay.Select(s => new StaffSDto
                {
                    UserId = s.UserId,
                    Name = s.Name,
                    Email = s.Email,
                    DaysOfWeek = s.WorkDays.GetValueOrDefault()
                }).ToList();

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
        public async Task<ActionResult<ApiResponse<StaffSDto>>> AssignStaffWorkDays([FromBody] AssignStaffWorkDaysDto assignDto)
        {
            try
            {
                // Validate request
                if (assignDto == null || assignDto.StaffId <= 0)
                {
                    return BadRequest(ApiResponse<StaffSDto>.ErrorResponse("Staff ID is required"));
                }

                // Note: We're allowing WorkDays.None as a valid value to clear the schedule
                var staff = await _scheduleService.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays);

                // Notify the staff member about their schedule update
                await _notificationService.NotifyScheduleUpdate(staff.UserId, DateTime.Now);

                // Also notify all staff about schedule updates
                await _notificationService.NotifyAllScheduleUpdates();

                // Manually map the staff entity to StaffSDto
                var staffDto = new StaffSDto
                {
                    UserId = staff.UserId,
                    Name = staff.Name,
                    Email = staff.Email,
                    DaysOfWeek = staff.WorkDays.GetValueOrDefault()
                };

                return Ok(ApiResponse<StaffSDto>.SuccessResponse(
                    staffDto, $"Work days assigned to {staff.Name} successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<StaffSDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<StaffSDto>.ErrorResponse(ex.Message));
            }
        }

    }
}