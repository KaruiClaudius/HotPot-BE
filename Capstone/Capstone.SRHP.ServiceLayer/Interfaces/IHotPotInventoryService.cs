using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface IHotPotInventoryService : IBaseService<HotPotInventory>
    {
        Task<HotPotInventory> GetBySeriesNumberAsync(string seriesNumber);
        Task<IEnumerable<HotPotInventory>> GetByHotpotIdAsync(int hotpotId);
        Task<IEnumerable<HotPotInventory>> CreateBulkAsync(int hotpotId, int quantity, string seriesNumberPrefix);
        Task<bool> IsSeriesNumberUniqueAsync(string seriesNumber, int? excludeId = null);
        Task<int> GetInventoryCountByHotpotIdAsync(int hotpotId);
    }
}
