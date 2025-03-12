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
        [Range(1, int.MaxValue, ErrorMessage = "Minimum size must be greater than 0")]
        public int MinSize { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100")]
        public decimal DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
