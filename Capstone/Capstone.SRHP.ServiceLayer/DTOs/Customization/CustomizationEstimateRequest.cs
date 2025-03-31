using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class CustomizationEstimateRequest
    {
        [Required]
        public int? ComboId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }

        [Required]
        public int BrothId { get; set; }

        [Required]
        public List<CustomizationIngredientsRequest> Ingredients { get; set; }
    }

}
