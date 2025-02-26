using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class CreateHotPotInventoryRequest
    {
        [Required]
        [StringLength(100)]
        public string SeriesNumber { get; set; }

        [Required]
        public int HotpotId { get; set; }
    }
}
