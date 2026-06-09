using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Entities;

public class ProjectMemberEntity 
{
    [ForeignKey(nameof(Project))]
    public Guid ProjectId { get; set; }

    public virtual ProjectEntity Project { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public virtual UserEntity User { get; set; } = null!;
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}