using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.DTOs.User;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffService
    {
        Task<User> GetStaffByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllStaffAsync();
        Task<List<StaffAvailableDto>> GetAvailableStaffAsync();
        Task<User> CreateStaffAsync(User staff);
        Task UpdateStaffAsync(int userId, User staffUpdate);
        Task DeleteStaffAsync(int userId);
        Task AssignWorkShiftsAsync(int userId, IEnumerable<WorkShift> workShifts);


        // Pickup Interface
        Task<bool> AssignStaffToPickupAsync(int staffId, int rentOrderDetailId, string notes = null);
        Task<bool> CompletePickupAssignmentAsync(
            int assignmentId,
            DateTime completedDate,
            string returnCondition = null,
            decimal? damageFee = null);
        Task<List<StaffPickupAssignmentDto>> GetStaffAssignmentsAsync(int staffId);
        Task<PagedResult<StaffPickupAssignmentDto>> GetAllCurrentAssignmentsAsync(int pageNumber = 1, int pageSize = 10);
}
}