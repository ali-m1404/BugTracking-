using BugTracker.Api.Entities;
using System.ComponentModel.DataAnnotations;

public class BugHistoryEntity : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string FieldName { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? OldValue { get; set; }

    [MaxLength(2000)]
    public string? NewValue { get; set; }

    public Guid BugId { get; set; }

    public virtual BugEntity Bug { get; set; } = null!;

    public Guid ChangedById { get; set; }

    public virtual UserEntity ChangedBy { get; set; } = null!;
}