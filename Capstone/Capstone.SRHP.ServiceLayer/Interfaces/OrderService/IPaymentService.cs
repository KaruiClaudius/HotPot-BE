using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IPaymentService
    {
        Task<Response> ProcessOnlinePayment(int orderId, string address, string notes, int? discountId, CreatePaymentLinkRequest paymentRequest, int userId);
        Task<Response> GetOrder(int orderCode);
        Task<Response> CancelOrder(int orderCode, string reason);
        Task<Response> ConfirmWebhook(ConfirmWebhook body);
        Task<Response> CheckOrder(CheckOrderRequest request, string userPhone);
        Task<Payment> ProcessCashPayment(int orderId, string address, string notes, int? discountId, int userId);
        Task<Payment> UpdatePaymentStatusAsync(int paymentId, PaymentStatus status);
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task<Payment> GetPaymentByIdAsync(int paymentId);
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);
    }
}
