using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Combo
{
    public class UpdateComboRequest
    {

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }


        [Range(1, int.MaxValue)]
        public int? Size { get; set; }


        public int? HotpotBrothID { get; set; }

        public string[]? ImageURLs { get; set; }

        public int? TurtorialVideoID { get; set; }

    }
}
