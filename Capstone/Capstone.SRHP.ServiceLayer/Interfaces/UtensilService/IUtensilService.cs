using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UtensilService
{
    public interface IUtensilService : IBaseService<Utensil>
    {
        Task<PagedResult<Utensil>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Utensil>> GetAvailableUtensilsAsync();
        Task<IEnumerable<Utensil>> GetByTypeAsync(int typeId);
        Task UpdateStatusAsync(int id, bool status);
        Task UpdateQuantityAsync(int id, int quantity);
        Task<bool> IsAvailableAsync(int id);
    }
}
