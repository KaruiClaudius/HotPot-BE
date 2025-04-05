using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class OrderStatusMetrics
    {
        public int TotalOrders { get; set; }
        public Dictionary<string, OrderStatusDetail> StatusDetails { get; set; }
        public List<OrderResponse> RecentOrders { get; set; }
    }
}
