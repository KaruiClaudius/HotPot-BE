using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Discount : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? Duration { get; set; }

        public double? PointCost { get; set; }


        public virtual Order? Order { get; set; }
    }
}
