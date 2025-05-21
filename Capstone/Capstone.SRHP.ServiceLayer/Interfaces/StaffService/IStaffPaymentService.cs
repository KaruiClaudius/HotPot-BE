using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffPaymentService
    {
        //Task<PaymentDetailDto> ConfirmDepositAsync(ConfirmDepositRequest request);
        //Task<PaymentReceiptDto> ProcessPaymentAsync(ProcessPaymentRequest request);
        Task<PagedResult<PaymentListItemDto>> GetPaymentsAsync(PaymentFilterRequest filter, int pageNumber, int pageSize);
        Task<PaymentReceiptDto> GenerateDetailedReceiptAsync(int paymentId);
    }
}
