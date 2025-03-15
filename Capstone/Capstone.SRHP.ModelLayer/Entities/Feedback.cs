using Capstone.HPTY.ModelLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Capstone.HPTY.ModelLayer.Enum;

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

    [StringLength(2000)]
    public string? Response { get; set; }

    public DateTime? ResponseDate { get; set; }

    [ForeignKey("Manager")]
    public int? ManagerId { get; set; }

    [Required]
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    // New properties for approval process
    public FeedbackApprovalStatus ApprovalStatus { get; set; } = FeedbackApprovalStatus.Pending;
    public DateTime? ApprovalDate { get; set; }

    [ForeignKey("ApprovedByUser")]
    public int? ApprovedByUserId { get; set; }

    [StringLength(500)]
    public string? RejectionReason { get; set; }

    public virtual User? User { get; set; }
    public virtual Order? Order { get; set; }
    public virtual Manager? Manager { get; set; }
    public virtual User? ApprovedByUser { get; set; }
}

