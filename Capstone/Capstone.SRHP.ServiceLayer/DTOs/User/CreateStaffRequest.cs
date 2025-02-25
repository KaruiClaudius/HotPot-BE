using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.User
{
    public class CreateStaffRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
