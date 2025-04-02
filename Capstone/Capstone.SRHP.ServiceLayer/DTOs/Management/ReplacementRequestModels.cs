using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class CreateReplacementRequestDto
    {
        [Required]
        [StringLength(500)]
        public string RequestReason { get; set; }

        [StringLength(1000)]
        public string? AdditionalNotes { get; set; }

        [Required]
        public EquipmentType EquipmentType { get; set; }

        public int? HotPotInventoryId { get; set; }

        public int? UtensilId { get; set; }
    }

    public class ReviewReplacementRequestDto
    {
        [Required]
        public bool IsApproved { get; set; }

        [StringLength(1000)]
        public string? ReviewNotes { get; set; }
    }

    public class UpdateReplacementStatusDto
    {
        [Required]
        public ReplacementRequestStatus Status { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }
    }

    public class CompleteReplacementDto
    {
        [Required]
        [StringLength(1000)]
        public string CompletionNotes { get; set; }
    }

    public class ReplacementRequestSummaryDto
    {
        public int ReplacementRequestId { get; set; }
        public string RequestReason { get; set; }
        public ReplacementRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public string CustomerName { get; set; }
        public string AssignedStaffName { get; set; }
    }

    public class ReplacementRequestDetailDto
    {
        public int ReplacementRequestId { get; set; }
        public string RequestReason { get; set; }
        public string AdditionalNotes { get; set; }
        public ReplacementRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }
        public DateTime? CompletionDate { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string EquipmentName { get; set; }

        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

        public int? AssignedStaffId { get; set; }
        public string AssignedStaffName { get; set; }

        public int? HotPotInventoryId { get; set; }
        public string HotPotSeriesNumber { get; set; }
        public string HotPotName { get; set; }

        public int? UtensilId { get; set; }
        public string UtensilName { get; set; }
        public string UtensilType { get; set; }
    }
    public class ReplacementDashboardDto
    {
        public int TotalRequests { get; set; }
        public int PendingRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int InProgressRequests { get; set; }
        public int CompletedRequests { get; set; }
        public int RejectedRequests { get; set; }
        public int CancelledRequests { get; set; }

        public int HotPotRequests { get; set; }
        public int UtensilRequests { get; set; }

        public List<ReplacementRequestSummaryDto> RecentRequests { get; set; }
    }
    public class VerifyEquipmentFaultyDto
    {
        [Required]
        public bool IsFaulty { get; set; }

        [Required]
        [StringLength(1000)]
        public string VerificationNotes { get; set; }
    }

}
