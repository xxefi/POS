using FluentValidation;
using POS.Domain.Entities;

namespace POS.Application.Validators;

public class LoginValidator : AbstractValidator<LoginEntity>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .When(x => x.Email != null);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Matches(RegexPatterns.passwordPattern)
            .When(x => x.Password != null);
    }
}
