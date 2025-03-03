using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class CustomizationIngredientDto
    {
        public int CustomizationIngredientId { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
    }
}
