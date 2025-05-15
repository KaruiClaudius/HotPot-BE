using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Notification : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // e.g., "OrderCreated", "PaymentReceived", "SystemAlert"

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        // For storing additional data as JSON
        [Column(TypeName = "nvarchar(max)")]
        public string DataJson { get; set; }

        // Target information
        [StringLength(20)]
        public string TargetType { get; set; } // "User", "Role", "Group"

        [StringLength(50)]
        public string TargetId { get; set; } // UserId, RoleName, or GroupName

        // Navigation property
        public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
    }
}
