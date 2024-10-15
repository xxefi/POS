using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Exceptions;
using POS.Application.Validators;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;

namespace POS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly LoginValidator _loginValidator;
    private readonly IAuthService _authService;

    public AuthController(LoginValidator loginValidator, IAuthService authService)
    {
        _loginValidator = loginValidator;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginEntity request)
    {
        try
        {
            var validationResult = _loginValidator.Validate(request);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var res = await _authService.LoginUserAsync(request);
            return Ok(res);
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync(TokenEntity token)
    {
        try
        {
            var newToken = await _authService.RefreshTokenAsync(token);
            if (newToken is null) return BadRequest("Invalid token");

            return Ok(newToken);
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }
    }
    [Authorize]
    [HttpPost("Logout")]
    public async Task<IActionResult> LogOutAsync(TokenEntity logout)
    {
        try
        {
            await _authService.LogOutAsync(logout);
            return Ok("Logged out successfully");
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }
    }
}