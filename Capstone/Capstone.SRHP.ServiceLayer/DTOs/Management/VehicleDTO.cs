using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType Type { get; set; }
        public VehicleStatus Status { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateVehicleRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LicensePlate { get; set; }

        [Required]
        public VehicleType Type { get; set; }

        [Required]
        public VehicleStatus Status { get; set; } = VehicleStatus.Available;

        [StringLength(500)]
        public string? Notes { get; set; }
    }

    public class UpdateVehicleRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LicensePlate { get; set; }

        [Required]
        public VehicleType Type { get; set; }

        [Required]
        public VehicleStatus Status { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }

    public class UpdateVehicleStatusRequest
    {
        [Required]
        public VehicleStatus Status { get; set; }
    }

    public class AllocateOrderWithVehicleRequest
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int StaffId { get; set; }

        public int? VehicleId { get; set; }
    }

    public class OrderSizeDTO
    {
        public int OrderId { get; set; }
        public OrderSize Size { get; set; }
        public VehicleType SuggestedVehicleType { get; set; }
    }

    public class VehicleInfoDto
    {
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType VehicleType { get; set; }
        public OrderSize? OrderSize { get; set; }
    }
}
