
using FluentValidation;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email format");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
            .Matches(RegexPatterns.phonePattern)
            .WithMessage("Invalid phone number format");
    }
}
