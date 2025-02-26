using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class UpdateHotPotInventoryRequest
    {
        [StringLength(100)]
        public string SeriesNumber { get; set; }
    }
}
