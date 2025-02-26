using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class ChatSession : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatSessionId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string? Topic { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Manager? Manager { get; set; }  
        public virtual ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }
}
