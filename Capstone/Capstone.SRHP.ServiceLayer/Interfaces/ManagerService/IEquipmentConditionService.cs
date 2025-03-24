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
        Task<DamageDevice> LogEquipmentConditionAsync(DamageDevice conditionLog);
        Task<DamageDevice> GetConditionLogByIdAsync(int conditionLogId);
        Task<IEnumerable<DamageDevice>> GetConditionLogsByEquipmentAsync(string equipmentType, int equipmentId);
        Task<IEnumerable<DamageDevice>> GetConditionLogsByStatusAsync(MaintenanceStatus status);
        //Task<IEnumerable<DamageDevice>> GetConditionLogsByScheduleTypeAsync(MaintenanceScheduleType scheduleType);
        Task<IEnumerable<DamageDevice>> GetConditionLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<bool> UpdateConditionStatusAsync(int conditionLogId, MaintenanceStatus status);
        Task<IEnumerable<DamageDevice>> GetRecentConditionLogsAsync(int count = 10);
    }
    
}
