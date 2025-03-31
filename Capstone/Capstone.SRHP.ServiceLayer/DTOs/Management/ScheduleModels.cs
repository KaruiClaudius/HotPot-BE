using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class WorkShiftDto
    {
        public int WorkShiftId { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public string? Status { get; set; }
        public List<StaffDto>? Staff { get; set; }
        public List<ManagerDto>? Managers { get; set; }
    }
    public class ManagerWorkShiftDto
    {
        public int WorkShiftId { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public string? Status { get; set; }
        public List<ManagerDto>? Managers { get; set; }
    }

    public class StaffWorkShiftDto
    {
        public int WorkShiftId { get; set; }
        public TimeSpan ShiftStartTime { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public string? Status { get; set; }
        public List<StaffDto>? Staff { get; set; }
    }

    public class StaffDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public WorkDays WorkDays { get; set; }
    }

    public class ManagerDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public WorkDays WorkDays { get; set; }
    }

    public class StaffScheduleDto
    {
        public StaffDto Staff { get; set; }
    }

    public class CreateWorkShiftDto
    {
        public TimeSpan ShiftStartTime { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateWorkShiftDto
    {
        public TimeSpan ShiftStartTime { get; set; }
        public WorkDays DaysOfWeek { get; set; }
        public string? Status { get; set; }
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