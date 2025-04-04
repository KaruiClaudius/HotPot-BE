using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog
{
    public class CreateDamageDeviceRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; }

        public int? UtensilID { get; set; }
        public int? HotPotInventoryId { get; set; }
    }
}
