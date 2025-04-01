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
        Task<User> GetManagerByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllManagersAsync();
        Task<User> CreateManagerAsync(User manager);
        Task UpdateManagerAsync(int userId, User managerUpdate);
        Task DeleteManagerAsync(int userId);
    }
}
