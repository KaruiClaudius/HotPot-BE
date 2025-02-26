using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Utensil
{
    public class UtensilDto
    {
        public int UtensilId { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public string ItemType { get; set; }
        public DateTime LastMaintainDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
