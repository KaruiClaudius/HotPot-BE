using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class IngredientUsageByComboReport
    {
        public int ComboId { get; set; }
        public string ComboName { get; set; }
        public int OrderCount { get; set; }
        public int TotalQuantitySold { get; set; }
        public List<ComboIngredientUsage> Ingredients { get; set; } = new List<ComboIngredientUsage>();
        public decimal TotalIngredientCost { get; set; }
        public decimal AverageIngredientCostPerOrder { get; set; }
    }
}
