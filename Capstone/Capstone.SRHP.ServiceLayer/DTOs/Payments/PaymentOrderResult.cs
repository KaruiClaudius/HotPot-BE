using Capstone.HPTY.ModelLayer.Entities;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments
{
    public class PaymentOrderResult
    {
        public Payment Transaction { get; set; }
        public PaymentLinkInformation PaymentLinkInformation { get; set; }
    }
}
