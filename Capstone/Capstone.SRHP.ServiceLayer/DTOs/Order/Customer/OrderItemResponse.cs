using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Order.Customer
{
    public class OrderItemResponse
    {
        public int OrderDetailId { get; set; }
        public int? Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
        public int? ItemId { get; set; }
        public bool IsSellable { get; set; }
    }
}
