using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class RentOrderDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentOrderDetailId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RentalPrice { get; set; }

        [Required]
        [ForeignKey("RentOrder")]
        public int OrderId { get; set; }
        public int? HotpotInventoryId { get; set; }


        public virtual RentOrder RentOrder { get; set; } = null!;

        [ForeignKey(nameof(HotpotInventoryId))]
        public virtual HotPotInventory? HotpotInventory { get; set; }
    }
}
