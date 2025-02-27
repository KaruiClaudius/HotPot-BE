using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.HotpotService
{
    public interface IHotpotTypeService : IBaseService<HotpotType>
    {
        Task<int> GetHotpotCountByTypeAsync(int typeId);
        Task<bool> IsTypeInUseAsync(int typeId);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
    }
}
