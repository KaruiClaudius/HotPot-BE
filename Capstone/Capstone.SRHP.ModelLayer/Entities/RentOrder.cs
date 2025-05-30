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
    public class RentOrder : BaseEntity
    {
        [Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        // Moved properties from RentOrderDetail
        [Required]
        public DateTime RentalStartDate { get; set; }

        [Required]
        public DateTime ExpectedReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LateFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DamageFee { get; set; }

        [StringLength(500)]
        public string? RentalNotes { get; set; }

        [StringLength(500)]
        public string? ReturnCondition { get; set; }

        // New nullable vehicle-related properties
        public int? VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle? Vehicle { get; set; }

        public OrderSize? OrderSize { get; set; }

        // Additional vehicle-related fields
        public DateTime? VehicleAssignedDate { get; set; }

        public DateTime? VehicleReturnedDate { get; set; }

        [StringLength(500)]
        public string? VehicleNotes { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<RentOrderDetail> RentOrderDetails { get; set; } = new List<RentOrderDetail>();
    }
}