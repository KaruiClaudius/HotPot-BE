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
        Task<Staff> GetStaffByIdAsync(int staffId);
        Task<Staff> GetStaffByUserIdAsync(int userId);
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff> CreateStaffAsync(Staff staff);
        Task UpdateStaffAsync(int staffId, Staff staff);
        Task DeleteStaffAsync(int staffId);
    }
}
