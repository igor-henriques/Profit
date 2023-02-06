namespace Profit.Domain.Validations.DTOs;

public sealed class ProductDtoValidator : AbstractValidator<ProductDTO>
{
    public ProductDtoValidator()
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
            .WithMessage(x => $"{x.Description} maximum length is {Constants.FieldsDefinitions.MaxLengthDescriptions} characters");

        RuleFor(x => x.ImageThumbnailUrl)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthImageThumbnail)
            .WithMessage($"Maximum length is {Constants.FieldsDefinitions.MaxLengthImageThumbnail} characters");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0)
            .WithMessage(x => $"{nameof(x.TotalPrice)} must be greater than 0");

        RuleFor(x => x.RecipeId)
            .Must(id => !id.Equals(default(Guid)))
            .WithMessage(x => $"{nameof(x.RecipeId)} is required");
    }
}
