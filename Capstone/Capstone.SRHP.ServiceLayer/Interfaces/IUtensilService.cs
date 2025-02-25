using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface IUtensilService : IBaseService<Utensil>
    {
        Task<IEnumerable<Utensil>> GetAvailableUtensilsAsync();
        Task<IEnumerable<Utensil>> GetByTypeAsync(int typeId);
        Task UpdateStatusAsync(int id, bool status);
        Task UpdateQuantityAsync(int id, int quantity);
        Task<bool> IsAvailableAsync(int id);
        Task LogMaintenanceAsync(int id, string description, MaintenanceStatus status);
        Task<IEnumerable<ConditionLog>> GetMaintenanceHistoryAsync(int id);
    }
}
