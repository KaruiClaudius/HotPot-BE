using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Order.Customer
{
    public class ShippingInfo
    {
        public int? ShippingOrderId { get; set; }
        public string? StaffName { get; set; }
        public string? StaffPhone { get; set; }
        public DateTime? EstimatedDeliveryTime { get; set; }
        public bool IsDelivered { get; set; }
        public string? DeliveryNotes { get; set; }
    }
}
