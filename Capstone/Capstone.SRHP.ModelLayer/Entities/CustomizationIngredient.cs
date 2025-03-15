using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class CustomizationIngredient : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomizationIngredientId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string MeasurementUnit { get; set; }

        public int CustomizationId { get; set; }
        public int IngredientId { get; set; }

        public virtual Customization Customization { get; set; } = null!;

        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
