using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Discount
{
    public class DiscountRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal DiscountPercentage { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? Duration { get; set; }
        public double? PointCost { get; set; }
    }

    public class DiscountUpdateRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Duration { get; set; }
        public bool UpdateDuration { get; set; }
        public double? PointCost { get; set; }
        public bool UpdatePointCost { get; set; }
    }
}
