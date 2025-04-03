using Capstone.HPTY.ModelLayer.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public PaymentStatus Status { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int UserId { get; set; }

        public int? OrderId { get; set; }



        public virtual User User { get; set; }
        public virtual Order? Order { get; set; }
        public virtual PaymentReceipt Receipt { get; set; }

    }
}
