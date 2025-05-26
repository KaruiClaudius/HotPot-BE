using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class BatchSummaryDto
    {
        public string BatchNumber { get; set; }
        public DateTime ReceivedDate { get; set; }
        public List<string> ProvideCompanies { get; set; } = new List<string>();
        public int TotalIngredients { get; set; }
        public DateTime EarliestExpiryDate { get; set; }
        public DateTime LatestExpiryDate { get; set; }
    }
}
