using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer
{
    public class PaymentLinkResponse
    {
        public string PaymentLink { get; set; }
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
