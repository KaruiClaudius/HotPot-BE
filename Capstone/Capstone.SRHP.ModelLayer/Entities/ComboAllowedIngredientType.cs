using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class ComboAllowedIngredientType : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Combo")]
        public int ComboId { get; set; }

        [Required]
        [ForeignKey("IngredientType")]
        public int IngredientTypeId { get; set; }

        [Required]
        public int MaxQuantity { get; set; } = 1; // Maximum quantity of this type allowed

        public virtual Combo Combo { get; set; } = null!;
        public virtual IngredientType IngredientType { get; set; } = null!;
    }
}
