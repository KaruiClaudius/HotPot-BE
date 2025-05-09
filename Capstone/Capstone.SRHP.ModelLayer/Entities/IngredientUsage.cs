using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class IngredientUsage : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientUsageId { get; set; }

        [Required]
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        [Required]
        [ForeignKey("IngredientBatch")]
        public int IngredientBatchId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]  // Changed to int range
        public int QuantityUsed { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("OrderDetail")]
        public int? OrderDetailId { get; set; }

        // Optional: Link to specific combo or customization
        [ForeignKey("Combo")]
        public int? ComboId { get; set; }

        [ForeignKey("Customization")]
        public int? CustomizationId { get; set; }

        [Required]
        public DateTime UsageDate { get; set; }

        // Navigation properties
        public virtual Ingredient Ingredient { get; set; }
        public virtual IngredientBatch IngredientBatch { get; set; }
        public virtual Order Order { get; set; }
        public virtual SellOrderDetail OrderDetail { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual Customization Customization { get; set; }
    }
}
