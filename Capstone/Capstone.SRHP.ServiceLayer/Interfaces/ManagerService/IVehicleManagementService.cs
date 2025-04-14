using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IVehicleManagementService
    {
        Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync();
        Task<VehicleDTO> GetVehicleByIdAsync(int id);
        Task<VehicleDTO> CreateVehicleAsync(CreateVehicleRequest request);
        Task<VehicleDTO> UpdateVehicleAsync(int id, UpdateVehicleRequest request);
        Task<bool> DeleteVehicleAsync(int id);
        Task<VehicleDTO> UpdateVehicleStatusAsync(int id, VehicleStatus status);
        Task<IEnumerable<VehicleDTO>> GetAvailableVehiclesAsync(VehicleType? type = null);
    }
}
