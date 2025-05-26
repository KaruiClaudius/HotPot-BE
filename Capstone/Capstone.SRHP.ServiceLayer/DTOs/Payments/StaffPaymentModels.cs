using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Payments
{

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

        // Order details
        public string OrderStatus { get; init; } = string.Empty;
        public string DeliveryAddress { get; init; } = string.Empty;

        // Order items
        public List<ReceiptItemDto> SoldItems { get; init; } = new List<ReceiptItemDto>();
        public List<ReceiptRentalItemDto> RentedItems { get; init; } = new List<ReceiptRentalItemDto>();

        // Pricing summary
        //public decimal DiscountAmount { get; init; }
        public decimal TotalAmount { get; init; }

        // Additional fees if applicable
        public decimal? LateFee { get; init; }
        public decimal? DamageFee { get; init; }

        // Notes
        public string Notes { get; init; } = string.Empty;
    }

    public record ReceiptItemDto
    {
        public string ItemType { get; init; } = string.Empty; // Ingredient, Utensil, Combo, Customization
        public string Name { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
        public decimal TotalPrice { get; init; }
    }

    public record ReceiptRentalItemDto
    {
        public string Name { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public decimal RentalPrice { get; init; }
        public DateTime RentalStartDate { get; init; }
        public DateTime ExpectedReturnDate { get; init; }
        public DateTime? ActualReturnDate { get; init; }
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
        public string? OrderCode { get; init; } = string.Empty;
        public int? OrderId { get; init; }
        public string OrderStatus { get; init; } = string.Empty;

        // Minimal user information
        public int UserId { get; init; }
        public string CustomerName { get; init; } = string.Empty;
        public string CustomerPhone { get; init; } = string.Empty;
    }
}
