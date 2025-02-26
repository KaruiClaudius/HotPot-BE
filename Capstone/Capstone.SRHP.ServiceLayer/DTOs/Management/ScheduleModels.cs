using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class CreateWorkShiftRequest
    {
        [Required]
        public DateTime ShiftTime { get; set; }

        public AttendanceStatus? Status { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public int ManagerId { get; set; }
    }

    public class UpdateWorkShiftRequest
    {
        [Required]
        public DateTime ShiftTime { get; set; }

        public AttendanceStatus? Status { get; set; }
    }

    public class UpdateWorkShiftStatusRequest
    {
        [Required]
        public AttendanceStatus Status { get; set; }
    }

    public class WeeklyScheduleResponse
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, List<WorkShift>> DailySchedules { get; set; }
    }

    public class MonthlyScheduleResponse
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, List<WorkShift>> DailySchedules { get; set; }
    }
}
