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
        Task<IEnumerable<WorkShift>> GetAllWorkShiftsAsync(DateTime? startDate = null, DateTime? endDate = null, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<WorkShift>> GetStaffWorkShiftsAsync(int staffId, DateTime? startDate = null, DateTime? endDate = null);
        Task<IEnumerable<WorkShift>> GetManagerAssignedShiftsAsync(int managerId, DateTime? startDate = null, DateTime? endDate = null);
        Task<WorkShift> CreateWorkShiftAsync(WorkShift workShift);
        Task<WorkShift> UpdateWorkShiftAsync(int shiftId, DateTime shiftTime, AttendanceStatus? status);
        Task<bool> DeleteWorkShiftAsync(int shiftId);
        Task<int> GetTotalWorkShiftsCountAsync(DateTime? startDate = null, DateTime? endDate = null);
    }
}
