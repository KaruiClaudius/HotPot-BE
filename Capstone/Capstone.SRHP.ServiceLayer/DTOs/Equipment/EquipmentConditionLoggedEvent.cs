using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Equipment
{
    public class EquipmentConditionLoggedEvent
    {
        public int? HotPotInventoryId { get; set; }
        public int? UtensilId { get; set; }
        public MaintenanceStatus Status { get; set; }
        public string Description { get; set; }
    }
}
