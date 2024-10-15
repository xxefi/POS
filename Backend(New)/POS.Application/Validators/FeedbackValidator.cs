
using FluentValidation;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Validators;

public class FeedbackValidator : AbstractValidator<Feedback>
{
    public FeedbackValidator()
    {
        RuleFor(f => f.Comment)
            .NotEmpty()
            .WithMessage("Feedback is required")
            .Matches(RegexPatterns.descriptionPattern)
            .WithMessage("Invalid feedback format");
    }
}
