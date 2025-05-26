using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class UserNotification : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserNotificationId { get; set; }

        [Required]
        [ForeignKey("Notification")]
        public int NotificationId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ReadAt { get; set; }

        [Required]
        public bool IsDelivered { get; set; } = false;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? DeliveredAt { get; set; }

        // Navigation properties
        public virtual Notification Notification { get; set; }
        public virtual User User { get; set; }

        public void MarkAsRead()
        {
            if (!IsRead)
            {
                IsRead = true;
                ReadAt = DateTime.UtcNow.AddHours(7);
                SetUpdateDate();
            }
        }

        public void MarkAsDelivered()
        {
            if (!IsDelivered)
            {
                IsDelivered = true;
                DeliveredAt = DateTime.UtcNow.AddHours(7);
                SetUpdateDate();
            }
        }
    }
}

