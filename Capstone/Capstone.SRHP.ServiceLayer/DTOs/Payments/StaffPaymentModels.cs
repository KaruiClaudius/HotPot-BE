using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments
{
    public record ConfirmDepositRequest
    {
        public int OrderId { get; init; }
        public int PaymentId { get; init; }
    }

    public record ProcessPaymentRequest
    {
        public int OrderId { get; init; }
        public int PaymentId { get; init; }
        public PaymentStatus NewStatus { get; init; }
        public bool GenerateReceipt { get; init; } = true;
    }

    public record PaymentReceiptDto
    {
        public int ReceiptId { get; init; }
        public int OrderId { get; init; }
        public string OrderCode { get; init; } = string.Empty;
        public int PaymentId { get; init; }
        public string TransactionCode { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public DateTime PaymentDate { get; init; }
        public string CustomerName { get; init; } = string.Empty;
        public string CustomerPhone { get; init; } = string.Empty;
        public string PaymentMethod { get; init; } = string.Empty;
    }

    public record PaymentFilterRequest
    {
        public PaymentStatus? Status { get; init; }
        public DateTime? FromDate { get; init; }
        public DateTime? ToDate { get; init; }
        public string? SortBy { get; init; } = "CreatedAt";
        public bool SortDescending { get; init; } = true;
    }

    public record PaymentListItemDto
    {
        public int PaymentId { get; init; }
        public int TransactionCode { get; init; }
        public string PaymentType { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }

        // Minimal order information
        public int? OrderId { get; init; }
        public string OrderStatus { get; init; } = string.Empty;

        // Minimal user information
        public int UserId { get; init; }
        public string CustomerName { get; init; } = string.Empty;
        public string CustomerPhone { get; init; } = string.Empty;
    }

    public record PaymentDetailDto
    {
        public int PaymentId { get; init; }
        public int TransactionCode { get; init; }
        public string PaymentType { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }

        // Order information
        public OrderInfoDto? Order { get; init; }

        // User information
        public UserInfoDto User { get; init; } = null!;

        // Receipt information (if available)
        public ReceiptInfoDto? Receipt { get; init; }
    }

    public record OrderInfoDto
    {
        public int OrderId { get; init; }
        public string Status { get; init; } = string.Empty;
        public decimal TotalPrice { get; init; }
        public string Address { get; init; } = string.Empty;
        public string? Notes { get; init; }
    }

    public record UserInfoDto
    {
        public int UserId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
    }

    public record ReceiptInfoDto
    {
        public int ReceiptId { get; init; }
        public string ReceiptNumber { get; init; } = string.Empty;
        public DateTime GeneratedAt { get; init; }
    }
}
