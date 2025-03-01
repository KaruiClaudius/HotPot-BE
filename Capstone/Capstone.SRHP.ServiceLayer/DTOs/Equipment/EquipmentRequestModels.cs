using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Equipment
{
    public class UpdateResolutionTimelineRequest
    {
        [Required]
        public MaintenanceStatus Status { get; set; }

        [Required]
        public DateTime EstimatedResolutionTime { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }
    }

    public class AssignStaffRequest
    {
        [Required]
        public int StaffId { get; set; }
    }

    public class ResolveEquipmentRequest
    {
        [Required]
        [StringLength(1000)]
        public string ResolutionNotes { get; set; }
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
}
