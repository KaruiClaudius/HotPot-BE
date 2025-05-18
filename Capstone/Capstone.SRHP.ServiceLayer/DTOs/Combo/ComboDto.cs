using Capstone.HPTY.ServiceLayer.DTOs.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class ComboDto
    {
        public int ComboId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string[] ImageURLs { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class RegularComboDto : ComboDto
    {
        public string Description { get; set; }
        public List<ComboIngredientDto> Ingredients { get; set; }
    }

    public class CustomizableComboDto : ComboDto
    {
        public string GroupIdentifier { get; set; } 
        public List<ComboAllowedIngredientTypeDto> AllowedIngredientTypes { get; set; }

        // Group information
        public bool IsPartOfGroup { get; set; }
    }
    public class CustomizableComboVariantDto
    {
        public int ComboId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
    }

    public class ComboDetailDto : ComboDto
    {
        // Regular combo specific properties
        public string Description { get; set; }
        public List<ComboIngredientDto> Ingredients { get; set; }

        // Customizable combo specific properties
        public string GroupIdentifier { get; set; }
        public List<ComboAllowedIngredientTypeDto> AllowedIngredientTypes { get; set; }
        public bool IsPartOfGroup { get; set; }
        public List<CustomizableComboVariantDto> GroupVariants { get; set; }

        // Common detail properties
        public int? AppliedDiscountID { get; set; }
        public decimal AppliedDiscountPercentage { get; set; }
        public int TurtorialVideoID { get; set; }
        public string TutorialVideoName { get; set; }
        public string TutorialVideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TutorialVideoDto TutorialVideo { get; set; }

        // Flag to indicate the type of combo
        public bool IsCustomizable { get; set; }
    }
}
