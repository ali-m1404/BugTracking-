using System.ComponentModel.DataAnnotations;

namespace BugTracker.Api.DTOs.Auth;

public sealed record LoginRequestDto
{
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; init; } = string.Empty;

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string Password { get; init; } = string.Empty;
}