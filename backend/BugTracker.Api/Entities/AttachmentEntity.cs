using BugTracker.Api.Entities;
using System.ComponentModel.DataAnnotations;

public class AttachmentEntity : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string StoredFileName { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string FilePath { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string ContentType { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public string? FileHash { get; set; }

    public Guid BugId { get; set; }

    public virtual BugEntity Bug { get; set; } = null!;

    public Guid UploadedById { get; set; }

    public virtual UserEntity UploadedBy { get; set; } = null!;
}