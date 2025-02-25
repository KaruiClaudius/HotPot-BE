using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
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
                .Include(hi => hi.Hotpot)
                .Where(hi => !hi.IsDelete)
                .ToListAsync();
        }

        public async Task<HotPotInventory?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .Include(hi => hi.Hotpot)
                .FirstOrDefaultAsync(hi => hi.HotpotId == id && !hi.IsDelete);
        }

        public async Task<HotPotInventory> CreateAsync(HotPotInventory entity)
        {
            // Validate SeriesNumber
            if (string.IsNullOrWhiteSpace(entity.SeriesNumber))
                entity.SeriesNumber = await GenerateSeriesNumberAsync();

            // Check for duplicate SeriesNumber
            var exists = await _unitOfWork.Repository<HotPotInventory>()
                .FindAsync(hi => hi.SeriesNumber == entity.SeriesNumber && !hi.IsDelete);

            if (exists != null)
                throw new ValidationException($"Inventory with series number {entity.SeriesNumber} already exists");

            _unitOfWork.Repository<HotPotInventory>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, HotPotInventory entity)
        {
            var existingInventory = await GetByIdAsync(id);
            if (existingInventory == null)
                throw new NotFoundException($"Inventory with ID {id} not found");

            // Check for duplicate SeriesNumber if changed
            if (entity.SeriesNumber != existingInventory.SeriesNumber)
            {
                var exists = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(hi => hi.SeriesNumber == entity.SeriesNumber && hi.HotPotInventoryId != id && !hi.IsDelete);

                if (exists != null)
                    throw new ValidationException($"Inventory with series number {entity.SeriesNumber} already exists");
            }

            entity.SetUpdateDate();
            await _unitOfWork.Repository<HotPotInventory>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inventory = await GetByIdAsync(id);
            if (inventory == null)
                throw new NotFoundException($"Inventory with ID {id} not found");

            inventory.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<HotPotInventory>> GetAvailableInventoryAsync()
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .Include(hi => hi.Hotpot)
                .Where(hi => !hi.IsDelete)
                .ToListAsync();
        }

        public async Task<string> GenerateSeriesNumberAsync()
        {
            var prefix = "HP";
            var date = DateTime.UtcNow.ToString("yyyyMMdd");
            var lastInventory = await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(hi => hi.SeriesNumber.StartsWith(prefix + date))
                .ToListAsync();

            var sequence = (lastInventory.Count + 1).ToString("D4");
            return $"{prefix}{date}{sequence}";
        }

        public async Task<HotPotInventory?> GetBySeriesNumberAsync(string seriesNumber)
        {
            return await _unitOfWork.Repository<HotPotInventory>()
                .Include(hi => hi.Hotpot)
                .FirstOrDefaultAsync(hi => hi.SeriesNumber == seriesNumber && !hi.IsDelete);
        }

        public async Task<IEnumerable<Hotpot>> GetAssociatedHotpotsAsync(int inventoryId)
        {
            //var inventory = await GetByIdAsync(inventoryId);
            //if (inventory == null)
            //    throw new NotFoundException($"Inventory with ID {inventoryId} not found");

            //return inventory.Hotpot ?? new List<Hotpot>();
            return null;
        }
    }
}
