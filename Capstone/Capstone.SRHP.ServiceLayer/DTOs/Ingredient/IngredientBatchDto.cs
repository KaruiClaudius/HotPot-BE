using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class IngredientBatchDto
    {
        public int IngredientBatchId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int InitialQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public string Unit { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ReceivedDate { get; set; }
        public double MeasurementValue { get; set; }

        public double PhysicalQuantity => RemainingQuantity * MeasurementValue;
        public string FormattedQuantity => $"{PhysicalQuantity} {Unit}";

        public int DaysUntilExpiration => (BestBeforeDate - DateTime.UtcNow).Days;
        public bool IsExpired => BestBeforeDate < DateTime.UtcNow;
    }
}
