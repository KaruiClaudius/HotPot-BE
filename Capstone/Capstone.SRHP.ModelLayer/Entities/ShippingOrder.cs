using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class ShippingOrder : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShippingOrderId { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }


        [StringLength(500)]
        public string? DeliveryNotes { get; set; }

        [DefaultValue(false)]
        public bool IsDelivered { get; set; } = false;


        public virtual Order? Order { get; set; }
        public virtual User? Staff { get; set; }
    }
}
