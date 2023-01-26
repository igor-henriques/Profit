namespace Profit.Domain.Validations.Entities;

public sealed class IngredientValidator : AbstractValidator<Ingredient>
{
    public IngredientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(x => $"{nameof(x.Name)} is required").MaximumLength(100).WithMessage("Maximum length is 100 characters");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage(x => $"{nameof(x.Price)} must be greater than 0");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(x => $"{nameof(x.Quantity)} must be greater than 0");
        RuleFor(x => x.ImageThumbnailUrl).NotEmpty().WithMessage(x => $"{nameof(x.ImageThumbnailUrl)} is required").MaximumLength(500).WithMessage("Maximum length is 500 characters");
    }
}
