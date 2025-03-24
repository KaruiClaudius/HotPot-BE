using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customer
{
    public class UnifiedProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string[] ImageURLs { get; set; }
        public bool IsAvailable { get; set; }
        public string ProductType { get; set; } // "Hotpot", "Utensil", "Ingredient"

        // Common properties
        public string Material { get; set; }
        public int Quantity { get; set; } 

        // Type-specific properties
        public string Size { get; set; } // For Hotpot
        public int TypeId { get; set; } // For Ingredient and Utensil
        public string TypeName { get; set; } // For Ingredient and Utensil
    }


}
