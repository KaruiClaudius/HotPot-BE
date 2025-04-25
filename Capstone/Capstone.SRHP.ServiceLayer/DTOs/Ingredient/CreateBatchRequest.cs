using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class CreateBatchRequest
    {
        [Required]
        public int IngredientId { get; set; }

        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Total amount must be greater than 0")]
        public double TotalAmount { get; set; }

        [Required]
        public DateTime BestBeforeDate { get; set; }

        public string BatchNumber { get; set; }
    }
}
