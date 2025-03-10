using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Schedule
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IHubContext<ScheduleHub> _scheduleHubContext;

        public AdminScheduleController(IScheduleService scheduleService, IHubContext<ScheduleHub> scheduleHubContext)
        {
            _scheduleService = scheduleService;
            _scheduleHubContext = scheduleHubContext;
        }


        /// <summary>
        /// Get all work shifts
        /// </summary>
        [HttpGet("shifts")]
        public async Task<ActionResult<IEnumerable<WorkShiftDto>>> GetAllWorkShifts()
        {
            try
            {
                var shifts = await _scheduleService.GetAllWorkShiftsAsync();
                return Ok(shifts.ToList().Adapt<List<WorkShiftDto>>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get work shift by ID
        /// </summary>
        [HttpGet("shifts/{shiftId}")]
        public async Task<ActionResult<WorkShiftDto>> GetWorkShiftById(int shiftId)
        {
            try
            {
                var shift = await _scheduleService.GetWorkShiftByIdAsync(shiftId);
                if (shift == null)
                    return NotFound($"Work shift with ID {shiftId} not found");

                return Ok(shift.Adapt<WorkShiftDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create a new work shift
        /// </summary>
        [HttpPost("shifts")]
        public async Task<ActionResult<WorkShiftDto>> CreateWorkShift([FromBody] CreateWorkShiftDto createDto)
        {
            try
            {
                var workShift = new WorkShift
                {
                    ShiftStartTime = createDto.ShiftStartTime,
                    DaysOfWeek = createDto.DaysOfWeek,
                    Status = Enum.Parse<AttendanceStatus>(createDto.Status ?? "Scheduled")
                };

                var createdShift = await _scheduleService.CreateWorkShiftAsync(workShift);

                // Notify all managers about the new shift
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return CreatedAtAction(nameof(GetWorkShiftById), new { shiftId = createdShift.Id }, createdShift.Adapt<WorkShiftDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update an existing work shift
        /// </summary>
        [HttpPut("shifts/{shiftId}")]
        public async Task<ActionResult<WorkShiftDto>> UpdateWorkShift(int shiftId, [FromBody] UpdateWorkShiftDto updateDto)
        {
            try
            {
                var status = string.IsNullOrEmpty(updateDto.Status)
                    ? (AttendanceStatus?)null
                    : Enum.Parse<AttendanceStatus>(updateDto.Status);

                var updatedShift = await _scheduleService.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.DaysOfWeek,
                    status);

                // Get the staff members assigned to this shift
                var staffMembers = updatedShift.Staff;
                if (staffMembers != null)
                {
                    foreach (var staff in staffMembers)
                    {
                        // Notify each staff member about their schedule update
                        await _scheduleHubContext.Clients.Group($"Staff_{staff.StaffId}").SendAsync(
                            "ReceiveScheduleUpdate",
                            staff.StaffId,
                            DateTime.Now);
                    }
                }

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return Ok(updatedShift.Adapt<WorkShiftDto>());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a work shift
        /// </summary>
        [HttpDelete("shifts/{shiftId}")]
        public async Task<ActionResult> DeleteWorkShift(int shiftId)
        {
            try
            {
                // Get the shift before deleting to know which staff members to notify
                var shift = await _scheduleService.GetWorkShiftByIdAsync(shiftId);
                if (shift == null)
                    return NotFound($"Work shift with ID {shiftId} not found");

                var staffMembers = shift.Staff;

                var result = await _scheduleService.DeleteWorkShiftAsync(shiftId);
                if (!result)
                    return NotFound($"Work shift with ID {shiftId} not found");

                // Notify staff members about the deleted shift
                if (staffMembers != null)
                {
                    foreach (var staff in staffMembers)
                    {
                        await _scheduleHubContext.Clients.Group($"Staff_{staff.StaffId}").SendAsync(
                            "ReceiveScheduleUpdate",
                            staff.StaffId,
                            DateTime.Now);
                    }
                }

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Assign work days to a staff member
        /// </summary>
        [HttpPost("staff/assign-workdays")]
        public async Task<ActionResult<StaffDto>> AssignStaffWorkDays([FromBody] AssignStaffWorkDaysDto assignDto)
        {
            try
            {
                var staff = await _scheduleService.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays);

                // Notify the staff member about their schedule update
                await _scheduleHubContext.Clients.Group($"Staff_{staff.StaffId}").SendAsync(
                    "ReceiveScheduleUpdate",
                    staff.StaffId,
                    DateTime.Now);

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return Ok(staff.Adapt<StaffDto>());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Assign work days and shifts to a manager
        /// </summary>
        [HttpPost("managers/assign-workdays-shifts")]
        public async Task<ActionResult<ManagerDto>> AssignManagerWorkDaysAndShifts([FromBody] AssignManagerWorkDaysAndShiftsDto assignDto)
        {
            try
            {
                // Get all the work shifts by IDs
                var workShifts = new List<WorkShift>();
                foreach (var shiftId in assignDto.WorkShiftIds)
                {
                    var shift = await _scheduleService.GetWorkShiftByIdAsync(shiftId);
                    if (shift == null)
                        return NotFound($"Work shift with ID {shiftId} not found");
                    workShifts.Add(shift);
                }

                var manager = await _scheduleService.AssignManagerWorkDaysAndShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    workShifts);

                // Notify the manager about their schedule update
                await _scheduleHubContext.Clients.Group($"Manager_{manager.ManagerId}").SendAsync(
                    "ReceiveScheduleUpdate",
                    manager.ManagerId,
                    DateTime.Now);

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return Ok(manager.Adapt<ManagerDto>());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// Manually send a notification to all users about schedule updates
        /// </summary>
        [HttpPost("notify-all")]
        public async Task<ActionResult> NotifyAllUsers()
        {
            try
            {
                // Notify all managers about schedule updates
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                // Notify all staff members about schedule updates
                await _scheduleHubContext.Clients.Group("Staff").SendAsync("ReceiveAllScheduleUpdates");

                return Ok(new { message = "Notifications sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Manually send a notification to a specific staff member
        /// </summary>
        [HttpPost("notify-staff/{staffId}")]
        public async Task<ActionResult> NotifyStaff(int staffId)
        {
            try
            {
                // Notify the specific staff member about their schedule update
                await _scheduleHubContext.Clients.Group($"Staff_{staffId}").SendAsync(
                    "ReceiveScheduleUpdate",
                    staffId,
                    DateTime.Now);

                return Ok(new { message = $"Notification sent to staff {staffId}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

