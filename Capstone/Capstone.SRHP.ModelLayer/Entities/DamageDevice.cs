using Microsoft.Identity.Client;
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
    public class DamageDevice : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DamageDeviceId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LoggedDate { get; set; }

        public int? UtensilId { get; set; }
        public int? HotPotInventoryId { get; set; }


        [ForeignKey(nameof(HotPotInventoryId))]
        public virtual HotPotInventory? HotPotInventory { get; set; }

        [ForeignKey(nameof(UtensilId))]
        public virtual Utensil? Utensil { get; set; }

        public virtual ICollection<ReplacementRequest>? ReplacementRequests { get; set; }

    }
}
