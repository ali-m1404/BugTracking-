using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Api.Entities;

[Table("Roles")]
public class RoleEntity : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }
    public virtual ICollection<UserEntity> Users { get; set; }
        = new List<UserEntity>();
}