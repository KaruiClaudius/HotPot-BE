using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Payment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        public int TransactionCode { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int UserID { get; set; }

        public int? OrderID { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual Order? Order { get; set; }
    }
}
