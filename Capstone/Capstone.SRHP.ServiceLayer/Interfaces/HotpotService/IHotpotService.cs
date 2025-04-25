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
    public interface IHotpotService
    {
        Task<PagedResult<Hotpot>> GetHotpotsAsync(
                string searchTerm = null,
                bool? isAvailable = null,
                string material = null,
                string size = null,
                decimal? minPrice = null,
                decimal? maxPrice = null,
                int? minQuantity = null,
                int pageNumber = 1,
                int pageSize = 10,
                string sortBy = "Name",
                bool ascending = true);

        Task<Hotpot> GetByIdAsync(int id);
        Task<HotPotInventory> GetByInvetoryIdAsync(int inventoryId);
        Task<Hotpot> CreateAsync(Hotpot entity, string[] seriesNumbers = null);
        Task UpdateAsync(int id, Hotpot entity, string[] seriesNumbers = null);
        Task DeleteAsync(int id);
        Task<decimal> CalculateDepositAsync(int id, int quantity);
        Task UpdateQuantityAsync(int hotpotId);
        Task<bool> IsAvailableAsync(int id);

        Task<int> CountDamageDevice();
    }
}
