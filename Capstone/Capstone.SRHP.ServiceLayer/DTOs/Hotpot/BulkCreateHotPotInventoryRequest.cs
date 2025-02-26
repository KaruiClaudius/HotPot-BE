using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class BulkCreateHotPotInventoryRequest
    {
        [Required]
        public int HotpotId { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string SeriesNumberPrefix { get; set; }
    }

}
