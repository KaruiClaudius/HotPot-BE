using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments.Admin
{
    public class PaymentSummary
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalOrderAmount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalRefunded { get; set; }
        public decimal TotalFees { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal DepositRefunded { get; set; }
        public decimal RemainingDepositToRefund { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
