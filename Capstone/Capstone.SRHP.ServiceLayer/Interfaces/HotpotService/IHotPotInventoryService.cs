using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.HotpotService
{
    public interface IHotPotInventoryService : IBaseService<HotPotInventory>
    {
        Task<PagedResult<HotPotInventory>> GetPagedAsync(int pageNumber, int pageSize);
        Task<HotPotInventory> GetBySeriesNumberAsync(string seriesNumber);
        Task<IEnumerable<HotPotInventory>> GetByHotpotIdAsync(int hotpotId);
        Task<IEnumerable<HotPotInventory>> CreateBulkAsync(int hotpotId, int quantity, string seriesNumberPrefix);
        Task<bool> IsSeriesNumberUniqueAsync(string seriesNumber, int? excludeId = null);
        Task<int> GetInventoryCountByHotpotIdAsync(int hotpotId);
    }
}
