using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Customer : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double LoyatyPoint { get; set; } = 0;

        [StringLength(1000)]
        public string? Note { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ReplacementRequest>? ReplacementRequests { get; set; }

    }
}
