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
}
