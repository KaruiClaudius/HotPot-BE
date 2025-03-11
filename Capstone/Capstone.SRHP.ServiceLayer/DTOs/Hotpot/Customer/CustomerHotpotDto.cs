using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot.Customer
{
    public class CustomerHotpotDto
    {
        public int HotpotId { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string[] ImageURLs { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string HotpotTypeName { get; set; }
    }

    public class CustomerHotpotDetailDto : CustomerHotpotDto
    {
        public int TurtorialVideoID { get; set; }
        public string TurtorialVideoUrl { get; set; }
        public string TurtorialVideoTitle { get; set; }
    }
}
