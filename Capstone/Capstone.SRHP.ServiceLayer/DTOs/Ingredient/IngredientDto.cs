using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int MinStockLevel { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double MeasurementValue { get; set; }
        public double PhysicalQuantity => Quantity * MeasurementValue;
        public string FormattedQuantity => $"{PhysicalQuantity} {Unit}";
        public int IngredientTypeID { get; set; }
        public string IngredientTypeName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsLowStock { get; set; }

    }    
    public class IngredientDetailDto : IngredientDto
    {
        public List<IngredientBatchDto> Batches { get; set; } = new List<IngredientBatchDto>();

    }


}
