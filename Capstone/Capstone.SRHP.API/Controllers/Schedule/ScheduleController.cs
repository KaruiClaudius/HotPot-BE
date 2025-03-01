using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Controllers.Schedule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IHubContext<ScheduleHub> _scheduleHubContext;

        public ScheduleController(IScheduleService scheduleService, IHubContext<ScheduleHub> scheduleHubContext)
        {
            _scheduleService = scheduleService;
            _scheduleHubContext = scheduleHubContext;
        }

        // GetAllWorkShifts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<WorkShift>>>> GetAllWorkShifts(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var workShifts = await _scheduleService.GetAllWorkShiftsAsync(startDate, endDate, pageNumber, pageSize);
            var totalCount = await _scheduleService.GetTotalWorkShiftsCountAsync(startDate, endDate);

            var pagedResult = new PagedResult<WorkShift>
            {
                Items = workShifts,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(ApiResponse<PagedResult<WorkShift>>.SuccessResponse(pagedResult, "Work shifts retrieved successfully"));
        }

        // GetWorkShiftById
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<WorkShift>>> GetWorkShiftById(int id)
        {
            var workShift = await _scheduleService.GetWorkShiftByIdAsync(id);
            if (workShift == null)
                return NotFound(ApiResponse<WorkShift>.ErrorResponse($"Work shift with ID {id} not found"));

            return Ok(ApiResponse<WorkShift>.SuccessResponse(workShift, "Work shift retrieved successfully"));
        }

        // GetStaffWorkShifts
        [HttpGet("staff/{staffId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<WorkShift>>>> GetStaffWorkShifts(
            int staffId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            var workShifts = await _scheduleService.GetStaffWorkShiftsAsync(staffId, startDate, endDate);
            return Ok(ApiResponse<IEnumerable<WorkShift>>.SuccessResponse(workShifts, "Staff work shifts retrieved successfully"));
        }

        // GetManagerAssignedShifts
        [HttpGet("manager/{managerId}")]
        [Authorize(Roles = "Manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<WorkShift>>>> GetManagerAssignedShifts(
            int managerId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            var workShifts = await _scheduleService.GetManagerAssignedShiftsAsync(managerId, startDate, endDate);
            return Ok(ApiResponse<IEnumerable<WorkShift>>.SuccessResponse(workShifts, "Manager assigned shifts retrieved successfully"));
        }

        // CreateWorkShift
        [HttpPost("createWorkShift")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<WorkShift>>> CreateWorkShift([FromBody] CreateWorkShiftRequest request)
        {
            try
            {
                var workShift = new WorkShift
                {
                    ShiftTime = request.ShiftTime,
                    Status = request.Status,
                    StaffID = request.StaffId,
                    ManagerID = request.ManagerId
                };

                var result = await _scheduleService.CreateWorkShiftAsync(workShift);

                // Notify the staff member about their new shift
                await _scheduleHubContext.Clients.User(request.StaffId.ToString()).SendAsync("ReceiveScheduleUpdate",
                    request.StaffId,
                    request.ShiftTime);

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return CreatedAtAction(nameof(GetWorkShiftById), new { id = result.Id },
                    ApiResponse<WorkShift>.SuccessResponse(result, "Work shift created successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<WorkShift>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<WorkShift>.ErrorResponse(ex.Message));
            }
        }

        // UpdateWorkShift
        [HttpPut("updateWorkShift/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<WorkShift>>> UpdateWorkShift(int id, [FromBody] UpdateWorkShiftRequest request)
        {
            try
            {
                var result = await _scheduleService.UpdateWorkShiftAsync(id, request.ShiftTime, request.Status);

                // Notify the staff member about their updated shift
                await _scheduleHubContext.Clients.User(result.StaffID.ToString()).SendAsync("ReceiveScheduleUpdate",
                    result.StaffID,
                    result.ShiftTime);

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return Ok(ApiResponse<WorkShift>.SuccessResponse(result, "Work shift updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<WorkShift>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<WorkShift>.ErrorResponse(ex.Message));
            }
        }

        // DeleteWorkShift
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteWorkShift(int id)
        {
            try
            {
                // Get the work shift before deleting it to know which staff to notify
                var workShift = await _scheduleService.GetWorkShiftByIdAsync(id);
                if (workShift == null)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Work shift with ID {id} not found"));

                var result = await _scheduleService.DeleteWorkShiftAsync(id);
                if (!result)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Work shift with ID {id} not found"));

                // Notify the staff member about their deleted shift
                await _scheduleHubContext.Clients.User(workShift.StaffID.ToString()).SendAsync("ReceiveScheduleUpdate",
                    workShift.StaffID,
                    workShift.ShiftTime);

                // Notify all managers about the schedule update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Work shift deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        // GetWeeklySchedule
        [HttpGet("weekly/{userId}/{userType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<WeeklyScheduleResponse>>> GetWeeklySchedule(
            int userId,
            string userType,
            [FromQuery] DateTime? startDate = null)
        {
            try
            {
                // If no start date is provided, use the current week's Monday
                if (!startDate.HasValue)
                {
                    var today = DateTime.Today;
                    var dayOfWeek = (int)today.DayOfWeek;
                    startDate = today.AddDays(dayOfWeek == 0 ? -6 : 1 - dayOfWeek); // Sunday is 0, Monday is 1, etc.
                }

                // Calculate the end date (7 days from start date)
                var endDate = startDate.Value.AddDays(7);

                // Get the appropriate work shifts based on user type
                IEnumerable<WorkShift> workShifts;
                if (userType.ToLower() == "staff")
                {
                    workShifts = await _scheduleService.GetStaffWorkShiftsAsync(userId, startDate, endDate);
                }
                else if (userType.ToLower() == "manager")
                {
                    // For managers, get all shifts for the week
                    workShifts = await _scheduleService.GetAllWorkShiftsAsync(startDate, endDate, 1, 1000);
                }
                else
                {
                    return BadRequest(ApiResponse<WeeklyScheduleResponse>.ErrorResponse("Invalid user type. Must be 'staff' or 'manager'."));
                }

                // Group shifts by day
                var dailyShifts = new Dictionary<string, List<WorkShift>>();
                for (int i = 0; i < 7; i++)
                {
                    var day = startDate.Value.AddDays(i).ToString("yyyy-MM-dd");
                    dailyShifts[day] = workShifts
                        .Where(w => w.ShiftTime.Date == startDate.Value.AddDays(i).Date)
                        .ToList();
                }

                var response = new WeeklyScheduleResponse
                {
                    StartDate = startDate.Value,
                    EndDate = endDate,
                    DailySchedules = dailyShifts
                };

                return Ok(ApiResponse<WeeklyScheduleResponse>.SuccessResponse(response, "Weekly schedule retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<WeeklyScheduleResponse>.ErrorResponse(ex.Message));
            }
        }

        // GetMonthlySchedule
        [HttpGet("monthly/{userId}/{userType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<MonthlyScheduleResponse>>> GetMonthlySchedule(
            int userId,
            string userType,
            [FromQuery] int year = 0,
            [FromQuery] int month = 0)
        {
            try
            {
                // If no year or month is provided, use the current month
                if (year == 0 || month == 0)
                {
                    year = DateTime.Today.Year;
                    month = DateTime.Today.Month;
                }

                // Calculate the start and end dates for the month
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                // Get the appropriate work shifts based on user type
                IEnumerable<WorkShift> workShifts;
                if (userType.ToLower() == "staff")
                {
                    workShifts = await _scheduleService.GetStaffWorkShiftsAsync(userId, startDate, endDate);
                }
                else if (userType.ToLower() == "manager")
                {
                    // For managers, get all shifts for the month
                    workShifts = await _scheduleService.GetAllWorkShiftsAsync(startDate, endDate, 1, 1000);
                }
                else
                {
                    return BadRequest(ApiResponse<MonthlyScheduleResponse>.ErrorResponse("Invalid user type. Must be 'staff' or 'manager'."));
                }

                // Group shifts by day
                var dailyShifts = new Dictionary<string, List<WorkShift>>();
                for (int i = 1; i <= endDate.Day; i++)
                {
                    var day = new DateTime(year, month, i).ToString("yyyy-MM-dd");
                    dailyShifts[day] = workShifts
                        .Where(w => w.ShiftTime.Date == new DateTime(year, month, i))
                        .ToList();
                }

                var response = new MonthlyScheduleResponse
                {
                    Year = year,
                    Month = month,
                    StartDate = startDate,
                    EndDate = endDate,
                    DailySchedules = dailyShifts
                };

                return Ok(ApiResponse<MonthlyScheduleResponse>.SuccessResponse(response, "Monthly schedule retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<MonthlyScheduleResponse>.ErrorResponse(ex.Message));
            }
        }

        // UpdateWorkShiftStatus
        [HttpPut("status/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<WorkShift>>> UpdateWorkShiftStatus(int id, [FromBody] UpdateWorkShiftStatusRequest request)
        {
            try
            {
                // Get the current work shift
                var workShift = await _scheduleService.GetWorkShiftByIdAsync(id);
                if (workShift == null)
                    return NotFound(ApiResponse<WorkShift>.ErrorResponse($"Work shift with ID {id} not found"));

                // Update only the status
                var result = await _scheduleService.UpdateWorkShiftAsync(id, workShift.ShiftTime, request.Status);

                // Notify all managers about the status update
                await _scheduleHubContext.Clients.Group("Managers").SendAsync("ReceiveStatusUpdate",
                    id,
                    result.StaffID,
                    result.Status);

                return Ok(ApiResponse<WorkShift>.SuccessResponse(result, "Work shift status updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<WorkShift>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<WorkShift>.ErrorResponse(ex.Message));
            }
        }
    }
}
