using BugTracker.Api.Configurations;
using BugTracker.Api.Data;
using BugTracker.Api.Interfaces;
using BugTracker.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var jwtSettings = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtSettings>()!;



builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
    });

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();