using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
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
    public class DamageDeviceService : IDamageDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DamageDeviceService> _logger;
        private readonly IHotpotService _hotpotService;

        public DamageDeviceService(
            IUnitOfWork unitOfWork,
            ILogger<DamageDeviceService> logger,
            IHotpotService hotpotService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _hotpotService = hotpotService;
        }

        public async Task<PagedResult<DamageDevice>> GetAllAsync(DamageDeviceFilterRequest request)
        {
            try
            {
                var query = _unitOfWork.Repository<DamageDevice>()
                    .AsQueryable()
                    .Include(d => d.HotPotInventory)
                    .Where(d => !d.IsDelete);

                // Apply filters
                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    var searchTerm = request.SearchTerm.ToLower();
                    query = query.Where(d =>
                        d.Name.ToLower().Contains(searchTerm) ||
                        (d.Description != null && d.Description.ToLower().Contains(searchTerm)) ||
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
                    case "hotpotinventory":
                        orderedQuery = request.Ascending
                            ? query.OrderBy(d => d.HotPotInventory != null ? d.HotPotInventory.SeriesNumber : string.Empty)
                            : query.OrderByDescending(d => d.HotPotInventory != null ? d.HotPotInventory.SeriesNumber : string.Empty);
                        break;
                    case "createdat":
                        orderedQuery = request.Ascending
                            ? query.OrderBy(d => d.CreatedAt)
                            : query.OrderByDescending(d => d.CreatedAt);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving damage devices with filters");
                throw;
            }
        }



        public async Task<DamageDevice> GetByIdAsync(int id)
        {
            try
            {
                var damageDevice = await _unitOfWork.Repository<DamageDevice>()
                    .AsQueryable()
                    .Include(d => d.HotPotInventory)
                    .Include(d => d.ReplacementRequests)
                    .FirstOrDefaultAsync(d => d.DamageDeviceId == id && !d.IsDelete);

                if (damageDevice == null)
                    throw new NotFoundException($"Không tìm thấy thiết bị hư hỏng với ID {id}");

                return damageDevice;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving damage device with ID {DamageDeviceId}", id);
                throw;
            }
        }

        public async Task<DamageDevice> CreateAsync(DamageDevice entity)
        {
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Validate basic properties
                if (string.IsNullOrWhiteSpace(entity.Name))
                    throw new ValidationException("Tên thiết bị không được để trống");

                // Validate that HotPotInventoryId is provided
                if (!entity.HotPotInventoryId.HasValue)
                    throw new ValidationException("Phải cung cấp HotPotInventoryId");

                // Validate HotPotInventory exists
                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(h => h.HotPotInventoryId == entity.HotPotInventoryId.Value && !h.IsDelete);

                if (hotpot == null)
                    throw new ValidationException($"Không tìm thấy HotPotInventory với ID {entity.HotPotInventoryId.Value}");

                // Set logged date if not set
                if (entity.LoggedDate == default)
                    entity.LoggedDate = DateTime.UtcNow.AddHours(7);

                // Update the hotpot inventory status to Damaged
                hotpot.Status = HotpotStatus.Damaged;
                hotpot.Hotpot.Quantity -= 1; 
                await _unitOfWork.Repository<HotPotInventory>().Update(hotpot, hotpot.HotPotInventoryId);

                // Insert the damage device
                _unitOfWork.Repository<DamageDevice>().Insert(entity);
                await _unitOfWork.CommitAsync();

                // Update the hotpot quantity
                

                return entity;
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error creating damage device");
                }
            });
        }
        public async Task UpdateAsync(int id, DamageDevice entity)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var originalEntity = await _unitOfWork.Repository<DamageDevice>()
                    .FindAsync(d => d.DamageDeviceId == id && !d.IsDelete);

                if (originalEntity == null)
                    throw new NotFoundException($"Không tìm thấy thiết bị hư hỏng với ID {id}");

                // Store original values for comparison
                var originalStatus = originalEntity.Status;
                var originalHotpotId = originalEntity.HotPotInventoryId;

                if (!string.IsNullOrWhiteSpace(entity.Name))
                    originalEntity.Name = entity.Name;

                if (entity.Description != null) // Allow empty description
                    originalEntity.Description = entity.Description;

                // Only update status if it's different
                if (entity.Status != default && entity.Status != originalEntity.Status)
                    originalEntity.Status = entity.Status;

                // Only update hotpot if it's provided and different
                if (entity.HotPotInventoryId.HasValue && entity.HotPotInventoryId != originalEntity.HotPotInventoryId)
                    originalEntity.HotPotInventoryId = entity.HotPotInventoryId;

                // Validate after updates
                if (string.IsNullOrWhiteSpace(originalEntity.Name))
                    throw new ValidationException("Tên thiết bị không được để trống");

                if (!originalEntity.HotPotInventoryId.HasValue)
                    throw new ValidationException("Phải cung cấp HotPotInventoryId");

                // Check if HotPotInventoryId has changed
                bool hotpotChanged = originalEntity.HotPotInventoryId != originalHotpotId;
                bool statusChanged = originalEntity.Status != originalStatus;

                // Handle status changes
                if (statusChanged || hotpotChanged)
                {
                    _logger.LogInformation(
                        "Updating damage device {Id}: Status changed from {OldStatus} to {NewStatus}, " +
                        "Hotpot changed from {OldHotpot} to {NewHotpot}",
                        id, originalStatus, originalEntity.Status,
                        originalHotpotId, originalEntity.HotPotInventoryId);
                }

                // Validate HotPotInventory exists if changed
                if (hotpotChanged)
                {
                    var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAsync(h => h.HotPotInventoryId == originalEntity.HotPotInventoryId.Value && !h.IsDelete);

                    if (hotpot == null)
                        throw new ValidationException($"Không tìm thấy HotPotInventory với ID {originalEntity.HotPotInventoryId.Value}");
                }

                // Update the entity
                originalEntity.SetUpdateDate();
                await _unitOfWork.Repository<DamageDevice>().Update(originalEntity, id);

                // Handle status changes
                if (statusChanged || hotpotChanged)
                {
                    // If status changed to Completed, update the hotpot inventory status
                    if (originalEntity.Status == MaintenanceStatus.Completed)
                    {
                        var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                            .Include(h => h.Hotpot)
                            .FirstOrDefaultAsync(h => h.HotPotInventoryId == originalEntity.HotPotInventoryId.Value && !h.IsDelete);

                        if (hotpot != null)
                        {
                            // Update hotpot status
                            hotpot.Status = HotpotStatus.Available;
                            hotpot.Hotpot.Quantity += 1;
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpot, hotpot.HotPotInventoryId);
                        }
                    }

                    // If the hotpot changed, update the old hotpot's status if no other damage reports exist
                    if (hotpotChanged && originalHotpotId.HasValue)
                    {
                        var oldHotpot = await _unitOfWork.Repository<HotPotInventory>()
                            .FindAsync(h => h.HotPotInventoryId == originalHotpotId.Value && !h.IsDelete);

                        if (oldHotpot != null)
                        {
                            // Check if there are any other active damage reports for this hotpot
                            var otherDamageReports = await _unitOfWork.Repository<DamageDevice>()
                                .FindAll(d => d.HotPotInventoryId == oldHotpot.HotPotInventoryId &&
                                             d.DamageDeviceId != id &&
                                             !d.IsDelete &&
                                             d.Status != MaintenanceStatus.Completed &&
                                             d.Status != MaintenanceStatus.Cancelled)
                                .AnyAsync();

                            if (!otherDamageReports)
                            {
                                // Update old hotpot status
                                oldHotpot.Status = HotpotStatus.Available;
                                oldHotpot.Hotpot.Quantity += 1;
                            }
                        }
                    }
                }
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating damage device with ID {DamageDeviceId}", id);
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var device = await GetByIdAsync(id);
                if (device == null)
                    throw new NotFoundException($"Không tìm thấy thiết bị hư hỏng với ID {id}");

                // Check if there are any active replacement requests
                var hasActiveRequests = await _unitOfWork.Repository<ReplacementRequest>()
                    .AnyAsync(r => r.DamageDeviceId == id && !r.IsDelete && r.Status != ReplacementRequestStatus.Completed);

                if (hasActiveRequests)
                    throw new ValidationException("Không thể xóa thiết bị có yêu cầu thay thế đang hoạt động");

                // If this is the only damage report for the hotpot, update the hotpot status
                if (device.HotPotInventoryId.HasValue)
                {
                    var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAsync(h => h.HotPotInventoryId == device.HotPotInventoryId.Value && !h.IsDelete);

                    if (hotpot != null)
                    {
                        // Check if there are any other active damage reports for this hotpot
                        var otherDamageReports = await _unitOfWork.Repository<DamageDevice>()
                            .FindAll(d => d.HotPotInventoryId == hotpot.HotPotInventoryId &&
                                         d.DamageDeviceId != id &&
                                         !d.IsDelete &&
                                         d.Status != MaintenanceStatus.Completed &&
                                         d.Status != MaintenanceStatus.Cancelled)
                            .AnyAsync();

                        if (!otherDamageReports)
                        {
                            hotpot.Status = HotpotStatus.Available;
                            hotpot.Hotpot.Quantity += 1; // Restore the quantity
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpot, hotpot.HotPotInventoryId);

                            // Update the hotpot quantity
                            //await _hotpotService.UpdateQuantityAsync(hotpot.HotpotId);
                        }
                    }
                }

                // Soft delete the damage device
                device.SoftDelete();
                await _unitOfWork.Repository<DamageDevice>().Update(device, id);

                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error deleting damage device with ID {DamageDeviceId}", id);
                }
            });
        }
        private async Task UpdateHotpotInventoryStatusAsync(int hotpotInventoryId, MaintenanceStatus damageStatus)
        {
            var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                .FindAsync(h => h.HotPotInventoryId == hotpotInventoryId && !h.IsDelete);

            if (hotpot == null)
                return;

            // If damage is completed, check if there are any other active damage reports
            if (damageStatus == MaintenanceStatus.Completed || damageStatus == MaintenanceStatus.Cancelled)
            {
                var otherDamageReports = await _unitOfWork.Repository<DamageDevice>()
                    .FindAll(d => d.HotPotInventoryId == hotpotInventoryId &&
                                 !d.IsDelete &&
                                 d.Status != MaintenanceStatus.Completed &&
                                 d.Status != MaintenanceStatus.Cancelled)
                    .AnyAsync();

                // If no other active damage reports, set hotpot to Available
                if (!otherDamageReports)
                {
                    hotpot.Status = HotpotStatus.Available;
                    hotpot.Hotpot.Quantity += 1; // Restore the quantity
                    await _unitOfWork.Repository<HotPotInventory>().Update(hotpot, hotpotInventoryId);

                    // Update the hotpot quantity
                    //await _hotpotService.UpdateQuantityAsync(hotpot.HotpotId);
                }
            }
            else if (damageStatus == MaintenanceStatus.Pending || damageStatus == MaintenanceStatus.InProgress)
            {
                // If damage is pending or in progress, set hotpot to Damaged
                hotpot.Status = HotpotStatus.Damaged;
                hotpot.Hotpot.Quantity -= 1; // Decrease the quantity
                await _unitOfWork.Repository<HotPotInventory>().Update(hotpot, hotpotInventoryId);

                // Update the hotpot quantity
                //await _hotpotService.UpdateQuantityAsync(hotpot.HotpotId);
            }
        }


        public Task<IEnumerable<DamageDevice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
