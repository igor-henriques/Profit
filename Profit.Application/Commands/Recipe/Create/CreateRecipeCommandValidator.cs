namespace Profit.Application.Commands.Recipe.Create;

public sealed class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Name)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthName)
            .WithMessage(x => $"{nameof(x.Name)} maximum length is {Constants.FieldsDefinitions.MaxLengthName} characters");

        RuleFor(x => x.Description)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthDescriptions)
            .WithMessage(x => $"{nameof(x.Description)} maximum length is {Constants.FieldsDefinitions.MaxLengthDescriptions} characters");

        RuleFor(x => x.IngredientRecipeRelations)
            .NotNull()
            .Must(collection => collection?.Count > 0)
            .WithMessage(x => $"{nameof(x.IngredientRecipeRelations)} is required");
    }
}
