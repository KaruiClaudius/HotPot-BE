using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ShippingService
{
    public interface IEquipmentReturnService
    {
        Task<bool> ProcessEquipmentReturnAsync(
        EquipmentReturnRequest request);

        Task<bool> CompletePickupAssignmentAsync(
            int assignmentId,
            EquipmentReturnRequest request);

        Task<RentOrder> GetRentOrderAsync(int orderId);
    }
}
