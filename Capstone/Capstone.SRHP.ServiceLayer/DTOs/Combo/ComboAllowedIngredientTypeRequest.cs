using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboAllowedIngredientTypeRequest
    {
        [Required]
        public int IngredientTypeId { get; set; }

        [Required]
        public int MinQuantity { get; set; }
    }
}
