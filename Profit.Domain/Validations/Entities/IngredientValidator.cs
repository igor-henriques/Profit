namespace Profit.Domain.Validations.Entities;

public sealed class IngredientValidator : AbstractValidator<Ingredient>
{
    public IngredientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(x => $"{nameof(x.Name)} is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage(x => $"{nameof(x.Price)} must be greater than 0");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(x => $"{nameof(x.Quantity)} must be greater than 0");
        RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage(x => $"{nameof(x.TotalPrice)} must be greater than 0");
        RuleFor(x => x.ImageThumbnailUrl).NotEmpty().WithMessage(x => $"{nameof(x.ImageThumbnailUrl)} is required");
    }
    
    public static void ValidateName(string name)
    {
        var result = !string.IsNullOrWhiteSpace(name);
        
        if (result is false)
            throw new ValidationException($"{nameof(name)} is required");
    }
    public static void ValidatePrice(decimal price)
    {
        var result = price > 0;
        
        if (result is false)
            throw new ValidationException($"{nameof(price)} must be greater than 0");
    }
    public static void ValidateQuantity(decimal quantity)
    {
        var result = quantity > 0;

        if (result is false)
            throw new ValidationException($"{nameof(quantity)} must be greater than 0");
    }
    public static void ValidateTotalPrice(decimal totalPrice)
    {
        var result =  totalPrice > 0;

        if (result is false)
            throw new ValidationException($"{nameof(totalPrice)} must be greater than 0");
    }
    public static void ValidateImageThumbnailUrl(string imageThumbnailUrl)
    {
        var result = !string.IsNullOrWhiteSpace(imageThumbnailUrl);

        if (result is false)
            throw new ValidationException($"{nameof(imageThumbnailUrl)} is required");
    }
}
