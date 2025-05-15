using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboIngredientDto
    {
        public int ComboIngredientId { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public decimal Quantity { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ImageURL { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal TotalPrice { get; set; }
    }
}
