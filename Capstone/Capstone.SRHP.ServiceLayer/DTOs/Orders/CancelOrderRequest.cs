using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class CancelOrderRequest
    {
        [Required]
        [StringLength(1000)]
        public string CancellationReason { get; set; }
    }
}
