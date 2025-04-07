using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;


namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class OrderStatusMetrics
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public Dictionary<string, OrderStatusDetail> StatusDetails { get; set; }
        public List<OrderResponse> RecentOrders { get; set; } = new List<OrderResponse>(); // Initialize the property to avoid CS8618
    }
}
