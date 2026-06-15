using System.ComponentModel.DataAnnotations;

namespace BugTracker.Api.DTOs.Auth;

public sealed record RegisterRequestDto
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; init; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; init; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 8)]
    [RegularExpression(
    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
    ErrorMessage = "Password must contain uppercase, lowercase and number.")]
    public string Password { get; init; } = string.Empty;

    [Required]
    public Guid RoleId { get; init; }
}