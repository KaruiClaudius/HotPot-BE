using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Ingredient : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        // For the MeasurementValue field
        [Column(TypeName = "float")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Measurement value must be greater than zero")]
        public double MeasurementValue { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Range(0, int.MaxValue)]
        public int MinStockLevel { get; set; }

        [NotMapped]
        public int Quantity => IngredientBatches?.Where(b => !b.IsDelete).Sum(b => b.RemainingQuantity) ?? 0;

        [Required]
        [ForeignKey("IngredientType")]
        public int IngredientTypeId { get; set; }

        public virtual IngredientType? IngredientType { get; set; }
        public virtual ICollection<SellOrderDetail>? SellOrderDetails { get; set; }
        public virtual ICollection<CustomizationIngredient>? CustomizationIngredients { get; set; }
        public virtual ICollection<ComboIngredient>? ComboIngredients { get; set; }
        public virtual ICollection<IngredientPrice>? IngredientPrices { get; set; }
        public virtual ICollection<IngredientBatch>? IngredientBatches { get; set; }
    }
}
