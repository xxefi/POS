using POS.Domain.Enums;

namespace POS.API.Contracts.Register;

public record RegisterResponse(
    Guid UserId,
    string Username,
    string Email,
    UserRole Role);