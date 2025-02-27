using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.HotpotService
{
    public interface ITurtorialVideoService : IBaseService<TurtorialVideo>
    {
        Task<PagedResult<TurtorialVideo>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Dictionary<int, bool>> GetVideosInUseStatusAsync(IEnumerable<int> videoIds);
        Task<IEnumerable<TurtorialVideo>> GetByHotpotTypeAsync(int hotpotTypeId);
        Task<bool> IsInUseAsync(int id);
    }
}
