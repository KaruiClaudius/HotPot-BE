using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Utensil
{
    public class UpdateUtensilRequest
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Material { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }

        public bool? Status { get; set; }

        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }

        public int? UtensilTypeID { get; set; }
    }
}
