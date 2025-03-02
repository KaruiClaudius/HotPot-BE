using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Customization : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomizationId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }  

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }


        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [ForeignKey("HotpotBroth")]
        public int HotpotBrothID { get; set; }

        [Required]
        [ForeignKey("Combo")]
        public int ComboID { get; set; }

        [ForeignKey("AppliedDiscount")]
        public int? AppliedDiscountID { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Ingredient HotpotBroth { get; set; } = null!;
        public virtual Combo Combo { get; set; } = null!;
        public virtual OrderDetail OrderDetail { get; set; } = null!;
        public virtual ICollection<CustomizationIngredient> CustomizationIngredients { get; set; } = new List<CustomizationIngredient>();
        public virtual SizeDiscount AppliedDiscount { get; set; }

    }
}
