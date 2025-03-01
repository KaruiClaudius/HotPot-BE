using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class AllocateOrderRequest
    {  
        public int OrderId { get; set; }
        public int StaffId { get; set; }
    }
    public class ManagerOrderStatusUpdateRequest
    {
        public OrderStatus Status { get; set; }
    }

    public class UpdateDeliveryStatusRequest
    {
        public bool IsDelivered { get; set; }

        public string Notes { get; set; }
    }

    public class UpdateDeliveryTimeRequest
    {
        [Required]
        public DateTime DeliveryTime { get; set; }
    }
}
