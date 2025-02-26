using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog
{
    public class CreateConditionLogRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; }

        [Required]
        public MaintenanceScheduleType ScheduleType { get; set; }

        public int? UtensilID { get; set; }

        public int? HotPotInventoryId { get; set; }
    }
}
