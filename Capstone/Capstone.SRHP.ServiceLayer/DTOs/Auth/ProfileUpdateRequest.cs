using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Auth
{
    public class ProfileUpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
    }
}
