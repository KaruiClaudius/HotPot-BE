using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Equipment
{
    public class EquipmentStatusDto
    {
        public string EquipmentType { get; set; } // "HotPot" or "Utensil"
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }
        public int UnavailableCount { get; set; }
        public int LowStockCount { get; set; } // Only applicable for Utensils
        public double AvailabilityPercentage { get; set; }
    }

    public class HotPotInventoryDto
    {
        public int HotPotInventoryId { get; set; }
        public string SeriesNumber { get; set; }
        public string Status { get; set; }
        public string HotpotName { get; set; }
    }

    public class HotPotInventoryDetailDto : HotPotInventoryDto
    {
        public int HotpotId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<DamageDeviceDto> ConditionLogs { get; set; }
    }

    // DTOs for Utensil
    public class UtensilDto
    {
        public int UtensilId { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string UtensilTypeName { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
    }

    public class UtensilDetailDto : UtensilDto
    {
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public DateTime LastMaintainDate { get; set; }
        public int UtensilTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<DamageDeviceDto> ConditionLogs { get; set; }
    }

    // DTO for Damage Device
    public class DamageDeviceDto
    {
        public int DamageDeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime LoggedDate { get; set; }
    }
    
}
