using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Exceptions;
using POS.Application.Validators;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;

namespace POS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly RegisterValidator _registerValidator;
    private readonly IUserService _userService;

    public UserController(RegisterValidator registerValidator, IUserService userService)
    {
        _registerValidator = registerValidator;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterEntity entity)
    {
        try
        {
            var validationResult = _registerValidator.Validate(entity);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var res = await _userService.CreateUserAsync(entity);
            return Ok(res);
        }
        catch (MyAuthException ex)
        {
            return BadRequest($"{ex.Message}\n{ex.AuthErrorType}");
        }
    }
}
