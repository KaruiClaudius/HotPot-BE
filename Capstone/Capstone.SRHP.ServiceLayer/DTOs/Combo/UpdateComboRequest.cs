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
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }

        [Required]
        public int HotpotBrothID { get; set; }

        public string[] ImageURLs { get; set; }

        public int? TurtorialVideoID { get; set; }
    }
}
