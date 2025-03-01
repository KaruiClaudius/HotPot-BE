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
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("Staff")]
        public int StaffID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? DeliveryTime { get; set; }

        [StringLength(500)]
        public string? DeliveryNotes { get; set; }

        [DefaultValue(false)]
        public bool IsDelivered { get; set; } = false;

        // Fields for proof of delivery
        public byte[]? ProofImage { get; set; }

        public string? ProofImageType { get; set; }

        public byte[]? SignatureData { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ProofTimestamp { get; set; }


        public virtual Order? Order { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
