using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IAuthService
{
    Task<AccessInfoEntity> LoginUserAsync(LoginEntity user);
    Task<AccessInfoEntity> RefreshTokenAsync(TokenEntity token);
    Task LogOutAsync(TokenEntity userTokenInfo);
}
