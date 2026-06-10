using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Entities;

[Table("Users")]
public class UserEntity: BaseEntity
{
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(Role))]
    public Guid RoleId { get; set; }

    public virtual RoleEntity Role { get; set; } = null!;

    public ICollection<ProjectEntity> ManagedProjects { get; set; }
    = new List<ProjectEntity>();

    public ICollection<BugEntity> AssignedBugs { get; set; }
        = new List<BugEntity>();

    public ICollection<BugEntity> ReportedBugs { get; set; }
        = new List<BugEntity>();

    public ICollection<CommentEntity> Comments { get; set; }
        = new List<CommentEntity>();

    public ICollection<AttachmentEntity> Attachments { get; set; }
        = new List<AttachmentEntity>();

    public ICollection<BugHistoryEntity> BugHistories { get; set; }
        = new List<BugHistoryEntity>();
}