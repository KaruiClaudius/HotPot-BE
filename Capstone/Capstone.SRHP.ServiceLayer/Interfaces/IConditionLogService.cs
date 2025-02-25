using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface IConditionLogService : IBaseService<ConditionLog>
    {
        Task<IEnumerable<ConditionLog>> GetByItemTypeAsync(MaintenanceItemType itemType);
        Task<IEnumerable<ConditionLog>> GetByItemAsync(MaintenanceItemType itemType, int itemId);
        Task<IEnumerable<ConditionLog>> GetByStatusAsync(MaintenanceStatus status);
        Task<IEnumerable<ConditionLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ConditionLog>> GetByScheduleTypeAsync(MaintenanceScheduleType scheduleType);
    }
}
