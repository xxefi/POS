using POS.Domain.Enums;

namespace POS.API.Contracts.Register;

public record RegisterRequest(
    string Username,
    string Email,
    string Phone,
    string Password,
    string ConfirmPassword,
    UserRole Role);