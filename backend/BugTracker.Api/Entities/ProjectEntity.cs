using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Entities;

[Table("Projects")]
public class ProjectEntity: BaseEntity
{
    

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Description { get; set; }

    public bool IsArchived { get; set; } = false;

    [ForeignKey(nameof(Manager))]
    public Guid ManagerId { get; set; }

    public virtual UserEntity Manager { get; set; } = null!;

    public virtual ICollection<ProjectMemberEntity> Members { get; set; }
        = new List<ProjectMemberEntity>();

    public virtual ICollection<BugEntity> Bugs { get; set; }
        = new List<BugEntity>();
}
