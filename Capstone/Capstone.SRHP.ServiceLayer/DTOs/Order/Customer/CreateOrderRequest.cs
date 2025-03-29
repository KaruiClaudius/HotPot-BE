using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Order.Customer
{
    public class CreateOrderRequest
    {
        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        [Required]
        public List<OrderItemRequest> Items { get; set; }

        public int? DiscountId { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
