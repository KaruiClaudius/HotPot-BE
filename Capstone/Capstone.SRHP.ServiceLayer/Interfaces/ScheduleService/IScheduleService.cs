using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService
{
    public interface IScheduleService
    {
        Task<WorkShift> GetWorkShiftByIdAsync(int shiftId);
        Task<IEnumerable<WorkShift>> GetAllWorkShiftsAsync();
        Task<IEnumerable<WorkShift>> GetStaffWorkShiftsAsync(int staffId);
        Task<IEnumerable<WorkShift>> GetManagerWorkShiftsAsync(int managerId);
        Task<WorkShift> CreateWorkShiftAsync(WorkShift workShift);
        Task<WorkShift> UpdateWorkShiftAsync(int shiftId, TimeSpan shiftStartTime, WorkDays daysOfWeek, AttendanceStatus? status);
        Task<bool> DeleteWorkShiftAsync(int shiftId);
        Task<User> AssignStaffWorkDaysAsync(int staffId, WorkDays workDays);
        Task<User> AssignManagerWorkDaysAndShiftsAsync(int managerId, WorkDays workDays, IEnumerable<WorkShift> workShifts);

    }
}
