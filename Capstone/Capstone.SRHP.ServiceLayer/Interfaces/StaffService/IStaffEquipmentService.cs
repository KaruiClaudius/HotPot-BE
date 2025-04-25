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
        Task<IEnumerable<EquipmentRetrievalDto>> GetAllRentalEquipmentAsync();
        Task<EquipmentRetrievalDto> GetRentalEquipmentDetailsAsync(int equipmentId);
        Task<EquipmentInspectionResponse> LogEquipmentInspectionAsync(EquipmentInspectionRequest request);
        Task<bool> UpdateEquipmentAvailabilityAsync(int equipmentId, UpdateAvailabilityRequest request);
        Task<IEnumerable<EquipmentInspectionResponse>> GetEquipmentInspectionHistoryAsync(int equipmentId);
    }
}
