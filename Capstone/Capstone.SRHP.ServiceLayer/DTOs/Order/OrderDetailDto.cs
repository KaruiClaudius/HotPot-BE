using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.OrderStaff
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; } // "Utensil", "Ingredient", "Hotpot", "Customization", "Combo"
        public int? ItemId { get; set; }
    }
}
