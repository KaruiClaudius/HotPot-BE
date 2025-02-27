using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UserService
{
    public interface IWorkShiftService : IBaseService<WorkShift>
    {
        Task<IEnumerable<WorkShift>> GetCurrentShiftsAsync();
        Task<IEnumerable<WorkShift>> GetUpcomingShiftsAsync();
        Task<IEnumerable<WorkShift>> GetByDateAsync(DateTime date);
        Task<IEnumerable<Staff>> GetStaffInShiftAsync(int shiftId);
        Task<IEnumerable<Manager>> GetManagersInShiftAsync(int shiftId);
        Task AssignStaffToShiftAsync(int shiftId, int staffId);
        Task AssignManagerToShiftAsync(int shiftId, int managerId);
        Task RemoveStaffFromShiftAsync(int shiftId, int staffId);
        Task RemoveManagerFromShiftAsync(int shiftId, int managerId);
        Task UpdateAttendanceStatusAsync(int shiftId, AttendanceStatus status);
    }
}
