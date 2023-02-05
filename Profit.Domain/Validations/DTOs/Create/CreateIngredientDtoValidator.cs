namespace Profit.Domain.Validations.DTOs.Create;

public sealed class CreateIngredientDtoValidator : AbstractValidator<CreateIngredientDTO>
{
    public CreateIngredientDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Name)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthName)
            .WithMessage(x => $"{x.Name} maximum length is {Constants.FieldsDefinitions.MaxLengthName} characters");
        
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage(x => $"{nameof(x.Price)} must be greater than 0");
        
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage(x => $"{nameof(x.Quantity)} must be greater than 0");
        
        RuleFor(x => x.ImageThumbnailUrl)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthImageThumbnail)
            .WithMessage(x => $"{x.ImageThumbnailUrl} maximum length is {Constants.FieldsDefinitions.MaxLengthImageThumbnail} characters");

        RuleFor(x => x.Description)
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthDescriptions)
            .WithMessage(x => $"{x.Description} maximum length is {Constants.FieldsDefinitions.MaxLengthDescriptions} characters");
    }
}