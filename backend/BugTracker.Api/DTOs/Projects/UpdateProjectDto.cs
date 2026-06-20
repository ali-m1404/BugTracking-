using System.ComponentModel.DataAnnotations;

namespace BugTracker.Api.DTOs.Projects;

public sealed record UpdateProjectDto
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    public bool IsArchived { get; set; }
}