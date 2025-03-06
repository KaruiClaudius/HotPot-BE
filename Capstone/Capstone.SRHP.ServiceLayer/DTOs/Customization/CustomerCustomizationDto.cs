using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class CustomerCustomizationDto
    {
        public int CustomizationId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int Size { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string HotpotBrothName { get; set; }
        public string ComboName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string[] ImageURLs { get; set; } // Array of image URLs
    }

    public class CustomerCustomizationDetailDto : CustomerCustomizationDto
    {
        public List<CustomizationIngredientDto> Ingredients { get; set; }
    }
}
