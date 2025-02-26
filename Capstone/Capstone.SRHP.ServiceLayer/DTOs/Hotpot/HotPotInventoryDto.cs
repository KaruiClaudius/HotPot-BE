using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class HotPotInventoryDto
    {
        public int HotPotInventoryId { get; set; }
        public string SeriesNumber { get; set; }
        public int HotpotId { get; set; }
        public string? HotpotName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ConditionLogDto>? ConditionLogs { get; set; }
    }

    public class HotPotInventoryDetailDto : HotPotInventoryDto
    {
        public List<ConditionLogDto> ConditionLogs { get; set; }
    }
}
