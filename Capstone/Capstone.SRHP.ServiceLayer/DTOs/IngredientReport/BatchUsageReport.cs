using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class BatchUsageReport
    {
        public int IngredientBatchId { get; set; }
        public string BatchNumber { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public decimal InitialQuantity { get; set; }
        public decimal TotalQuantityUsed { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int OrderCount { get; set; }
        public decimal UsagePercentage { get; set; }
        public decimal CostPerUnit { get; set; }
        public decimal TotalCost { get; set; }
    }
}
