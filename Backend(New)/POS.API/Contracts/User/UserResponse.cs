using POS.Domain.Enums;

namespace POS.API.Contracts.User;

public record UserResponse(
    Guid Id,
    string Username,
    string Email,
    string Phone,
    string Password,
    UserRole Role);