using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboAllowedIngredientTypeRequest
    {
        [Required]
        public int IngredientTypeId { get; set; }

        [Required]
        [Range(0.001, double.MaxValue)]
        public decimal MinQuantity { get; set; } 

        [Required]
        [StringLength(20)]
        public string MeasurementUnit { get; set; }
    }
}
