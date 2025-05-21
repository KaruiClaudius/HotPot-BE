using Capstone.HPTY.ServiceLayer.DTOs.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class CreateRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }



        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }

        public string[]? ImageURLs { get; set; }

        [Required]
        public TutorialVideoRequest TutorialVideo { get; set; }


    }    
    
    public class CreateComboRequest : CreateRequest
    {

        [StringLength(1000)]
        public string? Description { get; set; }


        [Required]
        public List<ComboIngredientRequest> Ingredients { get; set; }
    }

    

    public class CreateCustomizableComboRequest : CreateRequest
    {
        [StringLength(1000)]
        public string? GroupIdentifier { get; set; }

        [Required]
        public List<ComboAllowedIngredientTypeRequest> AllowedIngredientTypes { get; set; }
    }
}
