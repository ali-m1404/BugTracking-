using BugTracker.Api.Data;
using BugTracker.Api.DTOs.Auth;
using BugTracker.Api.Entities;
using BugTracker.Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    private readonly PasswordHasher<UserEntity> _passwordHasher;

    public AuthService(
        AppDbContext context,
        TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
        _passwordHasher = new PasswordHasher<UserEntity>();
    }

    public async Task RegisterAsync(RegisterRequestDto request)
    {
        bool emailExists = await _context.Users
            .AnyAsync(u => u.Email == request.Email);

        if (emailExists)
        {
            throw new Exception("Email already exists.");
        }

        UserEntity user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            RoleId = request.RoleId,
            IsActive = true
        };

        user.PasswordHash = _passwordHasher
            .HashPassword(user, request.Password);

        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        UserEntity? user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return null;
        }

        if (!user.IsActive)
        {
            throw new Exception("User account is inactive.");
        }

        PasswordVerificationResult result =
            _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        string token = _tokenService.GenerateToken(user);

        return new LoginResponseDto
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(60)
        };
    }
}