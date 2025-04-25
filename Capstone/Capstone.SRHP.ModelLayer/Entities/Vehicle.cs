using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Vehicle : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; }

        [Required]
        public VehicleType Type { get; set; }

        [Required]
        public VehicleStatus Status { get; set; } = VehicleStatus.Available;

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation property for shipping orders using this vehicle
        public virtual ICollection<ShippingOrder> ShippingOrders { get; set; } = new List<ShippingOrder>();
    }
}
