using Capstone.HPTY.ModelLayer.Enum; // Assuming StaffTaskType is in this namespace
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class StaffAssignment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffAssignmentId { get; set; }

        [Required]
        public int StaffId { get; set; } // Foreign Key to User table for the assigned staff

        [Required]
        public int ManagerId { get; set; } // Foreign Key to User table for the manager who assigned the task

        [Required]
        public int OrderId { get; set; } // Foreign Key to Order table

        [Required]
        public StaffTaskType TaskType { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedDate { get; set; }

        [NotMapped] // This property is calculated and not stored in the database
        public bool IsActive => CompletedDate == null;

        // Navigation properties
        [ForeignKey("StaffId")]
        public virtual User Staff { get; set; }

        [ForeignKey("ManagerId")]
        public virtual User Manager { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}