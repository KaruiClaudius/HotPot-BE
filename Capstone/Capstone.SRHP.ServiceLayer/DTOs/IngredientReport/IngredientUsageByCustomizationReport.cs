using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class IngredientUsageByCustomizationReport
    {
        public int CustomizationId { get; set; }
        public string CustomizationName { get; set; }
        public int OrderCount { get; set; }
        public int TotalQuantitySold { get; set; }
        public List<CustomizationIngredientUsage> Ingredients { get; set; } = new List<CustomizationIngredientUsage>();
        public decimal TotalIngredientCost { get; set; }
        public decimal AverageIngredientCostPerOrder { get; set; }
    }
}
