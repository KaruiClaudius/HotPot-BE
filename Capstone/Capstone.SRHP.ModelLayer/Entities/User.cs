using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required]
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

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual Manager? Manager { get; set; }
        public virtual ICollection<Customization>? Customizations { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        [InverseProperty("ApprovedByUser")]
        public virtual ICollection<Feedback>? ApprovedFeedbacks { get; set; }

    }
}
