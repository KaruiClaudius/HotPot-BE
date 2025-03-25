using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class ReplacementRequest : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplacementRequestId { get; set; }

        [Required]
        public string RequestReason { get; set; }

        [StringLength(1000)]
        public string? AdditionalNotes { get; set; }

        [Required]
        public ReplacementRequestStatus Status { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public DateTime? ReviewDate { get; set; }

        public string? ReviewNotes { get; set; }

        public DateTime? CompletionDate { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public int? AssignedStaffId { get; set; }

        public int? DamageDeviceId  { get; set; }

        // Equipment type and ID
        [Required]
        public EquipmentType EquipmentType { get; set; }

        public int? HotPotInventoryId { get; set; }

        public int? UtensilId { get; set; }

        // Navigation properties
        [InverseProperty("CustomerReplacementRequests")]
        public virtual User? Customer { get; set; }

        [ForeignKey("AssignedStaffId")]
        [InverseProperty("StaffReplacementRequests")]
        public virtual User? AssignedStaff { get; set; }

        [ForeignKey("DamageDeviceId ")]
        public virtual DamageDevice? ConditionLog { get; set; }

        [ForeignKey("HotPotInventoryId")]
        public virtual HotPotInventory? HotPotInventory { get; set; }

        [ForeignKey("UtensilId")]
        public virtual Utensil? Utensil { get; set; }
    }
}
