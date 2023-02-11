namespace Profit.Domain.Commands.Product.Create;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Name)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthName)
            .WithMessage(x => $"{nameof(x.Name)} maximum length is {Constants.FieldsDefinitions.MaxLengthName} characters");

        RuleFor(x => x.Description)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthDescriptions)
            .WithMessage(x => $"{nameof(x.Description)} maximum length is {Constants.FieldsDefinitions.MaxLengthDescriptions} characters");

        RuleFor(x => x.ImageThumbnailUrl)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthImageThumbnail)
            .WithMessage($"Maximum length is {Constants.FieldsDefinitions.MaxLengthImageThumbnail} characters");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0)
            .WithMessage(x => $"{nameof(x.TotalPrice)} must be greater than 0");

        RuleFor(x => x.RecipeId)
            .Must(id => !id.Equals(default))
            .WithMessage(x => $"{nameof(x.RecipeId)} is required");
    }
}