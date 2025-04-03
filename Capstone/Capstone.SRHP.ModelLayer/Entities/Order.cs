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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

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
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }

        public bool HasSellItems { get; set; } = false;

        public bool HasRentItems { get; set; } = false;

        public virtual User? User { get; set; }
        public virtual ShippingOrder? ShippingOrder { get; set; }
        public virtual Feedback? Feedback { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual Payment? Payment { get; set; }

        // Navigation properties to the specific order types
        public virtual SellOrder? SellOrder { get; set; }
        public virtual RentOrder? RentOrder { get; set; }
        public virtual ICollection<PaymentReceipt> Receipts { get; set; } = new List<PaymentReceipt>();

    }
}
