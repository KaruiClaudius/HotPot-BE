using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class UpdateOrderStatusRequest
    {
        [Required]
        public OrderStatus NewStatus { get; set; }

        public string Notes { get; set; }
    }
}
