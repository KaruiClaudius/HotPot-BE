using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class DailyIngredientUsageReport
    {
        public DateTime Date { get; set; }
        public List<IngredientDailyUsage> Ingredients { get; set; } = new List<IngredientDailyUsage>();
        public int TotalOrderCount { get; set; }
        public decimal TotalCost { get; set; }
    }
}
