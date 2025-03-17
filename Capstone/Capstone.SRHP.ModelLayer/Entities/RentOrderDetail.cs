using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class RentOrderDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentableOrderDetailId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RentalPrice { get; set; }

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

        public int OrderId { get; set; }
        public int? UtensilId { get; set; }
        public int? HotpotInventoryId { get; set; }

        public virtual Order? Order { get; set; } = null!;

        [ForeignKey(nameof(UtensilId))]
        public virtual Utensil? Utensil { get; set; }

        [ForeignKey(nameof(HotpotInventoryId))]
        public virtual HotPotInventory? HotpotInventory { get; set; }
    }
}
