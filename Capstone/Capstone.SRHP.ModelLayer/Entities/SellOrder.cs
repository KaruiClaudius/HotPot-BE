using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class SellOrder : BaseEntity
    {
        [Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<SellOrderDetail> SellOrderDetails { get; set; } = new List<SellOrderDetail>();
    }
}
