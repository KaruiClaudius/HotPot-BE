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
        Task<Response> GetOrders();
        Task<Response> GetOrderByUserId(int userId);
        Task<Response> CreatePaymentLink(CreatePaymentLinkRequest body, string Phone, int postId, int transactionId);
        Task<Response> GetOrder(int orderCode);
        Task<Response> CancelOrder(int orderCode, string reason);
        Task<Response> ConfirmWebhook(ConfirmWebhook body);
        Task<Response> CheckOrder(CheckOrderRequest request, string userPhone);
        Task<Payment> CreateCashPaymentAsync(int userId, int orderId, decimal amount);
        Task<Payment> UpdatePaymentStatusAsync(int paymentId, PaymentStatus status);
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task<Payment> GetPaymentByIdAsync(int paymentId);
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);
    }
}
