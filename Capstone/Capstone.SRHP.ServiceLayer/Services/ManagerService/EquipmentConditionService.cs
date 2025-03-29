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

        public EquipmentConditionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Existing methods remain the same
        public async Task<EquipmentConditionDetailDto> LogEquipmentConditionAsync(CreateEquipmentConditionRequest request)
        {
            // Validate that either HotPotInventoryId or UtensilId is provided
            if (!request.HotPotInventoryId.HasValue && !request.UtensilId.HasValue)
            {
                throw new ArgumentException("Either HotPotInventoryId or UtensilId must be provided");
            }

            // Create entity from request
            var conditionLog = new DamageDevice
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                LoggedDate = DateTime.UtcNow,
                HotPotInventoryId = request.HotPotInventoryId,
                UtensilId = request.UtensilId
            };

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

            // Convert to DTO and return
            return conditionLog.ToDetailDto();
        }

        public async Task<EquipmentConditionDetailDto> GetConditionLogByIdAsync(int conditionLogId)
        {
            var entity = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.DamageDeviceId == conditionLogId)
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .FirstOrDefaultAsync();

            return entity?.ToDetailDto();
        }
     
        public async Task<PagedResult<EquipmentConditionListItemDto>> GetConditionLogsByEquipmentAsync(
           string equipmentType, int equipmentId, PaginationParams paginationParams)
        {
            IQueryable<DamageDevice> query;

            if (equipmentType.ToLower() == "hotpot")
            {
                query = _unitOfWork.Repository<DamageDevice>()
                    .GetAll(c => c.HotPotInventoryId == equipmentId)
                    .Include(c => c.HotPotInventory)
                        .ThenInclude(h => h.Hotpot)
                    .OrderByDescending(c => c.LoggedDate);
            }
            else if (equipmentType.ToLower() == "utensil")
            {
                query = _unitOfWork.Repository<DamageDevice>()
                    .GetAll(c => c.UtensilId == equipmentId)
                    .Include(c => c.Utensil)
                        .ThenInclude(u => u.UtensilType)
                    .OrderByDescending(c => c.LoggedDate);
            }
            else
            {
                return new PagedResult<EquipmentConditionListItemDto>
                {
                    Items = new List<EquipmentConditionListItemDto>(),
                    TotalCount = 0,
                    PageNumber = paginationParams.PageNumber,
                    PageSize = paginationParams.PageSize
                };
            }

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
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(c => c.LoggedDate);

            var pagedResult = await query.ToPagedResultAsync(paginationParams);
            return pagedResult.ToPagedListItemDto();
        }
   
        public async Task<PagedResult<EquipmentConditionListItemDto>> GetFilteredConditionLogsAsync(
    EquipmentConditionFilterDto filterParams)
        {
            IQueryable<DamageDevice> query = _unitOfWork.Repository<DamageDevice>().GetAll();

            // Apply filters
            if (!string.IsNullOrEmpty(filterParams.EquipmentType) && filterParams.EquipmentId.HasValue)
            {
                if (filterParams.EquipmentType.ToLower() == "hotpot")
                {
                    query = query.Where(c => c.HotPotInventoryId == filterParams.EquipmentId);
                }
                else if (filterParams.EquipmentType.ToLower() == "utensil")
                {
                    query = query.Where(c => c.UtensilId == filterParams.EquipmentId);
                }
            }

            if (filterParams.Status.HasValue)
            {
                query = query.Where(c => c.Status == filterParams.Status);
            }

            if (filterParams.StartDate.HasValue)
            {
                query = query.Where(c => c.LoggedDate >= filterParams.StartDate);
            }

            if (filterParams.EndDate.HasValue)
            {
                query = query.Where(c => c.LoggedDate <= filterParams.EndDate);
            }

            // Include related entities
            query = query
                .Include(c => c.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null);

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
                .Include(c => c.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .FirstOrDefaultAsync();

            if (conditionLog == null)
                return null;

            conditionLog.Status = request.Status;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return conditionLog.ToDetailDto();
        }
    }
}