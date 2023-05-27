namespace Profit.Domain.Commands.User.Authenticate;

public sealed class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Username)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthUsername)
            .WithMessage(x => $"{nameof(x.Username)} maximum length is {Constants.FieldsDefinitions.MaxLengthUsername} characters");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Password)} is required")
            .Must(Helper.CheckForPasswordRequiredCharacters)
            .WithMessage(x => $"{nameof(x.Password)} must have at least one uppercase letter, one lowercase letter, one number and one special character")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthHashedPassword / 2)
            .WithMessage(x => $"{nameof(x.Password)} maximum length is {Constants.FieldsDefinitions.MaxLengthHashedPassword / 2} characters");
    }
}
