using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class OrderDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }  

        public int OrderID { get; set; }

        public int? UtensilID { get; set; }
        public int? IngredientID { get; set; }
        public int? HotpotID { get; set; }
        public int? CustomizationID { get; set; }
        public int? ComboID { get; set; }


        public virtual Order? Order { get; set; } = null!;

        [ForeignKey(nameof(UtensilID))]
        public virtual Utensil? Utensil { get; set; }

        [ForeignKey(nameof(IngredientID))]
        public virtual Ingredient? Ingredient { get; set; }

        [ForeignKey(nameof(HotpotID))]
        public virtual Hotpot? Hotpot { get; set; }

        [ForeignKey(nameof(CustomizationID))]
        public virtual Customization? Customization { get; set; }

        [ForeignKey(nameof(ComboID))]
        public virtual Combo? Combo { get; set; }

    }
}
