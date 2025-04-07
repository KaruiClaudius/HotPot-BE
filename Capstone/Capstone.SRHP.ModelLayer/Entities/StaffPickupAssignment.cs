using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class StaffPickupAssignment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual RentOrder RentOrder { get; set; }


        [ForeignKey(nameof(StaffId))]
        public virtual User Staff { get; set; }
    }
}
