using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.HotpotService
{
    public class DamageDeviceService : IDamageDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DamageDeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<DamageDevice>> GetAllAsync(DamageDeviceFilterRequest request)
        {
            var query = _unitOfWork.Repository<DamageDevice>()
                .AsQueryable()
                .Include(d => d.Utensil)
                .Include(d => d.HotPotInventory)
                .Where(d => !d.IsDelete);

            // Apply device type filter
            if (request.DeviceType == DeviceType.Hotpot)
            {
                query = query.Where(d => d.HotPotInventoryId != null);
            }
            else if (request.DeviceType == DeviceType.Utensil)
            {
                query = query.Where(d => d.UtensilId != null);
            }

            // Apply other filters
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(d =>
                    d.Name.ToLower().Contains(searchTerm) ||
                    (d.Description != null && d.Description.ToLower().Contains(searchTerm)) ||
                    (d.Utensil != null && d.Utensil.Name.ToLower().Contains(searchTerm)) ||
                    (d.HotPotInventory != null && d.HotPotInventory.SeriesNumber.ToLower().Contains(searchTerm)));
            }

            if (request.Status.HasValue)
            {
                query = query.Where(d => d.Status == request.Status.Value);
            }

            if (request.HotPotInventoryId.HasValue)
            {
                query = query.Where(d => d.HotPotInventoryId == request.HotPotInventoryId.Value);
            }

            if (request.UtensilId.HasValue)
            {
                query = query.Where(d => d.UtensilId == request.UtensilId.Value);
            }

            if (request.FromDate.HasValue)
            {
                var fromDate = request.FromDate.Value.Date;
                query = query.Where(d => d.LoggedDate >= fromDate);
            }

            if (request.ToDate.HasValue)
            {
                var toDate = request.ToDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(d => d.LoggedDate <= toDate);
            }

            // Apply sorting
            IOrderedQueryable<DamageDevice> orderedQuery;
            switch (request.SortBy?.ToLower())
            {
                case "name":
                    orderedQuery = request.Ascending
                        ? query.OrderBy(d => d.Name)
                        : query.OrderByDescending(d => d.Name);
                    break;
                case "status":
                    orderedQuery = request.Ascending
                        ? query.OrderBy(d =>
                            d.Status == MaintenanceStatus.Pending ? 0 :
                            d.Status == MaintenanceStatus.InProgress ? 1 :
                            d.Status == MaintenanceStatus.Completed ? 2 :
                            d.Status == MaintenanceStatus.Cancelled ? 3 : 4)
                        : query.OrderByDescending(d =>
                            d.Status == MaintenanceStatus.Pending ? 0 :
                            d.Status == MaintenanceStatus.InProgress ? 1 :
                            d.Status == MaintenanceStatus.Completed ? 2 :
                            d.Status == MaintenanceStatus.Cancelled ? 3 : 4);
                    break;
                case "loggeddate":
                default:
                    orderedQuery = request.Ascending
                        ? query.OrderBy(d => d.LoggedDate)
                        : query.OrderByDescending(d => d.LoggedDate);
                    break;
            }

            // Get total count
            var totalCount = await query.CountAsync();

            // Apply pagination
            var items = await orderedQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResult<DamageDevice>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }


        public async Task<DamageDevice> GetByIdAsync(int id)
        {
            var damageDevice = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable()
                .Include(d => d.HotPotInventory)
                .Include(d => d.Utensil)
                .Include(d => d.ReplacementRequests)
                .FirstOrDefaultAsync(d => d.DamageDeviceId == id && !d.IsDelete);

            if (damageDevice == null)
                throw new NotFoundException($"Damage device with ID {id} not found");

            return damageDevice;
        }

        public async Task<DamageDevice> CreateAsync(DamageDevice entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Device name cannot be empty");

            // Validate that at least one of HotPotInventoryId or UtensilId is provided
            if (!entity.HotPotInventoryId.HasValue && !entity.UtensilId.HasValue)
                throw new ValidationException("Either HotPotInventoryId or UtensilId must be provided");

            // Validate HotPotInventory exists if provided
            if (entity.HotPotInventoryId.HasValue)
            {
                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(h => h.HotPotInventoryId == entity.HotPotInventoryId.Value && !h.IsDelete);

                if (hotpot == null)
                    throw new ValidationException($"HotPotInventory with ID {entity.HotPotInventoryId.Value} not found");
            }

            // Validate Utensil exists if provided
            if (entity.UtensilId.HasValue)
            {
                var utensil = await _unitOfWork.Repository<Utensil>()
                    .FindAsync(u => u.UtensilId == entity.UtensilId.Value && !u.IsDelete);

                if (utensil == null)
                    throw new ValidationException($"Utensil with ID {entity.UtensilId.Value} not found");
            }

            // Set logged date if not set
            if (entity.LoggedDate == default)
                entity.LoggedDate = DateTime.UtcNow;

            _unitOfWork.Repository<DamageDevice>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, DamageDevice entity)
        {
            var existingDevice = await GetByIdAsync(id);
            if (existingDevice == null)
                throw new NotFoundException($"Damage device with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Device name cannot be empty");

            // Validate that at least one of HotPotInventoryId or UtensilId is provided
            if (!entity.HotPotInventoryId.HasValue && !entity.UtensilId.HasValue)
                throw new ValidationException("Either HotPotInventoryId or UtensilId must be provided");

            // Validate HotPotInventory exists if changed
            if (entity.HotPotInventoryId != existingDevice.HotPotInventoryId && entity.HotPotInventoryId.HasValue)
            {
                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(h => h.HotPotInventoryId == entity.HotPotInventoryId.Value && !h.IsDelete);

                if (hotpot == null)
                    throw new ValidationException($"HotPotInventory with ID {entity.HotPotInventoryId.Value} not found");

                if (entity.Status == MaintenanceStatus.Completed)
                {
                    hotpot.Status = HotpotStatus.Available;
                    await _unitOfWork.Repository<HotPotInventory>().Update(hotpot, id);
                }
            }

            // Validate Utensil exists if changed
            if (entity.UtensilId != existingDevice.UtensilId && entity.UtensilId.HasValue)
            {
                var utensil = await _unitOfWork.Repository<Utensil>()
                    .FindAsync(u => u.UtensilId == entity.UtensilId.Value && !u.IsDelete);

                if (utensil == null)
                    throw new ValidationException($"Utensil with ID {entity.UtensilId.Value} not found");
            }

            // Update the entity
            entity.SetUpdateDate();
            await _unitOfWork.Repository<DamageDevice>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var device = await GetByIdAsync(id);
            if (device == null)
                throw new NotFoundException($"Damage device with ID {id} not found");

            // Check if there are any active replacement requests
            var hasActiveRequests = await _unitOfWork.Repository<ReplacementRequest>()
                .AnyAsync(r => r.DamageDeviceId == id && !r.IsDelete && r.Status != ReplacementRequestStatus.Completed);

            if (hasActiveRequests)
                throw new ValidationException("Cannot delete device with active replacement requests");

            device.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        private IQueryable<DamageDevice> ApplySorting(IQueryable<DamageDevice> query, string sortBy, bool ascending)
        {
            // Default to LoggedDate if sortBy is invalid
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "LoggedDate";
            }

            // Apply sorting based on property name
            switch (sortBy.ToLower())
            {
                case "name":
                    return ascending
                        ? query.OrderBy(d => d.Name)
                        : query.OrderByDescending(d => d.Name);
                case "status":
                    return ascending
                        ? query.OrderBy(d => d.Status)
                        : query.OrderByDescending(d => d.Status);
                case "hotpotinventory":
                    return ascending
                        ? query.OrderBy(d => d.HotPotInventory.SeriesNumber)
                        : query.OrderByDescending(d => d.HotPotInventory.SeriesNumber);
                case "utensil":
                    return ascending
                        ? query.OrderBy(d => d.Utensil.Name)
                        : query.OrderByDescending(d => d.Utensil.Name);
                case "createdat":
                    return ascending
                        ? query.OrderBy(d => d.CreatedAt)
                        : query.OrderByDescending(d => d.CreatedAt);
                case "loggeddate":
                default:
                    return ascending
                        ? query.OrderBy(d => d.LoggedDate)
                        : query.OrderByDescending(d => d.LoggedDate);
            }
        }

        public Task<IEnumerable<DamageDevice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
