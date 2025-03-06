using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo.customer
{
    public class CustomerAllowedIngredientTypeDto
    {
        public int IngredientTypeId { get; set; }
        public string IngredientTypeName { get; set; }
        public int MaxQuantity { get; set; }
    }
}
