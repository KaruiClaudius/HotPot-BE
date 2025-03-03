using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboIngredientDto
    {
        public int ComboIngredientId { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
    }
}
