using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services
{
    public class HotPotInventoryService : IHotPotInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotPotInventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HotPotInventory>> GetAllAsync()
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(i => !i.IsDelete)
                .Include(i => i.Hotpot)
                .ToListAsync();
        }

        public async Task<IEnumerable<HotPotInventory>> GetByHotpotIdAsync(int hotpotId)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(i => i.HotpotId == hotpotId && !i.IsDelete)
                .Include(i => i.Hotpot)
                .ToListAsync();
        }

        public async Task<HotPotInventory> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .FindAsync(i => i.HotPotInventoryId == id && !i.IsDelete,
                          i => i.Include(x => x.Hotpot)
                                .Include(x => x.ConditionLogs));
        }

        public async Task<HotPotInventory> GetBySeriesNumberAsync(string seriesNumber)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .FindAsync(i => i.SeriesNumber == seriesNumber && !i.IsDelete,
                          i => i.Include(x => x.Hotpot));
        }

        public async Task<HotPotInventory> CreateAsync(HotPotInventory entity)
        {
            // Validate series number uniqueness
            if (!await IsSeriesNumberUniqueAsync(entity.SeriesNumber))
            {
                throw new ValidationException($"Inventory unit with series number '{entity.SeriesNumber}' already exists");
            }

            // Validate hotpot exists
            var hotpot = await _unitOfWork.Repository<Hotpot>()
                .FindAsync(h => h.HotpotId == entity.HotpotId && !h.IsDelete);

            if (hotpot == null)
            {
                throw new ValidationException($"Hotpot with ID {entity.HotpotId} not found");
            }

            _unitOfWork.Repository<HotPotInventory>().Insert(entity);
            await _unitOfWork.CommitAsync();

            // Update hotpot quantity
            await UpdateHotpotQuantity(entity.HotpotId);

            return entity;
        }

        public async Task<IEnumerable<HotPotInventory>> CreateBulkAsync(int hotpotId, int quantity, string seriesNumberPrefix)
        {
            // Validate hotpot exists
            var hotpot = await _unitOfWork.Repository<Hotpot>()
                .FindAsync(h => h.HotpotId == hotpotId && !h.IsDelete);

            if (hotpot == null)
            {
                throw new ValidationException($"Hotpot with ID {hotpotId} not found");
            }

            var createdInventories = new List<HotPotInventory>();

            // Generate unique series numbers
            for (int i = 1; i <= quantity; i++)
            {
                string seriesNumber = $"{seriesNumberPrefix}-{DateTime.Now:yyyyMMdd}-{i:D4}";

                // Ensure series number is unique
                int attempt = 1;
                while (!await IsSeriesNumberUniqueAsync(seriesNumber) && attempt <= 10)
                {
                    seriesNumber = $"{seriesNumberPrefix}-{DateTime.Now:yyyyMMdd}-{i:D4}-{attempt}";
                    attempt++;
                }

                if (attempt > 10)
                {
                    throw new ValidationException($"Failed to generate unique series number after 10 attempts");
                }

                var inventory = new HotPotInventory
                {
                    SeriesNumber = seriesNumber,
                    HotpotId = hotpotId
                };

                _unitOfWork.Repository<HotPotInventory>().Insert(inventory);
                createdInventories.Add(inventory);
            }

            await _unitOfWork.CommitAsync();

            // Update hotpot quantity
            await UpdateHotpotQuantity(hotpotId);

            return createdInventories;
        }

        public async Task UpdateAsync(int id, HotPotInventory entity)
        {
            var existingInventory = await GetByIdAsync(id);
            if (existingInventory == null)
            {
                throw new NotFoundException($"Inventory unit with ID {id} not found");
            }

            // Validate series number uniqueness if changed
            if (existingInventory.SeriesNumber != entity.SeriesNumber &&
                !await IsSeriesNumberUniqueAsync(entity.SeriesNumber, id))
            {
                throw new ValidationException($"Inventory unit with series number '{entity.SeriesNumber}' already exists");
            }

            existingInventory.SeriesNumber = entity.SeriesNumber;
            existingInventory.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inventory = await GetByIdAsync(id);
            if (inventory == null)
            {
                throw new NotFoundException($"Inventory unit with ID {id} not found");
            }

            // Check if there are any condition logs for this inventory
            var hasConditionLogs = inventory.ConditionLogs != null && inventory.ConditionLogs.Any(cl => !cl.IsDelete);
            if (hasConditionLogs)
            {
                throw new ValidationException("Cannot delete inventory unit that has condition logs");
            }

            int hotpotId = inventory.HotpotId;

            inventory.SoftDelete();
            await _unitOfWork.CommitAsync();

            // Update hotpot quantity
            await UpdateHotpotQuantity(hotpotId);
        }

        public async Task<bool> IsSeriesNumberUniqueAsync(string seriesNumber, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return !await _unitOfWork.Repository<HotPotInventory>()
                    .AnyAsync(i => i.SeriesNumber == seriesNumber && i.HotPotInventoryId != excludeId && !i.IsDelete);
            }
            else
            {
                return !await _unitOfWork.Repository<HotPotInventory>()
                    .AnyAsync(i => i.SeriesNumber == seriesNumber && !i.IsDelete);
            }
        }

        public async Task<int> GetInventoryCountByHotpotIdAsync(int hotpotId)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .AsQueryable(i => i.HotpotId == hotpotId && !i.IsDelete)
                .CountAsync();
        }

        private async Task UpdateHotpotQuantity(int hotpotId)
        {
            // Update the quantity in the Hotpot entity based on inventory count
            var count = await GetInventoryCountByHotpotIdAsync(hotpotId);

            var hotpot = await _unitOfWork.Repository<Hotpot>()
                .FindAsync(h => h.HotpotId == hotpotId);

            if (hotpot != null)
            {
                hotpot.Quantity = count;
                hotpot.SetUpdateDate();
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
