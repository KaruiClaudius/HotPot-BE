using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Extensions;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class EquipmentConditionService : IEquipmentConditionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;


        public EquipmentConditionService(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        // Existing methods remain the same
        public async Task<EquipmentConditionDetailDto> LogEquipmentConditionAsync(CreateEquipmentConditionRequest request)
        {
            // Create entity from request
            var conditionLog = new DamageDevice
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                LoggedDate = DateTime.UtcNow.AddHours(7),
                HotPotInventoryId = request.HotPotInventoryId
            };

            _unitOfWork.Repository<DamageDevice>().Insert(conditionLog);
            await _unitOfWork.CommitAsync();

            // Load related entities
            conditionLog.HotPotInventory = await _unitOfWork.Repository<HotPotInventory>()
                .AsQueryable(h => h.HotPotInventoryId == conditionLog.HotPotInventoryId)
                .Include(h => h.Hotpot)
                .FirstOrDefaultAsync();

            // Publish event to notify about the condition log
            _eventPublisher.Publish(new EquipmentConditionLoggedEvent
            {
                HotPotInventoryId = conditionLog.HotPotInventoryId,
                Status = conditionLog.Status,
                Description = conditionLog.Description
            });

            // Optionally update equipment status directly if requested
            if (request.UpdateEquipmentStatus)
            {
                await UpdateEquipmentStatusBasedOnCondition(
                    conditionLog.HotPotInventoryId,
                    conditionLog.Status,
                    conditionLog.Description);
            }

            // Convert to DTO and return
            return conditionLog.ToDetailDto();
        }


        public async Task<EquipmentConditionDetailDto> GetConditionLogByIdAsync(int conditionLogId)
        {
            var entity = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.DamageDeviceId == conditionLogId)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .FirstOrDefaultAsync();

            return entity?.ToDetailDto();
        }

        public async Task<PagedResult<EquipmentConditionListItemDto>> GetConditionLogsByEquipmentAsync(
     string equipmentType, int equipmentId, PaginationParams paginationParams)
        {
            // Only support hotpot equipment type
            if (equipmentType.ToLower() != "hotpot")
            {
                return new PagedResult<EquipmentConditionListItemDto>
                {
                    Items = new List<EquipmentConditionListItemDto>(),
                    TotalCount = 0,
                    PageNumber = paginationParams.PageNumber,
                    PageSize = paginationParams.PageSize
                };
            }

            var query = _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.HotPotInventoryId == equipmentId)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h.Hotpot)
                .OrderByDescending(c => c.LoggedDate);

            var pagedResult = await query.ToPagedResultAsync(paginationParams);
            return pagedResult.ToPagedListItemDto();
        }

        public async Task<PagedResult<EquipmentConditionListItemDto>> GetConditionLogsByStatusAsync(
               MaintenanceStatus status, PaginationParams paginationParams)
        {
            var query = _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.Status == status)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .OrderByDescending(c => c.LoggedDate);

            var pagedResult = await query.ToPagedResultAsync(paginationParams);
            return pagedResult.ToPagedListItemDto();
        }

        public async Task<PagedResult<EquipmentConditionListItemDto>> GetFilteredConditionLogsAsync(
        EquipmentConditionFilterDto filterParams)
        {
            IQueryable<DamageDevice> query = _unitOfWork.Repository<DamageDevice>().GetAll();

            // Apply filters
            // Filter by equipment type - only support hotpot
            if (!string.IsNullOrEmpty(filterParams.EquipmentType) &&
                filterParams.EquipmentType.ToLower() == "hotpot")
            {
                // If ID is also provided, further filter by ID
                if (filterParams.EquipmentId.HasValue)
                {
                    query = query.Where(c => c.HotPotInventoryId == filterParams.EquipmentId);
                }
            }
            // If only equipment ID is provided without type
            else if (filterParams.EquipmentId.HasValue)
            {
                query = query.Where(c => c.HotPotInventoryId == filterParams.EquipmentId);
            }

            // Filter by equipment name
            if (!string.IsNullOrEmpty(filterParams.EquipmentName))
            {
                string equipmentName = filterParams.EquipmentName.ToLower();

                query = query.Where(c =>
                    c.HotPotInventory != null && c.HotPotInventory.Hotpot != null &&
                    c.HotPotInventory.Hotpot.Name.ToLower().Contains(equipmentName)
                );
            }

            if (filterParams.Status.HasValue)
            {
                query = query.Where(c => c.Status == filterParams.Status);
            }

            // Include related entities
            query = query
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null);

            // Apply sorting
            if (!string.IsNullOrEmpty(filterParams.SortBy))
            {
                switch (filterParams.SortBy.ToLower())
                {
                    case "name":
                        query = filterParams.SortDescending
                            ? query.OrderByDescending(c => c.Name)
                            : query.OrderBy(c => c.Name);
                        break;
                    case "status":
                        query = filterParams.SortDescending
                            ? query.OrderByDescending(c => c.Status)
                            : query.OrderBy(c => c.Status);
                        break;
                    case "loggeddate":
                    default:
                        query = filterParams.SortDescending
                            ? query.OrderByDescending(c => c.LoggedDate)
                            : query.OrderBy(c => c.LoggedDate);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(c => c.LoggedDate);
            }

            var pagedResult = await query.ToPagedResultAsync(filterParams);
            return pagedResult.ToPagedListItemDto();
        }

        public async Task<EquipmentConditionDetailDto> UpdateConditionStatusAsync(int conditionLogId, UpdateConditionStatusRequest request)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.DamageDeviceId == conditionLogId)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .FirstOrDefaultAsync();

            if (conditionLog == null)
                return null;

            // Update status
            conditionLog.Status = request.Status;
            conditionLog.UpdatedAt = DateTime.UtcNow.AddHours(7);

            // Set finish date if status is Completed or Cancelled
            if (request.Status == MaintenanceStatus.Completed || request.Status == MaintenanceStatus.Cancelled)
            {
                conditionLog.FinishDate = DateTime.UtcNow.AddHours(7);
            }

            // If status is changing from Completed/Cancelled to something else, clear the finish date
            if (conditionLog.Status != MaintenanceStatus.Completed &&
                conditionLog.Status != MaintenanceStatus.Cancelled)
            {
                // Only reset if it was previously set
                if (conditionLog.FinishDate != default)
                {
                    conditionLog.FinishDate = default;
                }
            }

            await _unitOfWork.CommitAsync();

            return conditionLog.ToDetailDto();
        }

        private async Task UpdateEquipmentStatusBasedOnCondition(
         int? hotPotInventoryId,
         MaintenanceStatus status,
         string description)
        {
            // Only update status for severe conditions
            if (status != MaintenanceStatus.Pending || !hotPotInventoryId.HasValue)
                return;

            var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                .FindAsync(h => h.HotPotInventoryId == hotPotInventoryId.Value);

            if (hotpot != null)
            {
                // Set to damaged if condition is pending
                hotpot.Status = HotpotStatus.Damaged;
                hotpot.UpdatedAt = DateTime.UtcNow.AddHours(7);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}