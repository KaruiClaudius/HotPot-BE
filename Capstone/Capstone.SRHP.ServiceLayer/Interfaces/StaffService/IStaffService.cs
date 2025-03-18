using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffService
    {
        Task<User> GetStaffByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllStaffAsync();
        Task<User> CreateStaffAsync(User staff);
        Task UpdateStaffAsync(int userId, User staffUpdate);
        Task DeleteStaffAsync(int userId);
        Task AssignWorkShiftsAsync(int userId, IEnumerable<WorkShift> workShifts);
    }
}
