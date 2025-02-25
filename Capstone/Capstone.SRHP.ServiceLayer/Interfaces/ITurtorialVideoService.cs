using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface ITurtorialVideoService : IBaseService<TurtorialVideo>
    {
        Task<IEnumerable<TurtorialVideo>> GetByNameAsync(string name);
        Task<IEnumerable<Hotpot>> GetAssociatedHotpotsAsync(int videoId);
    }
}
