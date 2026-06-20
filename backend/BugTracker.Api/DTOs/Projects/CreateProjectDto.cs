using System.ComponentModel.DataAnnotations;

namespace BugTracker.Api.DTOs.Projects;

public sealed record CreateProjectDto
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    public Guid ManagerId { get; set; }
}