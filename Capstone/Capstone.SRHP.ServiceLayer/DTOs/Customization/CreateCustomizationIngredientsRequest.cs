using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class CreateCustomizationIngredientsRequest
    {
        public int IngredientID { get; set; }
        public int Quantity { get; set; }
    }
}
