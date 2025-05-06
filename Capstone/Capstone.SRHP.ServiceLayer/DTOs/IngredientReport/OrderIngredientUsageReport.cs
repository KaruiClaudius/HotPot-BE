using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.IngredientReport
{
    public class OrderIngredientUsageReport
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int IngredientBatchId { get; set; }
        public string BatchNumber { get; set; }
        public decimal QuantityUsed { get; set; }
        public int? ComboId { get; set; }
        public string ComboName { get; set; }
        public int? CustomizationId { get; set; }
        public string CustomizationName { get; set; }
        public decimal CostPerUnit { get; set; }
        public decimal TotalCost { get; set; }
    }
}
