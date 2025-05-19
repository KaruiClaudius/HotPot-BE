using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class SellOrderDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellOrderDetailId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [ForeignKey("SellOrder")]
        public int OrderId { get; set; }

        public int? PackagingId { get; set; }
        public int? CustomizationId { get; set; }
        public int? ComboId { get; set; }
        public int? UtensilId { get; set; }

        public virtual SellOrder SellOrder { get; set; } = null!;

        [ForeignKey(nameof(PackagingId))]
        public virtual IngredientPackaging? Packaging { get; set; }

        [ForeignKey(nameof(CustomizationId))]
        public virtual Customization? Customization { get; set; }

        [ForeignKey(nameof(ComboId))]
        public virtual Combo? Combo { get; set; }

        [ForeignKey(nameof(UtensilId))]
        public virtual Utensil? Utensil { get; set; }
    }
}
