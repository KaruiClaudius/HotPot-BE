using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class EquipmentStockService : IEquipmentStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int DEFAULT_LOW_STOCK_THRESHOLD = 5;

        public EquipmentStockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region HotPot Inventory Methods

        public async Task<HotPotInventory> GetHotPotInventoryByIdAsync(int inventoryId)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .AsQueryable(h => h.HotPotInventoryId == inventoryId)
                .Include(h => h.Hotpot)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HotPotInventory>> GetAllHotPotInventoryAsync()
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .GetAll()
                .Include(h => h.Hotpot)
                .ToListAsync();
        }

        public async Task<IEnumerable<HotPotInventory>> GetHotPotInventoryByHotpotIdAsync(int hotpotId)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .GetAll(h => h.HotpotId == hotpotId)
                .Include(h => h.Hotpot)
                .ToListAsync();
        }

        public async Task<HotPotInventory> UpdateHotPotInventoryAsync(int inventoryId, bool isAvailable, string reason)
        {
            var inventory = await _unitOfWork.Repository<HotPotInventory>()
                .FindAsync(h => h.HotPotInventoryId == inventoryId);

            if (inventory == null)
                throw new KeyNotFoundException($"HotPot inventory with ID {inventoryId} not found");

            inventory.Status = isAvailable;
            inventory.UpdatedAt = DateTime.UtcNow;

            // If there's a reason for the status change, log it as a condition
            if (!string.IsNullOrEmpty(reason))
            {
                var conditionLog = new ConditionLog
                {
                    Name = isAvailable ? "Available" : "Unavailable",
                    Description = reason,
                    Status = isAvailable ? ModelLayer.Enum.MaintenanceStatus.Completed : ModelLayer.Enum.MaintenanceStatus.Pending,
                    ScheduleType = isAvailable ? ModelLayer.Enum.MaintenanceScheduleType.Regular : ModelLayer.Enum.MaintenanceScheduleType.Unscheduled,
                    LoggedDate = DateTime.UtcNow,
                    HotPotInventoryId = inventoryId
                };

                _unitOfWork.Repository<ConditionLog>().Insert(conditionLog);
            }

            await _unitOfWork.CommitAsync();

            // Load the hotpot for the response
            inventory.Hotpot = await _unitOfWork.Repository<Hotpot>()
                .FindAsync(h => h.HotpotId == inventory.HotpotId);

            return inventory;
        }

        #endregion

        #region Utensil Methods

        public async Task<ModelLayer.Entities.Utensil> GetUtensilByIdAsync(int utensilId)
        {
            return await _unitOfWork.Repository<ModelLayer.Entities.Utensil>()
                .AsQueryable(u => u.UtensilId == utensilId)
                .Include(u => u.UtensilType)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ModelLayer.Entities.Utensil>> GetAllUtensilsAsync()
        {
            return await _unitOfWork.Repository<ModelLayer.Entities.Utensil>()
                .GetAll()
                .Include(u => u.UtensilType)
                .ToListAsync();
        }

        public async Task<IEnumerable<ModelLayer.Entities.Utensil>> GetUtensilsByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<ModelLayer.Entities.Utensil>()
                .GetAll(u => u.UtensilTypeID == typeId)
                .Include(u => u.UtensilType)
                .ToListAsync();
        }

        public async Task<ModelLayer.Entities.Utensil> UpdateUtensilQuantityAsync(int utensilId, int quantity)
        {
            var utensil = await _unitOfWork.Repository<ModelLayer.Entities.Utensil>()
                .FindAsync(u => u.UtensilId == utensilId);

            if (utensil == null)
                throw new KeyNotFoundException($"Utensil with ID {utensilId} not found");

            utensil.Quantity = quantity;
            utensil.UpdatedAt = DateTime.UtcNow;

            // If quantity is 0, also update status to unavailable
            if (quantity == 0)
            {
                utensil.Status = false;
            }

            await _unitOfWork.CommitAsync();

            // Load the utensil type for the response
            utensil.UtensilType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == utensil.UtensilTypeID);

            return utensil;
        }

        public async Task<ModelLayer.Entities.Utensil> UpdateUtensilStatusAsync(int utensilId, bool isAvailable, string reason)
        {
            var utensil = await _unitOfWork.Repository<ModelLayer.Entities.Utensil>()
                .FindAsync(u => u.UtensilId == utensilId);

            if (utensil == null)
                throw new KeyNotFoundException($"Utensil with ID {utensilId} not found");

            utensil.Status = isAvailable;
            utensil.UpdatedAt = DateTime.UtcNow;

            // If there's a reason for the status change, log it as a condition
            if (!string.IsNullOrEmpty(reason))
            {
                var conditionLog = new ConditionLog
                {
                    Name = isAvailable ? "Available" : "Unavailable",
                    Description = reason,
                    Status = isAvailable ? ModelLayer.Enum.MaintenanceStatus.Completed : ModelLayer.Enum.MaintenanceStatus.Pending,
                    ScheduleType = isAvailable ? ModelLayer.Enum.MaintenanceScheduleType.Regular : ModelLayer.Enum.MaintenanceScheduleType.Unscheduled,
                    LoggedDate = DateTime.UtcNow,
                    UtensilID = utensilId
                };

                _unitOfWork.Repository<ConditionLog>().Insert(conditionLog);
            }

            await _unitOfWork.CommitAsync();

            // Load the utensil type for the response
            utensil.UtensilType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == utensil.UtensilTypeID);

            return utensil;
        }

        #endregion

        #region Stock Status Methods

        public async Task<IEnumerable<ModelLayer.Entities.Utensil>> GetLowStockUtensilsAsync(int threshold = DEFAULT_LOW_STOCK_THRESHOLD)
        {
            return await _unitOfWork.Repository<ModelLayer.Entities.Utensil>()
                .GetAll(u => u.Quantity <= threshold && u.Quantity > 0)
                .Include(u => u.UtensilType)
                .ToListAsync();
        }

        public async Task<IEnumerable<EquipmentStatusDto>> GetEquipmentStatusSummaryAsync()
        {
            var result = new List<EquipmentStatusDto>();

            // Get HotPot inventory summary
            var hotpotInventories = await _unitOfWork.Repository<HotPotInventory>().GetAll().ToListAsync();
            var hotpotSummary = new EquipmentStatusDto
            {
                EquipmentType = "HotPot",
                TotalCount = hotpotInventories.Count,
                AvailableCount = hotpotInventories.Count(h => h.Status),
                UnavailableCount = hotpotInventories.Count(h => !h.Status),
                LowStockCount = 0, // Not applicable for HotPots
                AvailabilityPercentage = hotpotInventories.Count > 0
                    ? (double)hotpotInventories.Count(h => h.Status) / hotpotInventories.Count * 100
                    : 0
            };
            result.Add(hotpotSummary);

            // Get Utensil summary
            var utensils = await _unitOfWork.Repository<ModelLayer.Entities.Utensil>().GetAll().ToListAsync();
            var utensilSummary = new EquipmentStatusDto
            {
                EquipmentType = "Utensil",
                TotalCount = utensils.Count,
                AvailableCount = utensils.Count(u => u.Status && u.Quantity > 0),
                UnavailableCount = utensils.Count(u => !u.Status || u.Quantity == 0),
                LowStockCount = utensils.Count(u => u.Quantity <= DEFAULT_LOW_STOCK_THRESHOLD && u.Quantity > 0),
                AvailabilityPercentage = utensils.Count > 0
                    ? (double)utensils.Count(u => u.Status && u.Quantity > 0) / utensils.Count * 100
                    : 0
            };
            result.Add(utensilSummary);

            // Get summary by utensil type
            var utensilTypes = await _unitOfWork.Repository<UtensilType>().GetAll().ToListAsync();
            foreach (var utensilType in utensilTypes)
            {
                var typeUtensils = utensils.Where(u => u.UtensilTypeID == utensilType.UtensilTypeId).ToList();
                if (typeUtensils.Any())
                {
                    var typeSummary = new EquipmentStatusDto
                    {
                        EquipmentType = $"Utensil - {utensilType.Name}",
                        TotalCount = typeUtensils.Count,
                        AvailableCount = typeUtensils.Count(u => u.Status && u.Quantity > 0),
                        UnavailableCount = typeUtensils.Count(u => !u.Status || u.Quantity == 0),
                        LowStockCount = typeUtensils.Count(u => u.Quantity <= DEFAULT_LOW_STOCK_THRESHOLD && u.Quantity > 0),
                        AvailabilityPercentage = typeUtensils.Count > 0
                            ? (double)typeUtensils.Count(u => u.Status && u.Quantity > 0) / typeUtensils.Count * 100
                            : 0
                    };
                    result.Add(typeSummary);
                }
            }

            return result;
        }
        #endregion
    }
}
