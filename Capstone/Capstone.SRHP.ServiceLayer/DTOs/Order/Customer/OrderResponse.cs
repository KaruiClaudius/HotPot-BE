using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Order.Customer
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserInfo User { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public DiscountInfo Discount { get; set; }

        // Main payment (typically the order payment)
        public PaymentInfo Payment { get; set; }

        // Additional payments
        public List<PaymentInfo> AdditionalPayments { get; set; }

        // Rental-specific properties
        public DateTime? RentalStartDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
        public string RentalNotes { get; set; }
        public string ReturnCondition { get; set; }
    }    
}
