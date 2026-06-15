namespace BugTracker.Api.DTOs.Auth;

public sealed record LoginResponseDto
{
    public string Token { get; init; } = string.Empty;

    public DateTime Expiration { get; init; }

    public string TokenType { get; init; } = "Bearer";
}