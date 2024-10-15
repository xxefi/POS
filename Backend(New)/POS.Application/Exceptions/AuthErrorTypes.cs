
namespace POS.Application.Exceptions;

public enum AuthErrorTypes
{
    InvalidToken,
    InvalidRefreshToken,
    InvalidCredentials,
    UserNotFound,
    NullCredentials,
    InvalidRequest,
    PasswordMismatch,
    EmailAlreadyConfirmed,
    EmailNotConfirmed,
    EmailAlreadyExists,
    CredentialsAlreadyExists,
    NotFound,
}
