using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class HotpotDto
    {
        public int HotpotId { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public int Size { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public string HotpotTypeName { get; set; }
        public int HotpotTypeID { get; set; }
        public int TurtorialVideoID { get; set; }
        public string? TurtorialVideoName { get; set; }
        public DateTime LastMaintainDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<HotPotInventoryDto>? InventoryUnits { get; set; }
    }
}
