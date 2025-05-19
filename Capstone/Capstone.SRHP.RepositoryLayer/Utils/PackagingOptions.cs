using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.RepositoryLayer.Utils
{
    public static class PackagingOptions
    {
        public static readonly string Small = "Nhỏ";
        public static readonly string Medium = "Vừa";
        public static readonly string Large = "Lớn";

        public static readonly int SmallQuantity = 100;
        public static readonly int MediumQuantity = 250;
        public static readonly int LargeQuantity = 500;

        public static List<IngredientPackaging> CreateStandardOptions(int ingredientId)
        {
            return new List<IngredientPackaging>
        {
            new IngredientPackaging
            {
                Name = Small,
                Quantity = SmallQuantity,
                IngredientId = ingredientId,
                IsDefault = true
            },
            new IngredientPackaging
            {
                Name = Medium,
                Quantity = MediumQuantity,
                IngredientId = ingredientId,
                IsDefault = false
            },
            new IngredientPackaging
            {
                Name = Large,
                Quantity = LargeQuantity,
                IngredientId = ingredientId,
                IsDefault = false
            }
        };
        }
    }
}
