using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer
{
    public class RemoveCartItemRequest
    {
        public int OrderDetailId { get; set; }
        public bool IsSellItem { get; set; }
    }
}
