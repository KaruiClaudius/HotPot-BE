using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Capstone.HPTY.ModelLayer.Enum;

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
        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(2000)]
        public string? ImageURL { get; set; }
        [NotMapped]
        public string[]? ImageURLs
        {
            get
            {
                if (string.IsNullOrEmpty(ImageURL))
                    return null;

                try
                {
                    return JsonSerializer.Deserialize<string[]>(ImageURL);
                }
                catch (JsonException)
                {
                    // Log the error if you have a logger
                    // _logger.LogWarning($"Failed to deserialize ImageURL: {ImageURL}");

                    // If it looks like a single URL rather than a JSON array, return it as a single-element array
                    if (ImageURL.StartsWith("h") && (ImageURL.Contains("http://") || ImageURL.Contains("https://")))
                    {
                        return new[] { ImageURL };
                    }

                    // Return an empty array as fallback
                    return Array.Empty<string>();
                }
            }
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

        [NotMapped]
        public int Quantity => InventoryUnits?.Count(i => !i.IsDelete) ?? 0;

        [Required]
        public DateTime LastMaintainDate { get; set; }

        public virtual ICollection<HotPotInventory>? InventoryUnits { get; set; }
    }
}
