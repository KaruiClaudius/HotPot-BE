using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class RentOrder : BaseEntity
    {
        [Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HotpotDeposit { get; set; }

        // Moved properties from RentOrderDetail
        [Required]
        public DateTime RentalStartDate { get; set; }

        [Required]
        public DateTime ExpectedReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LateFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DamageFee { get; set; }

        [StringLength(500)]
        public string? RentalNotes { get; set; }

        [StringLength(500)]
        public string? ReturnCondition { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<RentOrderDetail> RentOrderDetails { get; set; } = new List<RentOrderDetail>();
    }
}
