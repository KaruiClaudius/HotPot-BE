using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Utensil : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UtensilId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Material { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public DateTime LastMaintainDate { get; set; }

        [Required]
        [ForeignKey("UtensilType")]
        public int UtensilTypeId { get; set; }

        public virtual UtensilType? UtensilType { get; set; }
        public virtual ICollection<RentOrderDetail> RentOrderDetails { get; set; }
        public virtual ICollection<ReplacementRequest>? ReplacementRequests { get; set; }
        public virtual ICollection<DamageDevice>? ConditionLogs { get; set; }

        public Utensil()
        {
            LastMaintainDate = DateTime.UtcNow.AddHours(7);
        }

        public virtual void SetMaintainDate()
        {
            LastMaintainDate = DateTime.UtcNow.AddHours(7);
        }

    }


}
