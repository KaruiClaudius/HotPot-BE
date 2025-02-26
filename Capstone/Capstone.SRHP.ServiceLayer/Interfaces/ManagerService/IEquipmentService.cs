using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IEquipmentService
    {
        Task<ConditionLog> LogEquipmentFailureAsync(ConditionLog conditionLog);
        Task<ConditionLog> UpdateResolutionTimelineAsync(int conditionLogId, MaintenanceStatus status, DateTime estimatedResolutionTime, string message);
        Task<ConditionLog> GetConditionLogByIdAsync(int conditionLogId);
        Task<IEnumerable<ConditionLog>> GetActiveConditionLogsAsync();
        Task<IEnumerable<ConditionLog>> GetConditionLogsByStatusAsync(MaintenanceStatus status);
        Task<IEnumerable<int>> GetAffectedCustomerIdsAsync(int conditionLogId);
        Task<bool> AssignStaffToResolutionAsync(int conditionLogId, int staffId);
        Task<bool> MarkAsResolvedAsync(int conditionLogId, string resolutionNotes);
    }
}
