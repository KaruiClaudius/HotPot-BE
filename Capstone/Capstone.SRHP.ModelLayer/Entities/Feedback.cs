using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class Feedback : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000)]
        public string Comment { get; set; }


        [StringLength(200)]
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
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User? User { get; set; }
        public virtual Order? Order { get; set; }

    }
}
