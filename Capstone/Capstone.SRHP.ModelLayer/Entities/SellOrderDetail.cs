using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class SellOrderDetail  : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellOrderDetailId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? VolumeWeight { get; set; }

        [StringLength(10)]
        public string? Unit { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }  

        public int OrderId { get; set; }

        public int? IngredientId { get; set; }
        public int? CustomizationId { get; set; }
        public int? ComboId { get; set; }


        public virtual Order? Order { get; set; } = null!;


        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient? Ingredient { get; set; }

        [ForeignKey(nameof(CustomizationId))]
        public virtual Customization? Customization { get; set; }

        [ForeignKey(nameof(ComboId))]
        public virtual Combo? Combo { get; set; }

    }
}
