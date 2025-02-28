using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class IngredientPriceDto
    {
        public int IngredientPriceId { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
