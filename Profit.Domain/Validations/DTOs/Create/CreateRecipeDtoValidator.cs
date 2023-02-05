﻿namespace Profit.Domain.Validations.DTOs.Create;

public sealed class CreateRecipeDtoValidator : AbstractValidator<CreateRecipeDTO>
{
    public CreateRecipeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Name)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthName)
            .WithMessage(x => $"{x.Name} maximum length is {Constants.FieldsDefinitions.MaxLengthName} characters");

        RuleFor(x => x.Description)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthDescriptions)
            .WithMessage(x => $"{x.Description} maximum length is {Constants.FieldsDefinitions.MaxLengthDescriptions} characters");

        RuleFor(x => x.TotalCost)
            .GreaterThan(0)
            .WithMessage(x => $"{nameof(x.TotalCost)} must be greater than 0");
        
        RuleFor(x => x.IngredientRecipeRelations)
            .NotNull()
            .Must(collection => collection?.Count > 0)
            .WithMessage(x => $"{nameof(x.IngredientRecipeRelations)} is required");
    }
}
