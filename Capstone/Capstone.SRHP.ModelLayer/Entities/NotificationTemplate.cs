using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class NotificationTemplate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; } // Unique code to identify the template

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string MessageTemplate { get; set; } // Can contain placeholders like {OrderNumber}

        [StringLength(50)]
        public string Type { get; set; } // e.g., "OrderCreated", "PaymentReceived"

        [StringLength(255)]
        public string Description { get; set; }

        // Optional: Default target information
        [StringLength(20)]
        public string DefaultTargetType { get; set; } // "User", "Role", "Group"
    }
}
