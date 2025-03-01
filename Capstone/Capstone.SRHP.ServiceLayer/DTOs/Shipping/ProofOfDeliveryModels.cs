using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Capstone.HPTY.ServiceLayer.DTOs.Shipping
{
    public class ProofOfDeliveryDto
    {
        public int ShippingOrderId { get; set; }
        public string? Base64Image { get; set; }
        public string? ImageType { get; set; }
        public string? Base64Signature { get; set; }
        public string? DeliveryNotes { get; set; }
        public DateTime? ProofTimestamp { get; set; }
    }

    public class ProofOfDeliveryRequest
    {
        public string? Base64Image { get; set; }
        public string? ImageType { get; set; }
        public string? Base64Signature { get; set; }
        public string? DeliveryNotes { get; set; }
    }

    public class ProofOfDeliveryResponse
    {
        public int ShippingOrderId { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? ProofTimestamp { get; set; }
        public string? DeliveryNotes { get; set; }
        public bool HasProofImage { get; set; }
        public bool HasSignature { get; set; }
    }
    public class ProofOfDeliveryFormRequest
    {    
        /// The proof of delivery image file 
        public IFormFile ProofImage { get; set; }
      
        /// Base64-encoded signature data       
        public string Base64Signature { get; set; }

        /// Additional notes about the delivery
        public string DeliveryNotes { get; set; }
    }
}
