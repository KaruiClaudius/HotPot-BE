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
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int HotpotBrothID { get; set; }
        public string HotpotBrothName { get; set; }
        public int ComboID { get; set; }
        public string ComboName { get; set; }
        public int? AppliedDiscountID { get; set; }
        public decimal AppliedDiscountPercentage { get; set; }
        public List<CustomizationIngredientDto> Ingredients { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
