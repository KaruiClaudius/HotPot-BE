using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class IngredientDailyUsage
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public decimal QuantityUsed { get; set; }
        public int OrderCount { get; set; }
        public decimal CostPerUnit { get; set; }
        public decimal TotalCost { get; set; }
    }
}
