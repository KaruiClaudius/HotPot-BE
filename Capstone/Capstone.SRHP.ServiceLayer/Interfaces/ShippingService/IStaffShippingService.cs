using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ShippingService
{
    public interface IStaffShippingService
    {      
        /// Gets all shipping orders assigned to a staff member    
        Task<IEnumerable<ShippingListDto>> GetShippingListAsync(int staffId);
        
        /// Gets detailed information about a specific shipping order   
        Task<ShippingListDto> GetShippingDetailAsync(int shippingOrderId);
   
        /// Gets pending (not delivered) shipping orders for a staff member     
        Task<IEnumerable<ShippingListDto>> GetPendingShippingListAsync(int staffId);
    
        /// Updates delivery notes for a shipping order     
        Task<ShippingListDto> UpdateDeliveryNotesAsync(int shippingOrderId, string notes);
    }
}
