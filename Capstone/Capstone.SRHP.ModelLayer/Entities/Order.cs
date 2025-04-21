using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Order : BaseEntity
    {
        private static readonly Random _random = new Random();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderCode { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        [ForeignKey("User")] // Customer
        public int UserId { get; set; }

        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }

        // For the staff member preparing the order
        [ForeignKey("PreparationStaff")]
        public int? PreparationStaffId { get; set; } // Nullable until assigned

        public bool HasSellItems { get; set; } = false;

        public bool HasRentItems { get; set; } = false;

        public virtual User? User { get; set; } // Customer
        public virtual ShippingOrder? ShippingOrder { get; set; }
        public virtual Feedback? Feedback { get; set; }
        public virtual Discount? Discount { get; set; }

        // Navigation property to the preparation staff member
        public virtual User? PreparationStaff { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        // Navigation properties to the specific order types
        public virtual SellOrder? SellOrder { get; set; }
        public virtual RentOrder? RentOrder { get; set; }
        public virtual ICollection<PaymentReceipt> Receipts { get; set; } = new List<PaymentReceipt>();

        public Order()
        {
            OrderCode = GenerateOrderCode();
        }

        // Method to generate a unique order code
        private string GenerateOrderCode()
        {
            // Generate a code with format: HP-YYMMDD-XXXX
            // HP = Hotpot, YY = Year, MM = Month, DD = Day, XXXX = Random 4-digit number
            string datePart = DateTime.UtcNow.ToString("yyMMdd");
            string randomPart = GenerateRandomDigits(4);
            return $"ORD-{datePart}-{randomPart}";
        }

        // Helper method to generate random digits
        private static string GenerateRandomDigits(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        // Method to manually set the order code (for migrations or special cases)
        public void SetOrderCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("Order code cannot be null or empty");

            OrderCode = code;
        }
    }
}
