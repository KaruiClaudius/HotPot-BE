using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboIngredientRequest
    {
        [Required]
        public int IngredientID { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
