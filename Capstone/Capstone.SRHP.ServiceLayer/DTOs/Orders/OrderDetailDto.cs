using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }

        public int? Quantity { get; set; }

        public decimal? VolumeWeight { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; } // "Ingredient", "Customization", "Combo"

        public int? ItemId { get; set; }

        public int OrderId { get; set; }
    }
}