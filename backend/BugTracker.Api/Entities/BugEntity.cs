using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Api.Enums;

namespace BugTracker.Api.Entities;

public class BugEntity: BaseEntity
{

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(5000)]
    public string Description { get; set; } = string.Empty;

    public BugPriority Priority { get; set; } = BugPriority.Medium;

    public BugStatus Status { get; set; } = BugStatus.New;

    // Project Relationship
    [ForeignKey(nameof(Project))]
    public Guid ProjectId { get; set; }

    public virtual ProjectEntity Project { get; set; } = null!;

    // Reporter Relationship
    [ForeignKey(nameof(ReportedBy))]
    public Guid ReportedById { get; set; }

    public virtual UserEntity ReportedBy { get; set; } = null!;

    // Assigned Developer Relationship
    [ForeignKey(nameof(AssignedTo))]
    public Guid? AssignedToId { get; set; }

    public virtual UserEntity? AssignedTo { get; set; }

    // Navigation Properties
    public virtual ICollection<CommentEntity> Comments { get; set; }
        = new List<CommentEntity>();

    public virtual ICollection<AttachmentEntity> Attachments { get; set; }
        = new List<AttachmentEntity>();

    public virtual ICollection<BugHistoryEntity> Histories { get; set; }
        = new List<BugHistoryEntity>();
}