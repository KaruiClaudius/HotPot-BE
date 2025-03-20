using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class OrderCountByStatus
    {
        public int Pending { get; set; }
        public int Processing { get; set; }
        public int Shipping { get; set; }
        public int Delivered { get; set; }
        public int Cancelled { get; set; }
        public int Returning { get; set; }
        public int Completed { get; set; }
    }
}
