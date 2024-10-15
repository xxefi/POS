using FluentValidation;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Matches(RegexPatterns.namePattern)
            .When(c => c.Name != null)
            .WithMessage("Invalid name format");
        
        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .Matches(RegexPatterns.descriptionPattern)
            .When(c => c.Description != null)
            .WithMessage("Invalid description format");
    }
}