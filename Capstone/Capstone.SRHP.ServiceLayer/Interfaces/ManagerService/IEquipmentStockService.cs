using System.Collections.Generic;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IEquipmentStockService
    {
        // HotPot Inventory Methods
        Task<HotPotInventoryDetailDto> GetHotPotInventoryByIdAsync(int inventoryId);
        Task<IEnumerable<HotPotInventoryDto>> GetAllHotPotInventoryAsync();
        Task<IEnumerable<HotPotInventoryDto>> GetHotPotInventoryByHotpotIdAsync(int hotpotId);
        Task<HotPotInventoryDetailDto> UpdateHotPotInventoryAsync(int inventoryId, HotpotStatus isAvailable, string reason);

        // Utensil Methods
        Task<UtensilDetailDto> GetUtensilByIdAsync(int utensilId);
        Task<IEnumerable<UtensilDto>> GetAllUtensilsAsync();
        Task<IEnumerable<UtensilDto>> GetUtensilsByTypeAsync(int typeId);
        Task<UtensilDetailDto> UpdateUtensilQuantityAsync(int utensilId, int quantity);
        Task<UtensilDetailDto> UpdateUtensilStatusAsync(int utensilId, bool isAvailable, string reason);

        // Stock Status Methods
        Task<IEnumerable<UtensilDto>> GetLowStockUtensilsAsync(int threshold = 5);
        Task<IEnumerable<EquipmentStatusDto>> GetEquipmentStatusSummaryAsync();
    }
}