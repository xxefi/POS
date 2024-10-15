using POS.Domain.Enums;

namespace POS.API.Contracts.User;

public record UserRequest(
    string Username,
    string Email,
    string Phone,
    string Password,
    UserRole Role);