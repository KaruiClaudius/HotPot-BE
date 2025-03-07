using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Hotpot : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotpotId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Material { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Size { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }

        [NotMapped]
        public string[]? ImageURLs
        {
            get => string.IsNullOrEmpty(ImageURL)
                ? null
                : JsonSerializer.Deserialize<string[]>(ImageURL);
            set => ImageURL = value != null ? JsonSerializer.Serialize(value) : null;
        }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal BasePrice { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public DateTime LastMaintainDate { get; set; }

        [Required]
        [ForeignKey("HotpotType")]
        public int HotpotTypeID { get; set; }

        [Required]
        [ForeignKey("HotPotInventory")]
        public int InventoryID { get; set; }

        [Required]
        [ForeignKey("TurtorialVideo")]
        public int TurtorialVideoID { get; set; }

        public virtual HotpotType? HotpotType { get; set; }
        public virtual TurtorialVideo? TurtorialVideo { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual ICollection<HotPotInventory>? InventoryUnits { get; set; }
    }
}
