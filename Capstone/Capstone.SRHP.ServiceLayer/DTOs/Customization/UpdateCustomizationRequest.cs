using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Customization
{
    public class UpdateCustomizationRequest
    {

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }


        [Range(1, int.MaxValue)]
        public int? Size { get; set; }

        public int? BrothId { get; set; }

        public string[]? ImageURLs { get; set; }

        public List<CustomizationIngredientsRequest>? Ingredients { get; set; }
    }
}
