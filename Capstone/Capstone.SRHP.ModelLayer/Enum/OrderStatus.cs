using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Enum
{
    public enum OrderStatus
    {
        Cart = 0,
        Pending = 1,
        Processing = 2,
        Processed = 3,
        Shipping = 4,
        Delivered = 5,
        Cancelled = 6,
        Returning = 7,
        Completed = 8
    }
}
