using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IManagerService
    {
        Task<Manager> GetManagerByIdAsync(int managerId);
        Task<Manager> GetManagerByUserIdAsync(int userId);
        Task<IEnumerable<Manager>> GetAllManagersAsync();
        Task<Manager> CreateManagerAsync(Manager manager);
        Task UpdateManagerAsync(int managerId, Manager manager);
        Task DeleteManagerAsync(int managerId);
    }
}
