using System.Security.Claims;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(User user);
    Task<string> GenerateRefreshTokenAsync();
    ClaimsPrincipal GetPrincipalFromToken(string token, bool validateTime = false);
}
