using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IEquipmentConditionService
    {
        Task<EquipmentConditionDetailDto> LogEquipmentConditionAsync(CreateEquipmentConditionRequest request);
        Task<EquipmentConditionDetailDto> GetConditionLogByIdAsync(int conditionLogId);

        Task<PagedResult<EquipmentConditionListItemDto>> GetConditionLogsByEquipmentAsync(
            string equipmentType, int equipmentId, PaginationParams paginationParams);

        Task<PagedResult<EquipmentConditionListItemDto>> GetConditionLogsByStatusAsync(
            MaintenanceStatus status, PaginationParams paginationParams);      
        
        Task<PagedResult<EquipmentConditionListItemDto>> GetFilteredConditionLogsAsync(
            EquipmentConditionFilterDto filterParams);

        Task<EquipmentConditionDetailDto> UpdateConditionStatusAsync(int conditionLogId, UpdateConditionStatusRequest request);
    }
}