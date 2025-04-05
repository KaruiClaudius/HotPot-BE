using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class ProductConsumptionStats
    {
        public List<TopSellingItemDto> TopOverallProducts { get; set; }
        public List<TopSellingItemDto> TopIngredients { get; set; }
        public List<TopSellingItemDto> TopCombos { get; set; }
        public List<TopSellingItemDto> TopCustomizations { get; set; }
        public List<TopSellingItemDto> TopHotpots { get; set; }
        public List<TopSellingItemDto> TopUtensils { get; set; }
    }
}
