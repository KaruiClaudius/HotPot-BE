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
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public int CustomizationID { get; set; }
        public int IngredientID { get; set; }

        public virtual Customization Customization { get; set; } = null!;

        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
