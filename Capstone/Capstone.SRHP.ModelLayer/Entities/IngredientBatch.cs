using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class IngredientBatch : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientBatchId { get; set; }

        [Required]
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Range(0, int.MaxValue)]
        public int InitialQuantity { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Range(0, int.MaxValue)]
        public int RemainingQuantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BestBeforeDate { get; set; }

        [StringLength(100)]
        public string? BatchNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReceivedDate { get; set; }

        public virtual Ingredient? Ingredient { get; set; }
    }
}
