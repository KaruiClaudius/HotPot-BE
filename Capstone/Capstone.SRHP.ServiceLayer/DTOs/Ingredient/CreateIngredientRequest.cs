using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class CreateIngredientRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Measurement value must be greater than 0")]
        public double MeasurementValue { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalAmount { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int MinStockLevel { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int IngredientTypeID { get; set; }

        [Required]
        public DateTime BestBeforeDate { get; set; }
    }

}
