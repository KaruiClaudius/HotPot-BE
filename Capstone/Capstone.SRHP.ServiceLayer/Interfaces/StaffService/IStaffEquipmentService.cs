using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffEquipmentService
    {
        /// Gets a list of all rental equipment
        Task<IEnumerable<EquipmentRetrievalDto>> GetAllRentalEquipmentAsync();

        /// Gets details of a specific rental equipment
        Task<EquipmentRetrievalDto> GetRentalEquipmentDetailsAsync(int equipmentId, string equipmentType);

        /// Logs an inspection for returned equipment
        Task<EquipmentInspectionResponse> LogEquipmentInspectionAsync(EquipmentInspectionRequest request);

        /// Updates the availability status of equipment
        Task<bool> UpdateEquipmentAvailabilityAsync(int equipmentId, string equipmentType, bool isAvailable);

        /// Gets inspection history for a specific equipment
        Task<IEnumerable<EquipmentInspectionResponse>> GetEquipmentInspectionHistoryAsync(int equipmentId, string equipmentType);
    }
}
