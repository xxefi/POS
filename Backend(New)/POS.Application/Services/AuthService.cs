using System.Security.Claims;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;
using static BCrypt.Net.BCrypt;

namespace POS.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IBlackListService _blackListService;
    private readonly IUserService _userService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService, IBlackListService blackListService, IUserService userService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _blackListService = blackListService;
        _userService = userService;
    }
    public async Task<AccessInfoEntity> LoginUserAsync(LoginEntity user)
    {
        var foundUser = await _userRepository.GetByEmailAsync(user.Email)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "User not found");
        if (Verify(user.Password, foundUser.Password))
        {
            var tokenData = new AccessInfoEntity
            {
                AccessToken = await _tokenService.GenerateTokenAsync(foundUser),
                RefreshToken = await _tokenService.GenerateRefreshTokenAsync(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1)
            };
            foundUser.RefreshToken = tokenData.RefreshToken;
            foundUser.RefreshTokenExpiryTime = tokenData.RefreshTokenExpiryTime;
            
            await _userRepository.Update(foundUser);
            return tokenData;
        }
        else
            throw new MyAuthException(AuthErrorTypes.InvalidCredentials, "Invalid credentials");
    }

    public async Task<AccessInfoEntity> RefreshTokenAsync(TokenEntity token)
    {
        if (token is null)
            throw new Exception("Invalid Client Request");

        var accessToken = token.AccessToken;
        var refreshToken = token.RefreshToken;

        var principal = _tokenService.GetPrincipalFromToken(accessToken);

        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new Exception("Invalid Client Request");

        var newAccessToken = await _tokenService.GenerateTokenAsync(user);
        var newRefreshToken = await _tokenService.GenerateRefreshTokenAsync();

        user.RefreshToken = newAccessToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1);

        await _userRepository.Update(user);

        return new AccessInfoEntity
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            RefreshTokenExpiryTime = user.RefreshTokenExpiryTime,
        };
    }

    public async Task LogOutAsync(TokenEntity userTokenInfo)
    {
        if (userTokenInfo is null)
            throw new MyAuthException(AuthErrorTypes.InvalidRequest, "Invalid Client Request");

        var principal = _tokenService.GetPrincipalFromToken(userTokenInfo.AccessToken);
        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        var user = await _userRepository.GetByEmailAsync(email);

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = DateTime.UtcNow;

        _blackListService.AddTokenToBlackList(userTokenInfo.AccessToken);
        await _userRepository.Update(user);
    }
}