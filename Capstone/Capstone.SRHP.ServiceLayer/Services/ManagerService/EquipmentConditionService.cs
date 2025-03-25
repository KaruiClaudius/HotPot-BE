using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class EquipmentConditionService : IEquipmentConditionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentConditionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DamageDevice> LogEquipmentConditionAsync(DamageDevice conditionLog)
        {
            // Validate that either HotPotInventoryId or UtensilID is provided
            if (!conditionLog.HotPotInventoryId.HasValue && !conditionLog.UtensilId.HasValue)
            {
                throw new ArgumentException("Either HotPotInventoryId or UtensilId must be provided");
            }

            // Set the logged date to current time
            conditionLog.LoggedDate = DateTime.UtcNow;

            _unitOfWork.Repository<DamageDevice>().Insert(conditionLog);
            await _unitOfWork.CommitAsync();

            // Load related entities
            if (conditionLog.HotPotInventoryId.HasValue)
            {
                conditionLog.HotPotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable(h => h.HotPotInventoryId == conditionLog.HotPotInventoryId.Value)
                    .Include(h => h.Hotpot)
                    .FirstOrDefaultAsync();
            }
            else if (conditionLog.UtensilId.HasValue)
            {
                conditionLog.Utensil = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable(u => u.UtensilId == conditionLog.UtensilId.Value)
                    .Include(u => u.UtensilType)
                    .FirstOrDefaultAsync();
            }

            return conditionLog;
        }

        public async Task<DamageDevice> GetConditionLogByIdAsync(int conditionLogId)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.DamageDeviceId == conditionLogId)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetConditionLogsByEquipmentAsync(string equipmentType, int equipmentId)
        {
            if (equipmentType.ToLower() == "hotpot")
            {
                return await _unitOfWork.Repository<DamageDevice>()
                    .GetAll(c => c.HotPotInventoryId == equipmentId)
                    .Include(c => c.HotPotInventory)
                        .ThenInclude(h => h.Hotpot)
                    .OrderByDescending(c => c.LoggedDate)
                    .ToListAsync();
            }
            else if (equipmentType.ToLower() == "utensil")
            {
                return await _unitOfWork.Repository<DamageDevice>()
                    .GetAll(c => c.UtensilId == equipmentId)
                    .Include(c => c.Utensil)
                        .ThenInclude(u => u.UtensilType)
                    .OrderByDescending(c => c.LoggedDate)
                    .ToListAsync();
            }

            return new List<DamageDevice>();
        }

        public async Task<IEnumerable<DamageDevice>> GetConditionLogsByStatusAsync(MaintenanceStatus status)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.Status == status)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetConditionLogsByScheduleTypeAsync(MaintenanceScheduleType scheduleType)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.ScheduleType == scheduleType)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetConditionLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.LoggedDate >= startDate && c.LoggedDate <= endDate)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();
        }

        public async Task<bool> UpdateConditionStatusAsync(int conditionLogId, MaintenanceStatus status)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .FindAsync(c => c.DamageDeviceId == conditionLogId);

            if (conditionLog == null)
                return false;

            conditionLog.Status = status;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<DamageDevice>> GetRecentConditionLogsAsync(int count = 10)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .GetAll()
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(c => c.LoggedDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
