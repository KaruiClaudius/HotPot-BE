using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo.customer
{
    public class CustomerComboIngredientDto
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FormattedQuantity { get; set; }
    }
}
