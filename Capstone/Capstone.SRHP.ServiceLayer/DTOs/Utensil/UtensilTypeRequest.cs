using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Utensil
{
    public class CreateUtensilTypeRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
