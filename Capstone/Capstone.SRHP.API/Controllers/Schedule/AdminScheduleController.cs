using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.HPTY.API.Controllers.Schedule
{
    [Route("api/admin/schedule")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly INotificationService _notificationService;

        public AdminScheduleController(
            IScheduleService scheduleService,
            INotificationService notificationService)
        {
            _scheduleService = scheduleService;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Get all work shifts
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [HttpGet("{shiftId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<WorkShiftDto>>> CreateWorkShift([FromBody] CreateWorkShiftDto createDto)
        {
            try
            {
                if (createDto == null)
                    return BadRequest(ApiResponse<WorkShiftDto>.ErrorResponse("Work shift data is required"));

                var workShift = new WorkShift
                {
                    ShiftStartTime = createDto.ShiftStartTime,
                    ShiftEndTime = createDto.ShiftEndTime,
                    ShiftName = createDto.ShiftName,
                    Staff = new List<User>(),
                    Managers = new List<User>()
                };

                var createdShift = await _scheduleService.CreateWorkShiftAsync(workShift);

                // Notify all managers about the new shift
                await _notificationService.NotifyRole(
                    "Managers",
                    "ScheduleUpdate",
                    "New Work Shift Created",
                    $"New work shift '{createdShift.ShiftName}' has been created: {createdShift.ShiftStartTime} - {createdShift.ShiftEndTime}",
                    new Dictionary<string, object>
                    {
                { "ShiftId", createdShift.WorkShiftId },
                { "ShiftName", createdShift.ShiftName },
                { "StartTime", createdShift.ShiftStartTime },
                { "EndTime", createdShift.ShiftEndTime },
                { "CreatedAt", DateTime.UtcNow },
                { "Action", "Created" }
                    });

                var shiftDto = createdShift.Adapt<WorkShiftDto>();
                return CreatedAtAction(
                    nameof(GetWorkShiftById),
                    new { shiftId = createdShift.WorkShiftId },
                    ApiResponse<WorkShiftDto>.SuccessResponse(shiftDto, "Work shift created successfully")
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<WorkShiftDto>.ErrorResponse(ex.Message));
            }
        }

        /// <summary>
        /// Update an existing work shift
        /// </summary>
        [HttpPut("{shiftId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<WorkShiftDto>>> UpdateWorkShift(int shiftId, [FromBody] UpdateWorkShiftDto updateDto)
        {
            try
            {
                // Validate request
                if (updateDto == null)
                {
                    return BadRequest(ApiResponse<WorkShiftDto>.ErrorResponse("Update data is required"));
                }

                var updatedShift = await _scheduleService.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.ShiftEndTime,
                    updateDto.ShiftName);

                // Get the updated shift with staff information
                var shiftWithStaff = await _scheduleService.GetWorkShiftByIdAsync(shiftId);


                // Notify staff members about their schedule update
                if (shiftWithStaff.Staff != null && shiftWithStaff.Staff.Any())
                {
                    foreach (var staff in shiftWithStaff.Staff)
                    {
                        // Notify each staff member about their schedule update
                        await _notificationService.NotifyUser(
                            staff.UserId,
                            "ScheduleUpdate",
                            "Work Shift Updated",
                            $"Your work shift '{updatedShift.ShiftName}' has been updated: {updatedShift.ShiftStartTime} - {updatedShift.ShiftEndTime}",
                            new Dictionary<string, object>
                            {
                        { "ShiftId", shiftId },
                        { "ShiftName", updatedShift.ShiftName },
                        { "NewStartTime", updatedShift.ShiftStartTime },
                        { "NewEndTime", updatedShift.ShiftEndTime },
                        { "UpdatedAt", DateTime.UtcNow },
                        { "Action", "Updated" }
                            });
                    }
                }

                // Notify all managers about the schedule update
                await _notificationService.NotifyRole(
                    "Managers",
                    "ScheduleUpdate",
                    "Work Shift Updated",
                    $"Work shift '{updatedShift.ShiftName}' has been updated: {updatedShift.ShiftStartTime} - {updatedShift.ShiftEndTime}",
                    new Dictionary<string, object>
                    {
                { "ShiftId", shiftId },
                { "ShiftName", updatedShift.ShiftName },
                { "NewStartTime", updatedShift.ShiftStartTime },
                { "NewEndTime", updatedShift.ShiftEndTime },
                { "StaffCount", shiftWithStaff.Staff?.Count ?? 0 },
                { "UpdatedAt", DateTime.UtcNow },
                { "Action", "Updated" }
                    });

                var shiftDto = updatedShift.Adapt<WorkShiftDto>();
                return Ok(ApiResponse<WorkShiftDto>.SuccessResponse(shiftDto, "Work shift updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<WorkShiftDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<WorkShiftDto>.ErrorResponse(
                    "An error occurred while updating the work shift. Please try again later."));
            }
        }

        /// <summary>
        /// Delete a work shift
        /// </summary>
        [HttpDelete("{shiftId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteWorkShift(int shiftId)
        {
            try
            {
                // Get the shift before deleting to know which staff members to notify
                var shift = await _scheduleService.GetWorkShiftByIdAsync(shiftId);
                if (shift == null)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Work shift with ID {shiftId} not found"));

                var staffMembers = shift.Staff;


                var result = await _scheduleService.DeleteWorkShiftAsync(shiftId);
                if (!result)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Work shift with ID {shiftId} not found"));

                // Notify staff members about the deleted shift
                if (staffMembers != null && staffMembers.Any())
                {
                    foreach (var staff in staffMembers)
                    {
                        await _notificationService.NotifyUser(
                            staff.UserId,
                            "ScheduleUpdate",
                            "Work Shift Deleted",
                            $"Your work shift '{shift.ShiftName}' ({shift.ShiftStartTime} - {shift.ShiftEndTime}) has been deleted",
                            new Dictionary<string, object>
                            {
                        { "ShiftId", shiftId },
                        { "ShiftName", shift.ShiftName },
                        { "StartTime", shift.ShiftStartTime },
                        { "EndTime", shift.ShiftEndTime },
                        { "DeletedAt", DateTime.UtcNow },
                        { "Action", "Deleted" }
                            });
                    }
                }

                // Notify all managers about the schedule update
                await _notificationService.NotifyRole(
                    "Managers",
                    "ScheduleUpdate",
                    "Work Shift Deleted",
                    $"Work shift '{shift.ShiftName}' ({shift.ShiftStartTime} - {shift.ShiftEndTime}) has been deleted",
                    new Dictionary<string, object>
                    {
                { "ShiftId", shiftId },
                { "ShiftName", shift.ShiftName },
                { "StartTime", shift.ShiftStartTime },
                { "EndTime", shift.ShiftEndTime },
                { "AffectedStaffCount", staffMembers?.Count ?? 0 },
                { "DeletedAt", DateTime.UtcNow },
                { "Action", "Deleted" }
                    });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.ErrorResponse(
                    "An error occurred while deleting the work shift. Please try again later."));
            }
        }


        /// <summary>
        /// Assign work days and shifts to a manager
        /// </summary>
        [HttpPost("assign-manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<ManagerDto>>> AssignManagerWorkDaysAndShifts([FromBody] AssignManagerWorkDaysAndShiftsDto assignDto)
        {
            try
            {
                // Validate request
                if (assignDto == null || assignDto.ManagerId <= 0)
                {
                    return BadRequest(ApiResponse<ManagerDto>.ErrorResponse("Manager ID is required"));
                }

                // WorkShiftIds can be null or empty, which might mean "remove all shifts"
                if (assignDto.WorkShiftIds == null)
                {
                    assignDto.WorkShiftIds = new List<int>(); // Empty list instead of null
                }

                // Note: We're allowing WorkDays.None as a valid value to clear the schedule
                var manager = await _scheduleService.AssignManagerToWorkShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    assignDto.WorkShiftIds);

                // Get the shifts assigned to the manager
                var shiftNames = manager.MangerWorkShifts?.Select(s => s.ShiftName).ToList() ?? new List<string>();
                string shiftSummary = shiftNames.Any() ? string.Join(", ", shiftNames) : "No shifts";

                // Get work days as readable text
                string workDaysText = GetWorkDaysText(manager.WorkDays.Value);

                // Notify the manager about their schedule update
                await _notificationService.NotifyUser(
                    manager.UserId,
                    "ScheduleUpdate",
                    "Your Schedule Has Been Updated",
                    $"Your work schedule has been updated: {workDaysText}, Shifts: {shiftSummary}",
                    new Dictionary<string, object>
                    {
                { "ManagerId", manager.UserId },
                { "WorkDays", manager.WorkDays },
                { "WorkDaysText", workDaysText },
                { "ShiftIds", assignDto.WorkShiftIds },
                { "ShiftNames", shiftNames },
                { "UpdatedAt", DateTime.UtcNow },
                { "Action", "ManagerAssigned" }
                    });

                // Notify all other managers about the schedule update
                await _notificationService.NotifyRole(
                    "Managers",
                    "ScheduleUpdate",
                    "Manager Schedule Updated",
                    $"Schedule for {manager.Name} has been updated: {workDaysText}, Shifts: {shiftSummary}",
                    new Dictionary<string, object>
                    {
                { "ManagerId", manager.UserId },
                { "ManagerName", manager.Name },
                { "WorkDays", manager.WorkDays },
                { "WorkDaysText", workDaysText },
                { "ShiftIds", assignDto.WorkShiftIds },
                { "ShiftNames", shiftNames },
                { "UpdatedAt", DateTime.UtcNow },
                { "Action", "ManagerAssigned" }
                    });

                // Create a custom ManagerDto with only the needed information
                var managerDto = new ManagerDto
                {
                    UserId = manager.UserId,
                    Name = manager.Name ?? string.Empty,
                    Email = manager.Email ?? string.Empty,
                    WorkDays = manager.WorkDays,
                    WorkShifts = manager.MangerWorkShifts.Select(ws => new WorkShiftSDto
                    {
                        WorkShiftId = ws.WorkShiftId,
                        ShiftName = ws.ShiftName ?? string.Empty,
                        ShiftStartTime = ws.ShiftStartTime,
                        ShiftEndTime = ws.ShiftEndTime
                    }).ToList()
                };

                return Ok(ApiResponse<ManagerDto>.SuccessResponse(managerDto, "Manager work days and shifts assigned successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<ManagerDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ManagerDto>.ErrorResponse(
                    "An error occurred while assigning manager work days and shifts. Please try again later."));
            }
        }

        /// <summary>
        /// Manually send a notification to all users about schedule updates
        /// </summary>
        //[HttpPost("notify-all")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ApiResponse<bool>>> NotifyAllUsers()
        //{
        //    try
        //    {
        //        // Get current schedule summary
        //        var shifts = await _scheduleService.GetAllWorkShiftsAsync();
        //        int shiftCount = shifts.Count();

        //        // Notify all staff about schedule updates
        //        await _notificationService.NotifyRole(
        //            "Staff",
        //            "ScheduleUpdate",
        //            "Schedule Update Available",
        //            "The work schedule has been updated. Please check your assignments.",
        //            new Dictionary<string, object>
        //            {
        //        { "UpdatedAt", DateTime.UtcNow },
        //        { "TotalShifts", shiftCount },
        //        { "Action", "ManualNotification" }
        //            });

        //        // Notify all managers about schedule updates
        //        await _notificationService.NotifyRole(
        //            "Managers",
        //            "ScheduleUpdate",
        //            "Schedule Update Available",
        //            "The work schedule has been updated. Please review the changes.",
        //            new Dictionary<string, object>
        //            {
        //        { "UpdatedAt", DateTime.UtcNow },
        //        { "TotalShifts", shiftCount },
        //        { "Action", "ManualNotification" }
        //            });

        //        return Ok(ApiResponse<bool>.SuccessResponse(true, "Notifications sent successfully"));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ApiResponse<bool>.ErrorResponse(ex.Message));
        //    }
        //}

        /// <summary>
        /// Manually send a notification to a specific staff member
        /// </summary>
        //[HttpPost("notify-staff/{staffId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ApiResponse<bool>>> NotifyStaff(int staffId)
        //{
        //    try
        //    {
        //        // Get staff member's shifts
        //        var staffShifts = await _scheduleService.GetStaffWorkShiftsAsync(staffId);
        //        var shiftNames = staffShifts.Select(s => s.ShiftName).ToList();
        //        string shiftSummary = shiftNames.Any() ? string.Join(", ", shiftNames) : "No shifts assigned";

        //        // Notify the specific staff member about their schedule
        //        await _notificationService.NotifyUser(
        //            staffId,
        //            "ScheduleUpdate",
        //            "Your Schedule Information",
        //            $"Your current work schedule: {shiftSummary}",
        //            new Dictionary<string, object>
        //            {
        //        { "StaffId", staffId },
        //        { "ShiftCount", staffShifts.Count() },
        //        { "ShiftNames", shiftNames },
        //        { "NotifiedAt", DateTime.UtcNow },
        //        { "Action", "ManualStaffNotification" }
        //            });

        //        return Ok(ApiResponse<bool>.SuccessResponse(true, $"Notification sent to staff {staffId}"));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ApiResponse<bool>.ErrorResponse(ex.Message));
        //    }
        //}

        private string GetWorkDaysText(WorkDays workDays)
        {
            if (workDays == WorkDays.None)
                return "No days assigned";

            var days = new List<string>();

            if (workDays.HasFlag(WorkDays.Monday)) days.Add("Monday");
            if (workDays.HasFlag(WorkDays.Tuesday)) days.Add("Tuesday");
            if (workDays.HasFlag(WorkDays.Wednesday)) days.Add("Wednesday");
            if (workDays.HasFlag(WorkDays.Thursday)) days.Add("Thursday");
            if (workDays.HasFlag(WorkDays.Friday)) days.Add("Friday");
            if (workDays.HasFlag(WorkDays.Saturday)) days.Add("Saturday");
            if (workDays.HasFlag(WorkDays.Sunday)) days.Add("Sunday");

            return string.Join(", ", days);
        }
    }
}