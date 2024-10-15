
using FluentValidation;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Validators;
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Matches(RegexPatterns.namePattern)
            .WithMessage("Invalid name format");

        RuleFor(p => p.UnitPrice)
            .NotEmpty()
            .WithMessage("Price is required")
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }
}