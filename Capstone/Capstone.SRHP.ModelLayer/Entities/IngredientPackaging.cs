using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class IngredientPackaging : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackagingId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Small, Medium, Large, etc.

        [Required]
        [Column(TypeName = "int")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } // Amount in base units

        [Required]
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        [Required]
        public bool IsDefault { get; set; } // Whether this is the default packaging option

        public virtual Ingredient? Ingredient { get; set; }
    }
}
