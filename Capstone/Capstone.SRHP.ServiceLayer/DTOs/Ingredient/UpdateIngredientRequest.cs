using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class UpdateIngredientRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinStockLevel { get; set; }

        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(1, int.MaxValue)]
        public int? IngredientTypeID { get; set; }
    }
}
