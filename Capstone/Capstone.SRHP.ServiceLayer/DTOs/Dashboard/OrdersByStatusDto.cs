using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class OrdersByStatusDto
    {
        public List<OrderResponse> PendingOrders { get; set; }
        public List<OrderResponse> ProcessingOrders { get; set; }
        public List<OrderResponse> ShippingOrders { get; set; }
        public List<OrderResponse> DeliveredOrders { get; set; }
        public List<OrderResponse> CancelledOrders { get; set; }
        public List<OrderResponse> ReturningOrders { get; set; }
        public List<OrderResponse> CompletedOrders { get; set; }
    }
}
