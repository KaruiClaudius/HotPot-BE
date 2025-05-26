using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.DTOs.User;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffService
    {
        Task<User> GetStaffByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllStaffAsync();
        Task<List<StaffAvailableDto>> GetAvailableStaffForTaskAsync(StaffTaskType? taskType = null, int? orderId = null);
        Task<User> CreateStaffAsync(User staff);
        Task UpdateStaffAsync(int userId, User staffUpdate);
        Task DeleteStaffAsync(int userId);


        // Pickup Interface
        Task<bool> AssignStaffToPickupAsync(int staffId, int rentOrderDetailId, int? vehicleId = null, string notes = null);
        Task<List<StaffPickupAssignmentDto>> GetStaffAssignmentsAsync(int staffId);
        Task<PagedResult<StaffPickupAssignmentDto>> GetStaffAssignmentsPaginatedAsync(int staffId, bool pendingOnly, int pageNumber, int pageSize);
        Task<PagedResult<StaffPickupAssignmentDto>> GetAllCurrentAssignmentsAsync(int pageNumber = 1, int pageSize = 10);

    }
}