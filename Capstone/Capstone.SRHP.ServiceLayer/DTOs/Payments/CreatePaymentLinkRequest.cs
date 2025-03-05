using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments
{
    public record CreatePaymentLinkRequest(
        string productName,
        string description,
        int price,
        string? returnUrl,
        string? cancelUrl,
        string? buyerName,
        string? buyerPhone
    );
}
