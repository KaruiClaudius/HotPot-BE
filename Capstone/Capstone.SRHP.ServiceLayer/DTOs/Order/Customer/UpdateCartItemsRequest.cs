using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Order.Customer
{
    public class UpdateCartItemsRequest
    {
        public CartItemUpdate[] Items { get; set; }
    }
}
