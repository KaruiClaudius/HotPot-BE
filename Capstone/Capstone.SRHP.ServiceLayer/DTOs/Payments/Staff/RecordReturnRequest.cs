using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments.Staff
{
    public class RecordReturnRequest
    {
        [Required]
        public string ReturnCondition { get; set; }

        public decimal? DamageFee { get; set; }
    }
}
