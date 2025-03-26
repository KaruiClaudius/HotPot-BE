using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capstone.HPTY.RepositoryLayer.Utils
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            // Convert enum value to string and replace underscores with spaces
            string name = enumValue.ToString();

            // Handle special case for "InProgress" -> "In Progress"
            name = Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");

            return name;
        }
    }
}
