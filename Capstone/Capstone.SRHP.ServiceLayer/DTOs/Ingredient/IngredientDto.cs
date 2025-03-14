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
        public decimal MinStockLevel { get; set; }
        public decimal Quantity { get; set; }
        public string MeasurementUnit { get; set; }
        public int IngredientTypeID { get; set; }
        public string IngredientTypeName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsLowStock { get; set; }
    }
}
