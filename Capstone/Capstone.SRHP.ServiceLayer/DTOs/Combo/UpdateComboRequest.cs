using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class UpdateRequest
    {

        [StringLength(100)]
        public string? Name { get; set; }




        [Range(1, int.MaxValue)]
        public int? Size { get; set; }


        public string[]? ImageURLs { get; set; }

        public int? TurtorialVideoID { get; set; }

    }    
    
    public class UpdateComboRequest : UpdateRequest
    {
        [StringLength(1000)]
        public string? Description { get; set; }

        public List<ComboIngredientRequest>? Ingredients { get; set; }

    }
    public class UpdateCustomizeComboRequest : UpdateRequest
    {

        [StringLength(1000)]
        public string? GroupIdentifier { get; set; }

        public List<ComboAllowedIngredientTypeRequest>? AllowedIngredientTypes { get; set; }

    }



}
