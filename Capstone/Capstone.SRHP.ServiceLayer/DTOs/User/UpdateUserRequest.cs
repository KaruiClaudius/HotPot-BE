using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.User
{
    public class UpdateUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;


        [Phone]
        public string PhoneNumber { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? Address { get; set; } = null!;

        public string? ImageURL { get; set; }
    }
}
