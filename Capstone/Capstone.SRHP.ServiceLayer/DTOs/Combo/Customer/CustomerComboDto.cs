using Capstone.HPTY.ServiceLayer.DTOs.Combo.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo.customer
{
    public class CustomerComboDto
    {
        public int ComboId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int QuantitySell { get; set; } 
        public bool IsCustomizable { get; set; }
        public string[] ImageURLs { get; set; }

        // Video information
        public int? TurtorialVideoID { get; set; }
        public string TutorialVideoName { get; set; }
        public string TutorialVideoUrl { get; set; }

        // Regular combo specific - only populated for non-customizable combos
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        // Group information - only populated for customizable combos
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GroupIdentifier { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsPartOfGroup { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CustomerComboVariantDto> GroupVariants { get; set; }
    }

    // Detail DTO for single combo view
    public class CustomerComboDetailDto : CustomerComboDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomerTutorialVideoDto TutorialVideo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CustomerComboIngredientDto> Ingredients { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CustomerAllowedIngredientTypeDto> AllowedIngredientTypes { get; set; }
    }

    public class CustomerComboVariantDto
    {
        public int ComboId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
    }
}
