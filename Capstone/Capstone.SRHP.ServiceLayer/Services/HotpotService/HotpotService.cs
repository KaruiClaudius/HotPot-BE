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
                    query = query.Where(i =>
                        EF.Functions.Collate(i.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        EF.Functions.Collate(i.Material.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        i.Description != null && EF.Functions.Collate(i.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                    );
                }

                if (isAvailable.HasValue)
                {
                    if (isAvailable.Value)
                    {
                        query = query.Where(h => h.Quantity > 0);
                    }
                    else
                    {
                        query = query.Where(h => h.Quantity <= 0);
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
                    throw new NotFoundException($"Không tìm thấy nồi lẩu với ID {id}");

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

        public async Task<HotPotInventory> GetByInvetoryIdAsync(int inventoryId)
        {
            try
            {
                var inventoryItem = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(h => h.HotPotInventoryId == inventoryId && !h.IsDelete);

                if (inventoryItem == null)
                    throw new NotFoundException($"Không tìm thấy mục kho với ID {inventoryId}");

                // Load inventory items
                var logItems = await _unitOfWork.Repository<DamageDevice>()
                    .FindAll(i => i.HotPotInventoryId == inventoryId && !i.IsDelete)
                    .ToListAsync();

                inventoryItem.ConditionLogs = logItems;

                return inventoryItem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving inventory item with ID {inventoryId}", inventoryId);
                throw;
            }
        }

        public async Task<Hotpot> CreateAsync(Hotpot entity, string[] seriesNumbers)
        {
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Validate basic properties
                ValidateHotpotBasicProperties(entity);

                // Check if a soft-deleted hotpot with the same name exists
                var existingHotpot = await _unitOfWork.Repository<Hotpot>()
                    .FindAsync(h => h.Name == entity.Name);

                if (existingHotpot != null)
                {
                    if (!existingHotpot.IsDelete)
                    {
                        throw new ValidationException($"Nồi lẩu với tên '{entity.Name}' đã tồn tại");
                    }
                    else
                    {
                        // Reactivate and update the soft-deleted hotpot
                        existingHotpot.IsDelete = false;
                        existingHotpot.Material = entity.Material;
                        existingHotpot.Size = entity.Size;
                        existingHotpot.Description = entity.Description;
                        existingHotpot.ImageURL = entity.ImageURL;
                        existingHotpot.Price = entity.Price;
                        existingHotpot.BasePrice = entity.BasePrice;
                        existingHotpot.LastMaintainDate = DateTime.UtcNow.AddHours(7);
                        existingHotpot.SetUpdateDate();

                        await _unitOfWork.CommitAsync();

                        // Set quantity based on series numbers
                        if (seriesNumbers != null && seriesNumbers.Length > 0)
                        {
                            // Validate serial numbers
                            await ValidateSerialNumbers(existingHotpot.HotpotId, seriesNumbers);

                            // Add inventory items
                            await AddInventoryItemsAsync(existingHotpot.HotpotId, seriesNumbers);
                        }

                        // Reload the hotpot with its inventory items
                        return await GetByIdAsync(existingHotpot.HotpotId);
                    }
                }

                entity.LastMaintainDate = DateTime.UtcNow.AddHours(7);

                // Set quantity based on series numbers
                if (seriesNumbers != null && seriesNumbers.Length > 0)
                {
                    // Validate serial numbers
                    await ValidateSerialNumbers(0, seriesNumbers); // Pass 0 for new hotpot

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
                    await AddInventoryItemsAsync(entity.HotpotId, seriesNumbers);
                }

                // Reload the hotpot with its inventory items
                var createdHotpot = await GetByIdAsync(entity.HotpotId);

                return createdHotpot;
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Lỗi khi tạo nồi lẩu");
                }
            });
        }

        public async Task UpdateAsync(int id, Hotpot entity, string[] seriesNumbers)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var existingHotpot = await GetByIdAsync(id);
                if (existingHotpot == null)
                    throw new NotFoundException($"Không tìm thấy nồi lẩu với ID {id}");

                // Validate basic properties
                ValidateHotpotBasicProperties(entity);

                // Check if name is unique (excluding current entity)
                var nameExists = await _unitOfWork.Repository<Hotpot>()
                    .AnyAsync(h => h.Name == entity.Name && h.HotpotId != id && !h.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Nồi lẩu với tên '{entity.Name}' đã tồn tại");

                // If series numbers are provided, update inventory items and quantity
                if (seriesNumbers != null)
                {
                    await UpdateInventoryItems(id, seriesNumbers);

                    // Update quantity to match the number of active inventory items
                    var activeInventoryCount = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAll(i => i.HotpotId == id && !i.IsDelete)
                        .CountAsync();

                    entity.Quantity = activeInventoryCount;
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
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Lỗi khi cập nhật nồi lẩu với ID {HotpotId}", id);
                }
            });
        }


        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var hotpot = await GetByIdAsync(id);
                if (hotpot == null)
                    throw new NotFoundException($"Không tìm thấy nồi lẩu với ID {id}");

                // Check if any inventory items are currently rented
                var rentedItems = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(i => i.HotpotId == id && !i.IsDelete && i.Status == HotpotStatus.Rented)
                    .ToListAsync();

                if (rentedItems.Any())
                {
                    throw new ValidationException(
                        $"Không thể xóa nồi lẩu vì một số mục kho đang được thuê: {string.Join(", ", rentedItems.Select(i => i.SeriesNumber))}");
                }

                // Soft delete all inventory items
                var inventoryItems = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(i => i.HotpotId == id && !i.IsDelete)
                    .ToListAsync();

                foreach (var item in inventoryItems)
                {
                    item.SoftDelete();
                    await _unitOfWork.Repository<HotPotInventory>().Update(item, item.HotPotInventoryId);
                }

                // Soft delete the hotpot
                hotpot.SoftDelete();
                await _unitOfWork.Repository<Hotpot>().Update(hotpot, id);

                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error deleting hotpot with ID {HotpotId}", id);
                }
            });
        }

        public async Task<decimal> CalculateDepositAsync(int id, int quantity)
        {
            try
            {
                var hotpot = await GetByIdAsync(id);
                if (hotpot == null)
                    throw new NotFoundException($"Không tìm thấy nồi lẩu với ID {id}");

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

        public async Task<int> CountDamageDevice()
        {
            try
            {
                return await _unitOfWork.Repository<HotPotInventory>().AsQueryable()
                        .Where(h => !h.IsDelete && h.Status == HotpotStatus.Damaged).CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Không lấy được số nồi cần bảo trì");
                throw;
            }
        }

        public async Task<bool> IsAvailableAsync(int id)
        {
            try
            {
                // Check if the hotpot exists and is active
                var hotpot = await _unitOfWork.Repository<Hotpot>()
                    .FindAsync(h => h.HotpotId == id && !h.IsDelete);

                if (hotpot == null)
                    return false;

                // Count available inventory units (not deleted and with Available status)
                var availableUnitsCount = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(i => i.HotpotId == id && !i.IsDelete && i.Status == HotpotStatus.Available)
                    .CountAsync();

                // Return true if there's at least one available unit
                return availableUnitsCount > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking availability for hotpot with ID {HotpotId}", id);
                throw;
            }
        }


        public async Task UpdateInventoryStatusAsync(int inventoryId, HotpotStatus newStatus)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var inventoryItem = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(i => i.HotPotInventoryId == inventoryId && !i.IsDelete);

                if (inventoryItem == null)
                    throw new NotFoundException($"Không tìm thấy mục kho với ID {inventoryId}");

                // Update the status
                inventoryItem.Status = newStatus;
                if (newStatus == HotpotStatus.Available)
                {
                    inventoryItem.Hotpot.Quantity += 1; 
                }
                else 
                {
                    inventoryItem.Hotpot.Quantity -= 1;
                }
                await _unitOfWork.Repository<HotPotInventory>().Update(inventoryItem, inventoryId);

                // Update the parent hotpot's quantity if status changes to/from Available
                //await SyncHotpotQuantityAsync(inventoryItem.HotpotId);

                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating inventory status for ID {InventoryId}", inventoryId);
                }
            });
        }

        public async Task UpdateQuantityAsync(int hotpotId)
        {
            try
            {
                await SyncHotpotQuantityAsync(hotpotId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot quantity for ID {HotpotId}", hotpotId);
                throw;
            }
        }

        private async Task SyncHotpotQuantityAsync(int hotpotId)
        {
            try
            {
                var availableInventoryCount = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(i => i.HotpotId == hotpotId && !i.IsDelete && i.Status == HotpotStatus.Available)
                    .CountAsync();

                var hotpot = await _unitOfWork.Repository<Hotpot>().FindAsync(h => h.HotpotId == hotpotId && !h.IsDelete);
                if (hotpot != null)
                {
                    hotpot.Quantity = availableInventoryCount;
                    await _unitOfWork.Repository<Hotpot>().Update(hotpot, hotpotId);
                    await _unitOfWork.CommitAsync(); // Commit the changes
                }
                else
                {
                    _logger.LogWarning("Hotpot with ID {HotpotId} not found or is deleted", hotpotId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SyncHotpotQuantityAsync for hotpot ID {HotpotId}", hotpotId);
                throw;
            }
        }

        private async Task<List<HotPotInventory>> AddInventoryItemsAsync(int hotpotId, string[] seriesNumbers)
        {
            if (seriesNumbers == null || seriesNumbers.Length == 0)
                return new List<HotPotInventory>();

            // Validate series numbers
            await ValidateSerialNumbers(hotpotId, seriesNumbers);

            // Check for soft-deleted inventory items with the same series numbers
            var reactivatedItems = new List<HotPotInventory>();
            var newSeriesNumbers = new List<string>();

            foreach (var seriesNumber in seriesNumbers)
            {
                var existingItem = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(i => i.SeriesNumber == seriesNumber && i.IsDelete);

                if (existingItem != null && existingItem.HotpotId == hotpotId)
                {
                    // Reactivate the soft-deleted inventory item
                    existingItem.IsDelete = false;
                    existingItem.Status = HotpotStatus.Available;
                    existingItem.Hotpot.Quantity += 1; 
                    existingItem.SetUpdateDate();
                    await _unitOfWork.Repository<HotPotInventory>().Update(existingItem, existingItem.HotPotInventoryId);
                    reactivatedItems.Add(existingItem);
                }
                else
                {
                    newSeriesNumbers.Add(seriesNumber);
                }
            }

            // Add new inventory items
            var inventoryItems = new List<HotPotInventory>();

            foreach (var seriesNumber in newSeriesNumbers)
            {
                var inventoryItem = new HotPotInventory
                {
                    SeriesNumber = seriesNumber,
                    HotpotId = hotpotId,
                    Status = HotpotStatus.Available
                };

                _unitOfWork.Repository<HotPotInventory>().Insert(inventoryItem);
                inventoryItems.Add(inventoryItem);
            }


            await _unitOfWork.CommitAsync();

            // Update the hotpot quantity to reflect the new inventory items
            //await SyncHotpotQuantityAsync(hotpotId);

            // Combine reactivated and new items
            inventoryItems.AddRange(reactivatedItems);
            return inventoryItems;
        }

        private async Task UpdateInventoryItems(int hotpotId, string[] seriesNumbers)
        {
            // Get existing inventory items
            var existingItems = await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(i => i.HotpotId == hotpotId && !i.IsDelete)
                .ToListAsync();

            var existingSerialNumbers = existingItems.Select(i => i.SeriesNumber).ToList();

            // Check if any items are currently rented
            var rentedItems = existingItems.Where(i => i.Status == HotpotStatus.Rented).ToList();
            var rentedSerialNumbers = rentedItems.Select(i => i.SeriesNumber).ToList();

            // Check if any rented items are being removed
            var removedRentedItems = rentedSerialNumbers
                .Where(sn => !seriesNumbers.Contains(sn))
                .ToList();

            if (removedRentedItems.Any())
            {
                throw new ValidationException(
                    $"Không thể xóa mục kho nồi lẩu đang được thuê: {string.Join(", ", removedRentedItems)}");
            }

            // Identify new serial numbers (ones that don't exist in the current inventory)
            var newSerialNumbers = seriesNumbers
                .Where(sn => !existingSerialNumbers.Contains(sn))
                .ToArray();

            // Validate the new serial numbers
            if (newSerialNumbers.Length > 0)
            {
                await ValidateSerialNumbers(hotpotId, newSerialNumbers);
            }

            // Identify serial numbers to remove
            var serialNumbersToRemove = existingSerialNumbers
                .Where(sn => !seriesNumbers.Contains(sn))
                .ToList();

            // Add new inventory items
            if (newSerialNumbers.Length > 0)
            {
                await AddInventoryItemsAsync(hotpotId, newSerialNumbers);
            }

            // Remove items that are no longer in the list
            foreach (var item in existingItems.Where(i => serialNumbersToRemove.Contains(i.SeriesNumber)))
            {
                item.SoftDelete();
                await _unitOfWork.Repository<HotPotInventory>().Update(item, item.HotPotInventoryId);
            }
        }

        private void ValidateHotpotBasicProperties(Hotpot entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Tên nồi lẩu không được để trống");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Chất liệu nồi lẩu không được để trống");

            if (string.IsNullOrWhiteSpace(entity.Size))
                throw new ValidationException("Kích thước phải được chỉ định");

            if (entity.Price <= 0)
                throw new ValidationException("Giá phải lớn hơn 0");

            if (entity.BasePrice <= 0)
                throw new ValidationException("Giá cơ bản phải lớn hơn 0");
        }

        private async Task ValidateSerialNumbers(int hotpotId, string[] seriesNumbers)
        {
            if (seriesNumbers == null || seriesNumbers.Length == 0)
                return;

            // Check for empty or whitespace serial numbers
            foreach (var seriesNumber in seriesNumbers)
            {
                if (string.IsNullOrWhiteSpace(seriesNumber))
                    throw new ValidationException("Serial number cannot be empty");
            }

            // Check for duplicates within the provided array
            var duplicates = seriesNumbers
                .GroupBy(s => s)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Any())
            {
                throw new ValidationException($"Found duplicate serial numbers in your input: {string.Join(", ", duplicates)}");
            }

            // Check if any of these serial numbers already exist for the SAME hotpot type
            // This is the modified part - we now include the hotpotId in our query
            var existingInventories = await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(i => seriesNumbers.Contains(i.SeriesNumber) && !i.IsDelete)
                .Include(i => i.Hotpot) // Include the Hotpot to access its ID
                .ToListAsync();

            // Filter to only consider duplicates for the same hotpot type
            var duplicatesForSameHotpot = existingInventories
                .Where(i => i.HotpotId == hotpotId)
                .Select(i => i.SeriesNumber)
                .ToList();

            if (duplicatesForSameHotpot.Any())
            {
                throw new ValidationException($"Serial numbers already exist for this hotpot type: {string.Join(", ", duplicatesForSameHotpot)}");
            }

        }

    }
}

