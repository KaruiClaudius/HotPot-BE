using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using System.Collections.Generic;
using System.Linq;

namespace Capstone.HPTY.ServiceLayer.Extensions
{
    public static class EquipmentConditionMappingExtensions
    {
        public static EquipmentConditionDto ToDto(this DamageDevice entity)
        {
            if (entity == null)
                return null;

            return new EquipmentConditionDto
            {
                DamageDeviceId = entity.DamageDeviceId,
                Name = entity.Name,
                Description = entity.Description ?? string.Empty,
                Status = entity.Status,
                LoggedDate = entity.LoggedDate,

                // Determine equipment type and details
                EquipmentType = entity.HotPotInventoryId.HasValue ? "HotPot" : "Utensil",
                EquipmentId = entity.HotPotInventoryId ?? entity.UtensilId ?? 0,
                EquipmentName = entity.HotPotInventoryId.HasValue
                    ? entity.HotPotInventory?.Hotpot?.Name ?? "Unknown HotPot"
                    : entity.Utensil?.Name ?? "Unknown Utensil"
            };
        }

        public static EquipmentConditionDetailDto ToDetailDto(this DamageDevice entity)
        {
            if (entity == null)
                return null;

            var baseDto = entity.ToDto();

            return new EquipmentConditionDetailDto
            {
                DamageDeviceId = baseDto.DamageDeviceId,
                Name = baseDto.Name,
                Description = baseDto.Description,
                Status = baseDto.Status,
                LoggedDate = baseDto.LoggedDate,
                EquipmentType = baseDto.EquipmentType,
                EquipmentId = baseDto.EquipmentId,
                EquipmentName = baseDto.EquipmentName,

                // Additional details
                UpdatedAt = entity.UpdatedAt,
                EquipmentSerialNumber = entity.HotPotInventoryId.HasValue
                    ? entity.HotPotInventory?.SeriesNumber
                    : null,
                EquipmentTypeName = entity.UtensilId.HasValue
                    ? entity.Utensil?.UtensilType?.Name
                    : null,
                EquipmentMaterial = entity.UtensilId.HasValue
                    ? entity.Utensil?.Material
                    : null,
                MaintenanceNotes = null // Add this if you have maintenance notes in your entity
            };
        }

        public static EquipmentConditionListItemDto ToListItemDto(this DamageDevice entity)
        {
            if (entity == null)
                return null;

            return new EquipmentConditionListItemDto
            {
                DamageDeviceId = entity.DamageDeviceId,
                Name = entity.Name,
                Status = entity.Status,
                LoggedDate = entity.LoggedDate,
                EquipmentType = entity.HotPotInventoryId.HasValue ? "HotPot" : "Utensil",
                EquipmentName = entity.HotPotInventoryId.HasValue
                    ? entity.HotPotInventory?.Hotpot?.Name ?? "Unknown HotPot"
                    : entity.Utensil?.Name ?? "Unknown Utensil"
            };
        }

        // Extension methods for collections
        public static IEnumerable<EquipmentConditionDto> ToDtoList(this IEnumerable<DamageDevice> entities)
        {
            return entities?.Select(e => e.ToDto());
        }

        public static IEnumerable<EquipmentConditionListItemDto> ToListItemDtoList(this IEnumerable<DamageDevice> entities)
        {
            return entities?.Select(e => e.ToListItemDto());
        }

        // Extension methods for paged results
        public static PagedResult<EquipmentConditionDto> ToPagedDto(this PagedResult<DamageDevice> pagedResult)
        {
            if (pagedResult == null)
                return null;

            return new PagedResult<EquipmentConditionDto>
            {
                Items = pagedResult.Items?.Select(item => item.ToDto()).ToList(),
                TotalCount = pagedResult.TotalCount,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
        }

        public static PagedResult<EquipmentConditionListItemDto> ToPagedListItemDto(this PagedResult<DamageDevice> pagedResult)
        {
            if (pagedResult == null)
                return null;

            return new PagedResult<EquipmentConditionListItemDto>
            {
                Items = pagedResult.Items?.Select(item => item.ToListItemDto()).ToList(),
                TotalCount = pagedResult.TotalCount,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
        }
    }
}