using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class UpdateIngredientRequest
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Quantity { get; set; }

        [StringLength(20)]
        public string? MeasurementUnit { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MinStockLevel { get; set; }

        public int? IngredientTypeID { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; set; }
    }
}
