using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class UpdateEquipmentStatusRequest
    {
        [Required]
        public bool Status { get; set; }

        [StringLength(1000)]
        public string Reason { get; set; }
    }

    public class UpdateUtensilQuantityRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class NotifyAdminStockRequest
    {
        [Required]
        [StringLength(20)]
        public string NotificationType { get; set; } // "LowStock" or "StatusChange"

        [Required]
        [StringLength(50)]
        public string EquipmentType { get; set; } // "HotPot" or "Utensil"

        public int EquipmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string EquipmentName { get; set; }

        public int CurrentQuantity { get; set; }

        public int Threshold { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(1000)]
        public string Reason { get; set; }
    }

    public class EquipmentUnavailableResponse
    {
        public List<HotPotInventory> UnavailableHotPots { get; set; }
        public List<ModelLayer.Entities.Utensil> UnavailableUtensils { get; set; }
        public int TotalUnavailableCount { get; set; }
    }

    public class EquipmentAvailableResponse
    {
        public List<HotPotInventory> AvailableHotPots { get; set; }
        public List<ModelLayer.Entities.Utensil> AvailableUtensils { get; set; }
        public int TotalAvailableCount { get; set; }
    }

    public class EquipmentDashboardResponse
    {
        public List<EquipmentStatusDto> StatusSummary { get; set; }
        public List<ModelLayer.Entities.Utensil> LowStockUtensils { get; set; }
        public List<HotPotInventory> UnavailableHotPots { get; set; }
        public List<ModelLayer.Entities.Utensil> UnavailableUtensils { get; set; }
        public int TotalEquipmentCount { get; set; }
        public int TotalAvailableCount { get; set; }
        public int TotalUnavailableCount { get; set; }
        public int TotalLowStockCount { get; set; }
    }
}
