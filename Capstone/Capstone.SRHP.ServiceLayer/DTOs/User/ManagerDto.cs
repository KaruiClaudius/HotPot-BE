using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.User
{
    public class ManagerDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public WorkDays? WorkDays { get; set; }
        public List<WorkShiftSDto> WorkShifts { get; set; } = new List<WorkShiftSDto>();
    }
    public class WorkShiftSDto
    {
        public int WorkShiftId { get; set; }
        public string ShiftName { get; set; } = string.Empty;
        public TimeSpan? ShiftStartTime { get; set; }
        public TimeSpan? ShiftEndTime { get; set; }
    }
}
