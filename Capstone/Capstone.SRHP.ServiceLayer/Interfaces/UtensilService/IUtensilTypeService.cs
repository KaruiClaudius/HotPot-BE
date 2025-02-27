using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UtensilService
{
    public interface IUtensilTypeService : IBaseService<UtensilType>
    {
        Task<PagedResult<UtensilType>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Dictionary<int, int>> GetUtensilCountsByTypesAsync(IEnumerable<int> typeIds);
        Task<int> GetUtensilCountByTypeAsync(int typeId);
        Task<bool> IsTypeInUseAsync(int typeId);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
    }
}
