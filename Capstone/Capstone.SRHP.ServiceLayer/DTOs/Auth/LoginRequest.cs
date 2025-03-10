using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Auth
{
    public class LoginRequest
    {
        [Phone]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
