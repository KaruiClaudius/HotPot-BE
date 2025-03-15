using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.HotpotService
{
    public class ConditionLogService : IConditionLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConditionLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DamageDevice>> GetAllAsync()
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .FindAll(cl => !cl.IsDelete)
                .ToListAsync();
        }
        public async Task<PagedResult<DamageDevice>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<DamageDevice>()
                .FindAll(l => !l.IsDelete);

            // If you have any includes or other query modifications, add them here
            // For example:
            // query = query.Include(l => l.Hotpot);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(l => l.CreatedAt) // Most recent logs first
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<DamageDevice>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<DamageDevice?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .FindAsync(cl => cl.HotPotInventoryId == id && !cl.IsDelete);
        }

        public async Task<DamageDevice> CreateAsync(DamageDevice entity)
        {
            //// Validate basic properties
            //if (string.IsNullOrWhiteSpace(entity.Name))
            //    throw new ValidationException("Log name cannot be empty");

            //if (string.IsNullOrWhiteSpace(entity.Description))
            //    throw new ValidationException("Log description cannot be empty");

            //// Validate item exists based on ItemType
            //await ValidateItemExistsAsync(entity.ItemType, entity.ItemID);

            //// Set logged date if not set
            //if (entity.LoggedDate == default)
            //    entity.LoggedDate = DateTime.UtcNow;

            //_unitOfWork.Repository<ConditionLog>().Insert(entity);
            //await _unitOfWork.CommitAsync();

            return null;
        }

        public async Task UpdateAsync(int id, DamageDevice entity)
        {
            //var existingLog = await GetByIdAsync(id);
            //if (existingLog == null)
            //    throw new NotFoundException($"Condition log with ID {id} not found");

            //// Validate basic properties
            //if (string.IsNullOrWhiteSpace(entity.Name))
            //    throw new ValidationException("Log name cannot be empty");

            //if (string.IsNullOrWhiteSpace(entity.Description))
            //    throw new ValidationException("Log description cannot be empty");

            //// Validate item exists if ItemType or ItemID changed
            //if (existingLog.ItemType != entity.ItemType || existingLog.ItemID != entity.ItemID)
            //{
            //    await ValidateItemExistsAsync(entity.ItemType, entity.ItemID);
            //}

            //entity.SetUpdateDate();
            //await _unitOfWork.Repository<ConditionLog>().Update(entity, id);
            //await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var log = await GetByIdAsync(id);
            if (log == null)
                throw new NotFoundException($"Condition log with ID {id} not found");

            log.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetByItemTypeAsync(MaintenanceItemType itemType)
        {
            //return await _unitOfWork.Repository<ConditionLog>()
            //    .FindAll(cl => cl.ItemType == itemType && !cl.IsDelete)
            //    .ToListAsync();
            return null;
        }

        public async Task<IEnumerable<DamageDevice>> GetByItemAsync(MaintenanceItemType itemType, int itemId)
        {
            //return await _unitOfWork.Repository<ConditionLog>()
            //    .FindAll(cl => cl.ItemType == itemType && cl.ItemID == itemId && !cl.IsDelete)
            //    .ToListAsync();
            return null;
        }

        public async Task<IEnumerable<DamageDevice>> GetByStatusAsync(MaintenanceStatus status)
        {
            //return await _unitOfWork.Repository<ConditionLog>()
            //    .FindAll(cl => cl.Status == status && !cl.IsDelete)
            //    .ToListAsync();

            return null;
        }

        public async Task<IEnumerable<DamageDevice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .FindAll(cl => cl.LoggedDate >= startDate && cl.LoggedDate <= endDate && !cl.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetByScheduleTypeAsync(MaintenanceScheduleType scheduleType)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .FindAll(cl => cl.ScheduleType == scheduleType && !cl.IsDelete)
                .ToListAsync();
        }

        private async Task ValidateItemExistsAsync(MaintenanceItemType itemType, int itemId)
        {
            //bool itemExists = itemType switch
            //{
            //    MaintenanceItemType.Hotpot => await _unitOfWork.Repository<Hotpot>()
            //        .FindAsync(h => h.Id == itemId && !h.IsDelete) != null,

            //    MaintenanceItemType.Utensil => await _unitOfWork.Repository<Utensil>()
            //        .FindAsync(u => u.Id == itemId && !u.IsDelete) != null,

            //    _ => throw new ValidationException($"Unsupported maintenance item type: {itemType}")
            //};

            //if (!itemExists)
            //    throw new ValidationException($"Item of type {itemType} with ID {itemId} not found");
        }
    }
}
