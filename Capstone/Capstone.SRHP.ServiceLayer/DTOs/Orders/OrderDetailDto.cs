using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }

        public int? Quantity { get; set; }

        public decimal? VolumeWeight { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; } // "Ingredient", "Customization", "Combo"

        public int? ItemId { get; set; }

        public int OrderId { get; set; }
    }

    public class RentalDetailDto
    {
        public int RentalDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal RentalPrice { get; set; }
        public int? HotpotInventoryId { get; set; }
        public string HotpotName { get; set; }
        public string SeriesNumber { get; set; }

        // Rental dates and fees
        public DateTime? RentalStartDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
        public string RentalNotes { get; set; }
        public string ReturnCondition { get; set; }
    }
}