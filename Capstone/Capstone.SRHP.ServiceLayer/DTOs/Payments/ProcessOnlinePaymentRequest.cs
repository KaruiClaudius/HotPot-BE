using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments
{
    public class ProcessOnlinePaymentRequest
    {
        // Order details
        [Required]
        public int OrderId { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        public int? DiscountId { get; set; }

        public DateTime? ExpectedReturnDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string? ReturnUrl { get; set; }

        public string? CancelUrl { get; set; }
    }
}
