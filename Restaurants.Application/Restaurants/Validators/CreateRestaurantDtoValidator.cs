using FluentValidation;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories =
    [
        "Italian", "Mexican", "Japanese", "Polish", "American", "Chinese", "Indian", "Greek", "French", "Spanish",
        "Thai", "Vietnamese", "Turkish", "Korean", "Lebanese"
    ];
    
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description cannot be empty.");

        RuleFor(dto => dto.Category)
            .Custom((value, context) =>
            {
                var isValidCategory = validCategories.Contains(value);

                if (!isValidCategory)
                {
                    context.AddFailure("Category"," Invalid category. Choose a valid one.");
                }
            });
        
        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address.");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Provide a valid postal code (XX-XXX).");
    }
}

