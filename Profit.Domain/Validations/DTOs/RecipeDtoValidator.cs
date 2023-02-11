namespace Profit.Domain.Validations.DTOs;

public sealed class RecipeDtoValidator : AbstractValidator<RecipeDTO>
{
    public RecipeDtoValidator()
    {
        RuleFor(x => x.Id)
            .Must(x => !x.Equals(default))
            .WithMessage(x => $"{nameof(x.Id)} is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Name)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthName)
            .WithMessage(x => $"{nameof(x.Name)} maximum length is {Constants.FieldsDefinitions.MaxLengthName} characters");

        RuleFor(x => x.Description)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthDescriptions)
            .WithMessage(x => $"{nameof(x.Description)} maximum length is {Constants.FieldsDefinitions.MaxLengthDescriptions} characters");

        RuleFor(x => x.TotalCost)
            .GreaterThan(0)
            .WithMessage(x => $"{nameof(x.TotalCost)} must be greater than 0");

        RuleFor(x => x.IngredientRecipeRelations)
            .NotNull()
            .Must(collection => collection?.Count > 0)
            .WithMessage(x => $"{nameof(x.IngredientRecipeRelations)} is required");
    }
}