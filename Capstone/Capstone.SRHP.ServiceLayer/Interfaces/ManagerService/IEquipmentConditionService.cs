using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IEquipmentConditionService
    {
        Task<ConditionLog> LogEquipmentConditionAsync(ConditionLog conditionLog);
        Task<ConditionLog> GetConditionLogByIdAsync(int conditionLogId);
        Task<IEnumerable<ConditionLog>> GetConditionLogsByEquipmentAsync(string equipmentType, int equipmentId);
        Task<IEnumerable<ConditionLog>> GetConditionLogsByStatusAsync(MaintenanceStatus status);
        Task<IEnumerable<ConditionLog>> GetConditionLogsByScheduleTypeAsync(MaintenanceScheduleType scheduleType);
        Task<IEnumerable<ConditionLog>> GetConditionLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<bool> UpdateConditionStatusAsync(int conditionLogId, MaintenanceStatus status);
        Task<IEnumerable<ConditionLog>> GetRecentConditionLogsAsync(int count = 10);
    }
    
}
