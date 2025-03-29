using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Equipment
{
    public class UpdateConditionStatusRequest
    {
        [Required]
        public MaintenanceStatus Status { get; set; }
    }

    public class NotifyAdminRequest
    {
        [Required]
        public int ConditionLogId { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipmentType { get; set; }

        [Required]
        [StringLength(100)]
        public string EquipmentName { get; set; }

        [Required]
        [StringLength(100)]
        public string IssueName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public MaintenanceScheduleType ScheduleType { get; set; }
    }

    public class EquipmentConditionDto
    {
        public int DamageDeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime LoggedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Equipment information
        public string EquipmentType { get; set; } // "HotPot" or "Utensil"
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
    }

    public class EquipmentConditionDetailDto : EquipmentConditionDto
    {
        public DateTime? UpdatedAt { get; set; }
        public string EquipmentSerialNumber { get; set; }
        public string EquipmentTypeName { get; set; } // For utensils, this would be the utensil type name
        public string EquipmentMaterial { get; set; } // For utensils

        // Additional maintenance information
        public string MaintenanceNotes { get; set; }
    }

    public class EquipmentConditionListItemDto
    {
        public int DamageDeviceId { get; set; }
        public string Name { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime LoggedDate { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentName { get; set; }
    }

    public class CreateEquipmentConditionRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Pending;

        // Only one of these should be provided
        public int? HotPotInventoryId { get; set; }
        public int? UtensilId { get; set; }
    }

}
