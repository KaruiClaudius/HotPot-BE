using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments.Admin
{
    public class CartVerificationResult
    {
        public bool AllItemsAvailable { get; set; }
        public List<string> UnavailableItems { get; set; } = new List<string>();
    }
}
