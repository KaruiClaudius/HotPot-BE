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
        Task<bool> IsTypeInUseAsync(int id);
        Task<int> GetUtensilCountAsync(int id);
    }
}
