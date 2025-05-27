using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffAssignmentService
    {
        /// Assigns a staff member to a specific task for an order
        Task<StaffAssignmentResponse> AssignStaffToTaskAsync(
                    int orderId,
                    int staffId,
                    int managerId,
                    StaffTaskType taskType,
                    int? vehicleId = null);

        Task<bool> CompleteAssignmentAsync(int assignmentId, EquipmentReturnRequest returnRequest = null);

        /// Gets all assignments for a specific staff member
        Task<List<StaffAssignmentDto>> GetStaffAssignmentsAsync(int staffId, StaffTaskType? taskType = null);

        /// Gets paginated assignments for a specific staff member
        Task<PagedResult<StaffAssignmentDto>> GetStaffAssignmentsPaginatedAsync(
                    int staffId,
                    StaffTaskType? taskType = null,
                    bool? activeOnly = null,
                    int pageNumber = 1,
                    int pageSize = 10);

        /// Gets all current (active) assignments across all staff members
        Task<PagedResult<StaffAssignmentDto>> GetAllCurrentAssignmentsAsync(
            StaffTaskType? taskType = null,
            int pageNumber = 1,
            int pageSize = 10);

        Task<PagedResult<StaffAssignmentHistoryDto>> GetStaffAssignmentHistoryAsync(
            StaffAssignmentHistoryFilterRequest filter, int managerId);
    }
}
