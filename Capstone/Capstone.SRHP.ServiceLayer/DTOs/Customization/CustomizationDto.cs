using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class CustomizationDto
    {
        public int CustomizationId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Size { get; set; }
        public string[] ImageURLs { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ComboName { get; set; }
    }

    public class CustomizationDetailDto : CustomizationDto
    {
        public int? ComboId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public List<CustomizationIngredientDto> Ingredients { get; set; }
    }
}
