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
        Task<IEnumerable<HotPotInventory>> GetAvailableInventoryAsync();
        Task<string> GenerateSeriesNumberAsync();
        Task<HotPotInventory?> GetBySeriesNumberAsync(string seriesNumber);
        Task<IEnumerable<Hotpot>> GetAssociatedHotpotsAsync(int inventoryId);
    }
}
