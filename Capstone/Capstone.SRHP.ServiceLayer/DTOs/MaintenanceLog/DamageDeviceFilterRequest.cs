using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog
{
    public class DamageDeviceFilterRequest
    {
        public string SearchTerm { get; set; }
        public MaintenanceStatus? Status { get; set; }
        public DeviceType DeviceType { get; set; } = DeviceType.All;
        public int? HotPotInventoryId { get; set; }
        public int? UtensilId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SortBy { get; set; } = "LoggedDate";
        public bool Ascending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
