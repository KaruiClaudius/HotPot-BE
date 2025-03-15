using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.HotpotService
{
    public interface IConditionLogService : IBaseService<DamageDevice>
    {
        Task<PagedResult<DamageDevice>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<DamageDevice>> GetByItemTypeAsync(MaintenanceItemType itemType);
        Task<IEnumerable<DamageDevice>> GetByItemAsync(MaintenanceItemType itemType, int itemId);
        Task<IEnumerable<DamageDevice>> GetByStatusAsync(MaintenanceStatus status);
        Task<IEnumerable<DamageDevice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<DamageDevice>> GetByScheduleTypeAsync(MaintenanceScheduleType scheduleType);
    }
}
