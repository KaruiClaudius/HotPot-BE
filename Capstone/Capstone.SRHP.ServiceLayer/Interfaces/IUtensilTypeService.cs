using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface IUtensilTypeService : IBaseService<UtensilType>
    {
        Task<int> GetUtensilCountByTypeAsync(int typeId);
        Task<bool> IsTypeInUseAsync(int typeId);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
    }
}
