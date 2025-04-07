using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer
{
    public class CartItemUpdate
    {
        public int OrderDetailId { get; set; }
        public bool IsSellItem { get; set; }
        public int NewQuantity { get; set; }
    }
}
