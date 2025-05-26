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
        [ForeignKey("SenderUser")]
        public int SenderUserId { get; set; }

        [Required]
        [ForeignKey("ReceiverUser")]
        public int ReceiverUserId { get; set; }

        [Required]
        [ForeignKey("ChatSession")]
        public int ChatSessionId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }
        public virtual User SenderUser { get; set; }
        public virtual User ReceiverUser { get; set; }
        public virtual ChatSession ChatSession { get; set; }
        public bool IsBroadcast { get; set; }

    }
}
