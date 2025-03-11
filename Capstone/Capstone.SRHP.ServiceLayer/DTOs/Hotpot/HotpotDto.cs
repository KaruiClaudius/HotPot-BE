using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Size { get; set; }
        public string Description { get; set; }
        public string[] ImageURLs { get; set; }
        public decimal Price { get; set; }
        public decimal BasePrice { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public DateTime LastMaintainDate { get; set; }
        public int InventoryID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class HotpotDetailDto : HotpotDto
    {
        public List<InventoryItemDto> InventoryItems { get; set; }
    }
}
