using BugTracker.Api.DTOs.Auth;

namespace BugTracker.Api.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequestDto request);

    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
}