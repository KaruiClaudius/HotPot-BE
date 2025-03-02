using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class SizeDiscount : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeDiscountId { get; set; }

        [Required]
        public int MinSize { get; set; } 

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } 

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Combo> Combos { get; set; } = new List<Combo>();
        public virtual ICollection<Customization> Customizations { get; set; } = new List<Customization>();
    }
}
