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
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(2000)]
        public string ImageURL { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinStockLevel { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }

        public int? IngredientTypeID { get; set; }
    }
}
