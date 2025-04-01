using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using System;
using System.Collections.Generic;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class WorkShiftDto
    {
        public int WorkShiftId { get; set; }
        public TimeSpan? ShiftStartTime { get; set; }
        public TimeSpan? ShiftEndTime { get; set; }
        public string ShiftName { get; set; }
        //public List<UserDto>? Staff { get; set; }
        //public List<UserDto>? Managers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public class ManagerWorkShiftDto
    {
        public int WorkShiftId { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan? ShiftEndTime { get; set; }
        public string ShiftName { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public List<ManagerSDto> Managers { get; set; }
    }

    public class StaffWorkShiftDto
    {
        public int WorkShiftId { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan? ShiftEndTime { get; set; }
        public string ShiftName { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public List<StaffSDto>? Staff { get; set; }
    }

    public class StaffSDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public WorkDays DaysOfWeek { get; set; }

    }

    public class ManagerSDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

    }

    public class StaffScheduleDto
    {
        public StaffSDto Staff { get; set; }
    }

    public class CreateWorkShiftDto
    {
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan ShiftEndTime { get; set; }
        public string ShiftName { get; set; }
    }

    public class UpdateWorkShiftDto
    {
        public TimeSpan ShiftStartTime { get; set; }
        public TimeSpan ShiftEndTime { get; set; }
        public string ShiftName { get; set; }
    }

    public class AssignStaffWorkDaysDto
    {
        public int StaffId { get; set; }
        public WorkDays WorkDays { get; set; }
    }

    public class AssignManagerWorkDaysAndShiftsDto
    {
        public int ManagerId { get; set; }
        public WorkDays WorkDays { get; set; }
        public List<int> WorkShiftIds { get; set; } = new List<int>();

    }
}