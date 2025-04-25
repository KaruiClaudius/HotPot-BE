using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Equipment
{
    public class EquipmentRetrievalDto
    {
        public int EquipmentId { get; set; }
        public string SeriesNumber { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? LastInspectionDate { get; set; }
        public MaintenanceStatus? LastInspectionStatus { get; set; }
    }

    public class EquipmentInspectionRequest
    {
        public int EquipmentId { get; set; }
        public string ConditionName { get; set; }
        public string ConditionDescription { get; set; }
        public MaintenanceStatus Status { get; set; }
        public bool SetAsAvailable { get; set; }
    }

    public class EquipmentInspectionResponse
    {
        public int ConditionLogId { get; set; }
        public string Equipment { get; set; }
        public string ConditionName { get; set; }
        public string ConditionDescription { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime LoggedDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class UpdateAvailabilityRequest
    {
        /// Whether the equipment is available for use
        public bool IsAvailable { get; set; }
    }
}
