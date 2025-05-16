using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class CustomizationIngredientDto
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FormattedQuantity { get; set; }
    }
}
