using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IEquipmentStockService
    {
        // HotPot Inventory Methods
        Task<HotPotInventory> GetHotPotInventoryByIdAsync(int inventoryId);
        Task<IEnumerable<HotPotInventory>> GetAllHotPotInventoryAsync();
        Task<IEnumerable<HotPotInventory>> GetHotPotInventoryByHotpotIdAsync(int hotpotId);

        // Utensil Methods
        Task<ModelLayer.Entities.Utensil> GetUtensilByIdAsync(int utensilId);
        Task<IEnumerable<ModelLayer.Entities.Utensil>> GetAllUtensilsAsync();
        Task<IEnumerable<ModelLayer.Entities.Utensil>> GetUtensilsByTypeAsync(int typeId);
        Task<ModelLayer.Entities.Utensil> UpdateUtensilQuantityAsync(int utensilId, int quantity);
        Task<ModelLayer.Entities.Utensil> UpdateUtensilStatusAsync(int utensilId, bool isAvailable, string reason);

        // Stock Status Methods
        Task<IEnumerable<ModelLayer.Entities.Utensil>> GetLowStockUtensilsAsync(int threshold = 5);
        Task<IEnumerable<EquipmentStatusDto>> GetEquipmentStatusSummaryAsync();
    }
}
