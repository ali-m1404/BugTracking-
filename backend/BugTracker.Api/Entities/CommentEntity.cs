using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Entities;

public class CommentEntity: BaseEntity
{

    [Required]
    [MaxLength(2000)]
    public string Content { get; set; } = string.Empty;

    [ForeignKey(nameof(Bug))]
    public Guid BugId { get; set; }

    public virtual BugEntity Bug { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public virtual UserEntity User { get; set; } = null!;
}