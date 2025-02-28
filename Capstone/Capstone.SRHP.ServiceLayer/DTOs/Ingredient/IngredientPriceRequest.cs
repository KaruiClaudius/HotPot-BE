using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class IngredientPriceRequest
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public int IngredientID { get; set; }
    }
}
