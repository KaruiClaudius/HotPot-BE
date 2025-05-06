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
        public string Description { get; set; }
        public int Size { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCustomizable { get; set; }
        public string HotpotBrothName { get; set; }
        public string[] ImageURLs { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ComboIngredientDto> Ingredients { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ComboAllowedIngredientTypeDto> AllowedIngredientTypes { get; set; }

    }

    public class ComboDetailDto : ComboDto
    {
        public int? AppliedDiscountID { get; set; }
        public decimal AppliedDiscountPercentage { get; set; }
        public int TurtorialVideoID { get; set; }
        public string TutorialVideoName { get; set; }
        public string TutorialVideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TutorialVideoDto TutorialVideo { get; set; }

    }
}
