using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UserService
{
    public interface IRoleService : IBaseService<Role>
    {
        Task<Role?> GetByNameAsync(string name);
        Task<IEnumerable<User>> GetUsersByRoleAsync(int roleId);
        Task<bool> IsRoleInUseAsync(int roleId);
        //Task UpdatePermissionsAsync(int roleId, IEnumerable<string> permissions);
    }
}
