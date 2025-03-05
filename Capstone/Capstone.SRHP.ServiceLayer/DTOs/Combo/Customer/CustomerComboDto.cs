using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo.customer
{
    public class CustomerComboDto
    {
        public int ComboId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsCustomizable { get; set; }
        public string HotpotBrothName { get; set; }
        public string[] ImageURLs { get; set; } // Array of image URLs
    }

    public class CustomerComboDetailDto : CustomerComboDto
    {
        public List<CustomerComboIngredientDto> Ingredients { get; set; }
        public List<CustomerAllowedIngredientTypeDto> AllowedIngredientTypes { get; set; }
    }
}
