using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.HotpotService
{
    public class HotpotService : IHotpotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotpotService> _logger;

        public HotpotService(IUnitOfWork unitOfWork, ILogger<HotpotService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResult<Hotpot>> GetHotpotsAsync(
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
                bool ascending = true)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<Hotpot>().AsQueryable()
                    .Where(h => !h.IsDelete);

                // Apply filters
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(h =>
                        h.Name.ToLower().Contains(searchTerm) ||
                        (h.Description != null && h.Description.ToLower().Contains(searchTerm)) ||
                        h.Material.ToLower().Contains(searchTerm));
                }

                if (isAvailable.HasValue)
                {
                    if (isAvailable.Value)
                    {
                        query = query.Where(h => h.Status && h.Quantity > 0);
                    }
                    else
                    {
                        query = query.Where(h => !h.Status || h.Quantity <= 0);
                    }
                }

                if (!string.IsNullOrWhiteSpace(material))
                {
                    query = query.Where(h => h.Material.ToLower() == material.ToLower());
                }

                if (!string.IsNullOrWhiteSpace(size))
                {
                    query = query.Where(h => h.Size.ToLower() == size.ToLower());
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(h => h.Price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(h => h.Price <= maxPrice.Value);
                }

                if (minQuantity.HasValue)
                {
                    query = query.Where(h => h.Quantity >= minQuantity.Value);
                }

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply sorting
                IOrderedQueryable<Hotpot> orderedQuery;

                switch (sortBy?.ToLower())
                {
                    case "price":
                        orderedQuery = ascending ? query.OrderBy(h => h.Price) : query.OrderByDescending(h => h.Price);
                        break;
                    case "quantity":
                        orderedQuery = ascending ? query.OrderBy(h => h.Quantity) : query.OrderByDescending(h => h.Quantity);
                        break;
                    case "material":
                        orderedQuery = ascending ? query.OrderBy(h => h.Material) : query.OrderByDescending(h => h.Material);
                        break;
                    case "size":
                        orderedQuery = ascending ? query.OrderBy(h => h.Size) : query.OrderByDescending(h => h.Size);
                        break;
                    case "lastmaintaindate":
                        orderedQuery = ascending ? query.OrderBy(h => h.LastMaintainDate) : query.OrderByDescending(h => h.LastMaintainDate);
                        break;
                    case "createdat":
                        orderedQuery = ascending ? query.OrderBy(h => h.CreatedAt) : query.OrderByDescending(h => h.CreatedAt);
                        break;
                    default: // Default to Name
                        orderedQuery = ascending ? query.OrderBy(h => h.Name) : query.OrderByDescending(h => h.Name);
                        break;
                }

                // Apply pagination
                var items = await orderedQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PagedResult<Hotpot>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpots with filters");
                throw;
            }
        }


        public async Task<Hotpot> GetByIdAsync(int id)
        {
            try
            {
                var hotpot = await _unitOfWork.Repository<Hotpot>()
                    .FindAsync(h => h.HotpotId == id && !h.IsDelete);

                if (hotpot == null)
                    return null;

                // Load inventory items
                var inventoryItems = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(i => i.HotpotId == id && !i.IsDelete)
                    .ToListAsync();

                hotpot.InventoryUnits = inventoryItems;

                return hotpot;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot with ID {HotpotId}", id);
                throw;
            }
        }

        public async Task<Hotpot> CreateAsync(Hotpot entity, string[] seriesNumbers = null)
        {
            var executionStrategy = _unitOfWork.Context.Database.CreateExecutionStrategy();

            return await executionStrategy.ExecuteAsync(async () =>
            {
                using var transaction = await _unitOfWork.BeginTransactionAsync();
                try
                {
                    // Validate basic properties
                    if (string.IsNullOrWhiteSpace(entity.Name))
                        throw new ValidationException("Hotpot name cannot be empty");

                    if (string.IsNullOrWhiteSpace(entity.Material))
                        throw new ValidationException("Hotpot material cannot be empty");

                    if (string.IsNullOrWhiteSpace(entity.Size))
                        throw new ValidationException("Size must be specified");

                    if (entity.Price <= 0)
                        throw new ValidationException("Price must be greater than 0");

                    if (entity.BasePrice <= 0)
                        throw new ValidationException("Base price must be greater than 0");

                    entity.LastMaintainDate = DateTime.UtcNow;

                    // Set quantity based on series numbers
                    if (seriesNumbers != null && seriesNumbers.Length > 0)
                    {
                        entity.Quantity = seriesNumbers.Length;
                    }
                    else
                    {
                        entity.Quantity = 0;
                    }

                    // Insert the hotpot
                    _unitOfWork.Repository<Hotpot>().Insert(entity);
                    await _unitOfWork.CommitAsync();

                    // Add inventory items if series numbers are provided
                    if (seriesNumbers != null && seriesNumbers.Length > 0)
                    {
                        await AddInventoryItemsInternalAsync(entity.HotpotId, seriesNumbers);
                    }

                    // Reload the hotpot with its inventory items
                    var createdHotpot = await GetByIdAsync(entity.HotpotId);

                    await transaction.CommitAsync();
                    return createdHotpot;
                }
                catch (ValidationException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Error creating hotpot");
                    throw;
                }
            });
        }

        public async Task UpdateAsync(int id, Hotpot entity, string[] seriesNumbers = null)
        {
            var executionStrategy = _unitOfWork.Context.Database.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using var transaction = await _unitOfWork.BeginTransactionAsync();
                try
                {
                    var existingHotpot = await GetByIdAsync(id);
                    if (existingHotpot == null)
                        throw new NotFoundException($"Hotpot with ID {id} not found");

                    // Validate basic properties
                    if (string.IsNullOrWhiteSpace(entity.Name))
                        throw new ValidationException("Hotpot name cannot be empty");

                    if (string.IsNullOrWhiteSpace(entity.Material))
                        throw new ValidationException("Hotpot material cannot be empty");

                    if (string.IsNullOrWhiteSpace(entity.Size))
                        throw new ValidationException("Size must be specified");

                    if (entity.Price <= 0)
                        throw new ValidationException("Price must be greater than 0");

                    if (entity.BasePrice <= 0)
                        throw new ValidationException("Base price must be greater than 0");

                    // If series numbers are provided, update inventory items and quantity
                    if (seriesNumbers != null && seriesNumbers.Length > 0)
                    {
                        // Get existing inventory items
                        var existingItems = await _unitOfWork.Repository<HotPotInventory>()
                            .FindAll(i => i.HotpotId == id && !i.IsDelete)
                            .ToListAsync();

                        // Soft delete all existing items
                        foreach (var item in existingItems)
                        {
                            item.SoftDelete();
                        }
                        await _unitOfWork.CommitAsync();

                        // Add new inventory items
                        await AddInventoryItemsInternalAsync(id, seriesNumbers);

                        // Update quantity to match the number of series numbers
                        entity.Quantity = seriesNumbers.Length;
                    }
                    else
                    {
                        // Keep the existing quantity if no series numbers are provided
                        entity.Quantity = existingHotpot.Quantity;
                    }

                    // Update the hotpot basic properties
                    entity.SetUpdateDate();
                    await _unitOfWork.Repository<Hotpot>().Update(entity, id);
                    await _unitOfWork.CommitAsync();

                    await transaction.CommitAsync();
                }
                catch (NotFoundException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (ValidationException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Error updating hotpot with ID {HotpotId}", id);
                    throw;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var hotpot = await GetByIdAsync(id);
                if (hotpot == null)
                    throw new NotFoundException($"Hotpot with ID {id} not found");

                hotpot.SoftDelete();
                await _unitOfWork.CommitAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotpot with ID {HotpotId}", id);
                throw;
            }
        }

        public async Task<decimal> CalculateDepositAsync(int id, int quantity)
        {
            try
            {
                var hotpot = await GetByIdAsync(id);
                if (hotpot == null)
                    throw new NotFoundException($"Hotpot with ID {id} not found");

                // Deposit is 70% of the hotpot base price
                return Math.Round((hotpot.BasePrice * quantity) * 0.7m, 2);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating deposit for hotpot with ID {HotpotId}", id);
                throw;
            }
        }

        public async Task<bool> IsAvailableAsync(int id)
        {
            try
            {
                var hotpot = await GetByIdAsync(id);
                return hotpot != null && hotpot.Status && hotpot.Quantity > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking availability for hotpot with ID {HotpotId}", id);
                throw;
            }
        }

        public async Task UpdateQuantityAsync(int hotpotId)
        {
            try
            {
                var inventoryItems = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(i => i.HotpotId == hotpotId && !i.IsDelete && i.Status)
                    .ToListAsync();

                var hotpot = await _unitOfWork.Repository<Hotpot>().FindAsync(h => h.HotpotId == hotpotId);
                if (hotpot != null)
                {
                    hotpot.Quantity = inventoryItems.Count;
                    await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot quantity for ID {HotpotId}", hotpotId);
                throw;
            }
        }

        private async Task<List<HotPotInventory>> AddInventoryItemsInternalAsync(int hotpotId, string[] seriesNumbers)
        {
            if (seriesNumbers == null || seriesNumbers.Length == 0)
                return new List<HotPotInventory>();

            // Validate series numbers
            foreach (var seriesNumber in seriesNumbers)
            {
                if (string.IsNullOrWhiteSpace(seriesNumber))
                    throw new ValidationException("Series number cannot be empty");
            }

            // Check for duplicates in the provided array
            var duplicates = seriesNumbers.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Any())
                throw new ValidationException($"Duplicate series numbers found: {string.Join(", ", duplicates)}");

            // Check if any series numbers already exist in the database
            var existingSeriesNumbers = await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(i => seriesNumbers.Contains(i.SeriesNumber) && !i.IsDelete)
                .Select(i => i.SeriesNumber)
                .ToListAsync();

            if (existingSeriesNumbers.Any())
                throw new ValidationException($"Series numbers already exist: {string.Join(", ", existingSeriesNumbers)}");

            // Add new inventory items
            var inventoryItems = new List<HotPotInventory>();
            foreach (var seriesNumber in seriesNumbers)
            {
                var inventoryItem = new HotPotInventory
                {
                    SeriesNumber = seriesNumber,
                    HotpotId = hotpotId,
                    Status = true // Default to active
                };

                _unitOfWork.Repository<HotPotInventory>().Insert(inventoryItem);
                inventoryItems.Add(inventoryItem);
            }

            await _unitOfWork.CommitAsync();
            return inventoryItems;
        }

        public Task<IEnumerable<Hotpot>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Hotpot> CreateAsync(Hotpot entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Hotpot entity)
        {
            throw new NotImplementedException();
        }
    }
}

