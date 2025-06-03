using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [Phone]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }


        [Range(0, double.MaxValue)]
        public double? LoyatyPoint { get; set; }

        public WorkDays? WorkDays { get; set; }

        [StringLength(1000)]
        public string? Note { get; set; }

        // For Role Staff only
        public StaffType? StaffType { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
        //public virtual Customer? Customer { get; set; }
        //public virtual Staff? Staff { get; set; }
        //public virtual Manager? Manager { get; set; }

        public virtual ICollection<Customization>? Customizations { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        //customer
        public virtual ICollection<ReplacementRequest>? CustomerReplacementRequests { get; set; }

        //staff
        [InverseProperty("Staff")]
        public virtual ICollection<WorkShift>? StaffWorkShifts { get; set; } = new List<WorkShift>();
        public virtual ICollection<ShippingOrder>? ShippingOrders { get; set; }
        public virtual ICollection<ReplacementRequest>? StaffReplacementRequests { get; set; }

        [InverseProperty("PreparationStaff")]
        public virtual ICollection<Order>? PreparedOrders { get; set; } = new List<Order>();


        //manager
        [InverseProperty("Managers")]
        public virtual ICollection<WorkShift>? MangerWorkShifts { get; set; } = new List<WorkShift>();

        // Add these navigation properties
        public virtual ICollection<StaffAssignment> StaffAssignments { get; set; } = new List<StaffAssignment>();
        public virtual ICollection<StaffAssignment> ManagedAssignments { get; set; } = new List<StaffAssignment>();

        [InverseProperty("User")]
        public virtual ICollection<UserNotification> Notifications { get; set; } = new List<UserNotification>();
    }
}
