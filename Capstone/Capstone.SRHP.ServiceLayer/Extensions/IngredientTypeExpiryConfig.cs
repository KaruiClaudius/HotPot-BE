using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Extensions
{
    public class IngredientTypeExpiryConfig
    {
        // Minimum days before expiry for each ingredient type
        private static readonly Dictionary<int, int> MinExpiryDays = new Dictionary<int, int>
    {
        { 1, 1 },  // Nước Lẩu - 6 months
        { 2, 3 },    // Hải Sản - 3 days
        { 3, 7 },    // Rau Củ - 7 days
        { 4, 90 },   // Mì - 3 months
        { 5, 14 },   // Đậu Phụ - 2 weeks
        { 6, 7 },    // Nấm - 7 days
        { 7, 5 },    // Thịt - 5 days
        { 8, 180 },  // Nước Chấm - 6 months
        { 9, 5 },    // Thịt Heo - 5 days
        { 10, 3 },   // Tôm - 3 days
        { 11, 5 }    // Thịt gà - 5 days
    };

        // Maximum days before expiry for each ingredient type
        private static readonly Dictionary<int, int> MaxExpiryDays = new Dictionary<int, int>
    {
        { 1, 2 },  // Nước Lẩu - 1 year
        { 2, 30 },   // Hải Sản - 1 month (if frozen)
        { 3, 30 },   // Rau Củ - 1 month (if preserved)
        { 4, 365 },  // Mì - 1 year
        { 5, 60 },   // Đậu Phụ - 2 months (if preserved)
        { 6, 60 },   // Nấm - 2 months (if dried)
        { 7, 180 },  // Thịt - 6 months (if frozen)
        { 8, 730 },  // Nước Chấm - 2 years
        { 9, 180 },  // Thịt Heo - 6 months (if frozen)
        { 10, 180 }, // Tôm - 6 months (if frozen)
        { 11, 180 }  // Thịt gà - 6 months (if frozen)
    };

        // Default values for unknown ingredient types
        private const int DefaultMinExpiryDays = 7;
        private const int DefaultMaxExpiryDays = 365;

        public static int GetMinExpiryDays(int ingredientTypeId)
        {
            return MinExpiryDays.TryGetValue(ingredientTypeId, out int days) ? days : DefaultMinExpiryDays;
        }

        public static int GetMaxExpiryDays(int ingredientTypeId)
        {
            return MaxExpiryDays.TryGetValue(ingredientTypeId, out int days) ? days : DefaultMaxExpiryDays;
        }

        public static DateTime GetMinExpiryDate(int ingredientTypeId)
        {
            return DateTime.UtcNow.AddDays(GetMinExpiryDays(ingredientTypeId));
        }

        public static DateTime GetMaxExpiryDate(int ingredientTypeId)
        {
            return DateTime.UtcNow.AddDays(GetMaxExpiryDays(ingredientTypeId));
        }

        public static bool IsValidExpiryDate(int ingredientTypeId, DateTime expiryDate)
        {
            var minDate = GetMinExpiryDate(ingredientTypeId);
            var maxDate = GetMaxExpiryDate(ingredientTypeId);

            return expiryDate >= minDate && expiryDate <= maxDate;
        }

        public static string GetExpiryValidationMessage(int ingredientTypeId)
        {
            int minDays = GetMinExpiryDays(ingredientTypeId);
            int maxDays = GetMaxExpiryDays(ingredientTypeId);

            return $"Ngày hết hạn phải nằm trong khoảng từ {minDays} đến {maxDays} ngày kể từ hôm nay đối với loại nguyên liệu này";

        }
    }
}
