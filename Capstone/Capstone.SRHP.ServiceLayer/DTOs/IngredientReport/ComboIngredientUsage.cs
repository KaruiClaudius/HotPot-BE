using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class ComboIngredientUsage
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public decimal TotalQuantityUsed { get; set; }
        public decimal QuantityPerCombo { get; set; }
        public decimal CostPerUnit { get; set; }
        public decimal TotalCost { get; set; }
    }
}
