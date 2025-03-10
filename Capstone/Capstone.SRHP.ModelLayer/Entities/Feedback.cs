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
        get => string.IsNullOrEmpty(ImageURL)
            ? null
            : JsonSerializer.Deserialize<string[]>(ImageURL);
        set => ImageURL = value != null ? JsonSerializer.Serialize(value) : null;
    }

    [StringLength(2000)]
    public string? Response { get; set; }

    public DateTime? ResponseDate { get; set; }

    [ForeignKey("Manager")]
    public int? ManagerId { get; set; }

    [Required]
    [ForeignKey("Order")]
    public int OrderID { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserID { get; set; }

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

