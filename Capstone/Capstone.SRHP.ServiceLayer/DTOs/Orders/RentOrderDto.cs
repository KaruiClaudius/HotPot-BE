using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class RecordReturnRequest
    {
        public DateTime ActualReturnDate { get; set; }
        public string ReturnCondition { get; set; }
        public decimal? DamageFee { get; set; }
        public string Notes { get; set; }
    }

    public class UpdateRentOrderDetailRequest
    {
        public string ExpectedReturnDate { get; set; }
        public string Notes { get; set; }
    }

    public class RentOrderDetailDto
    {
        public int RentOrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int? HotpotInventoryId { get; set; }
        public string HotpotName { get; set; }
        public int Quantity { get; set; }
        public decimal RentalPrice { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
        public string RentalNotes { get; set; }
        public string ReturnCondition { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
    }

    public class RentOrderDetailResponse
    {
        public int Id { get; set; } // Rent Order Detail Id
        public int OrderId { get; set; }
        public string EquipmentType { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string RentalStartDate { get; set; }
        public string ExpectedReturnDate { get; set; }
        public string ActualReturnDate { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string Notes { get; set; }
    }
    public class ExtendRentalRequest
    {
        public DateTime NewExpectedReturnDate { get; set; }
    }

    public class RentalHistoryItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string EquipmentName { get; set; }
        public string RentalStartDate { get; set; }
        public string ExpectedReturnDate { get; set; }
        public string ActualReturnDate { get; set; }
        public string Status { get; set; }
    }
    public class RentalListingDto
    {
        public int RentOrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public decimal RentalPrice { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? DamageFee { get; set; }
    }
}
