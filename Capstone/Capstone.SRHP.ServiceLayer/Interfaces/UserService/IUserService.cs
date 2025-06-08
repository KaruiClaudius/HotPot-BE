using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UserService
{
    public interface IUserService : IBaseService<User>
    {
        Task<PagedResult<User>> GetUsersAsync(
            string searchTerm = null,
            int? roleId = null,
            bool? isActive = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Name",
            bool ascending = true);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetByRoleAsync(int roleId);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<Role> GetByRoleNameAsync(string roleNAme);
        Task UpdatePasswordAsync(int id, string newPassword);
    }
}
