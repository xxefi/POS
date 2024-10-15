using FluentValidation;
using POS.Domain.Models;

namespace POS.Application.Validators;

public class TransactionValidator : AbstractValidator<Transaction>
{
    public TransactionValidator()
    {
        RuleFor(t => t.Amount)
            .NotEmpty()
            .WithMessage("Amount is required")
            .GreaterThan(0)
            .WithMessage("Amount must be greater than zero");

        RuleFor(t => t.Description)
           .NotEmpty()
           .WithMessage("Description is required")
           .Matches(RegexPatterns.descriptionPattern)
           .When(t => t.Description != null)
           .WithMessage("Invalid description format");
    }
}