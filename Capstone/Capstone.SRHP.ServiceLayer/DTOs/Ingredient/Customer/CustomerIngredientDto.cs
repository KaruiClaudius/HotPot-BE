using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient.Customer
{
    public class CustomerIngredientDto
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } // This will come from IngredientPrices
        public int IngredientTypeID { get; set; }
        public string IngredientTypeName { get; set; }
        public string ImageURL { get; set; }
        public bool IsAvailable { get; set; } // Derived from Quantity > 0
    }
}
