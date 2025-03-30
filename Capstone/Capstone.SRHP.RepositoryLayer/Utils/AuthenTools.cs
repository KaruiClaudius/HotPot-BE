using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.RepositoryLayer.Utils
{
    public static class AuthenTools
    {
        public static class ClaimTypes
        {
            public const string UserId = "id";
            public const string Role = "role";
            public const string Email = "email";
        }

        public static string GetCurrentUserId(ClaimsIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException(nameof(identity));
            return identity.FindFirst(ClaimTypes.UserId)?.Value;
        }

        public static IEnumerable<string> GetUserRoles(ClaimsIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException(nameof(identity));
            return identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
        }
    }
}
