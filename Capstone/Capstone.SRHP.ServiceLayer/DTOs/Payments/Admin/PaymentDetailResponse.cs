using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments.Admin
{
    public class PaymentDetailResponse
    {
        public int PaymentId { get; set; }
        public int TransactionCode { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // User information
        public UserInfo User { get; set; }

        // Order information (if available)
        public OrderBasicInfo Order { get; set; }
    }
}
