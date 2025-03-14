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

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue)]
        public decimal MinStockLevel { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue)]
        public decimal Quantity { get; set; }

        // Add a measurement unit
        [Required]
        [StringLength(20)]
        public string MeasurementUnit { get; set; }

        [Required]
        [ForeignKey("IngredientType")]
        public int IngredientTypeID { get; set; }


        public virtual IngredientType? IngredientType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<CustomizationIngredient>? CustomizationIngredients { get; set; }
        public virtual ICollection<ComboIngredient>? ComboIngredients { get; set; }
        public virtual ICollection<Combo>? CombosAsBroth { get; set; }
        public virtual ICollection<Customization>? CustomizationsAsBroth { get; set; }
        public virtual ICollection<IngredientPrice>? IngredientPrices { get; set; }
    }
}
