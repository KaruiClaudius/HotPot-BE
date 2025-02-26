using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
     public class ChatMessage : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatMessageId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int SenderUserId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int ReceiverUserId { get; set; }

        [ForeignKey("ChatSession")]
        public int? SessionId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        public virtual User? SenderUser { get; set; }
        public virtual User? ReceiverUser { get; set; }
        public virtual ChatSession? Session { get; set; }
    }
}
