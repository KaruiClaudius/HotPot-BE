using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboAllowedIngredientTypeDto
    {
        public int Id { get; set; }
        public int IngredientTypeId { get; set; }
        public string IngredientTypeName { get; set; }
        public decimal MinQuantity { get; set; } 
        public string MeasurementUnit { get; set; }
    }
}
