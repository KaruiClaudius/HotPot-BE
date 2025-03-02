using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount
{
    public class SizeDiscountCreateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int MinSize { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
