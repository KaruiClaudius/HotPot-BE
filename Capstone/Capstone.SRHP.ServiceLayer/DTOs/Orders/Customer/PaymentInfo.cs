using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer
{
    public class PaymentInfo
    {
        public int? PaymentId { get; set; }

        public int TransactionCode { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Purpose { get; set; }

    }
}
