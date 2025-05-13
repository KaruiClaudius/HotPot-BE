using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UserService
{
    public interface ICurrentUserService
    {
        int GetUserId();
        bool IsAuthenticated();
        bool IsInRole(string role);
        Task<User> GetCurrentUserAsync();
    }
}
