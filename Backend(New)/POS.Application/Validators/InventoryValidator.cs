
using FluentValidation;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Validators;

public class InventoryValidator : AbstractValidator<Inventory>
{
    public InventoryValidator()
    {
        RuleFor(i => i.IngredientName)
            .NotEmpty()
            .WithMessage("Ingredient name is required")
            .Matches(RegexPatterns.namePattern)
            .WithMessage("Invalid ingredient name format");

        RuleFor(i => i.Quantity)
            .NotEmpty()
            .WithMessage("Quantity is required")
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero");
    }
}
