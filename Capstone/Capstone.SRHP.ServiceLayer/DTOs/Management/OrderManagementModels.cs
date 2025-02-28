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
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int StaffId { get; set; }
    }
    public class UpdateOrderStatusRequest
    {
        [Required]
        public OrderStatus Status { get; set; }
    }

    public class UpdateDeliveryStatusRequest
    {
        [Required]
        public bool IsDelivered { get; set; }

        public string Notes { get; set; }
    }

    public class UpdateDeliveryTimeRequest
    {
        [Required]
        public DateTime DeliveryTime { get; set; }
    }
}
