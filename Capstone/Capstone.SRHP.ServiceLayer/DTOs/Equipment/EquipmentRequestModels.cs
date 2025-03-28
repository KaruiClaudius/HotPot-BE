using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Equipment
{

    public class AssignStaffRequest
    {
        [Required]
        public int StaffId { get; set; }
    }

    public class NotifyCustomerRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ConditionLogId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        [Required]
        public DateTime EstimatedResolutionTime { get; set; }
    }

    public class EquipmentFailureDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public int? UtensilID { get; set; }
        public int? HotPotInventoryId { get; set; }
    }

    public class ConditionLogDto
    {
        public int DamageDeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime LoggedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Equipment information
        public EquipmentType EquipmentType { get; set; }
        public int? EquipmentId { get; set; }
        public string EquipmentName { get; set; }
    }
    public class ConditionLogDetailDto : ConditionLogDto
    {
        // Additional details for detailed view
        public int? AssignedStaffId { get; set; }
        public string AssignedStaffName { get; set; }
        public List<ReplacementRequestDto> ReplacementRequests { get; set; }
        public List<int> AffectedCustomerIds { get; set; }
    }

    public class ReplacementRequestDto
    {
        public int ReplacementRequestId { get; set; }
        public string RequestReason { get; set; }
        public string AdditionalNotes { get; set; }
        public ReplacementRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }
        public int? AssignedStaffId { get; set; }
    }

    public class VerifyEquipmentDto
    {
        [Required]
        public bool IsVerified { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string VerificationNotes { get; set; }
    }
}
