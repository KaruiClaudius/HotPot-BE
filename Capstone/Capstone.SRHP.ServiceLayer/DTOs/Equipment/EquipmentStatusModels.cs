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
}
