﻿namespace Profit.Domain.Validations.DTOs;

public sealed class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.Id)
            .Must(x => !x.Equals(default))
            .WithMessage(x => $"{nameof(x.Id)} is required");

        RuleFor(x => x.TenantId)
            .Must(x => !x.Equals(default))
            .WithMessage(x => $"{nameof(x.TenantId)} is required");

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Username)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthUsername)
            .WithMessage(x => $"{nameof(x.Username)} maximum length is {Constants.FieldsDefinitions.MaxLengthUsername} characters");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(x => $"{nameof(x.Email)} is required")
            .MaximumLength(Constants.FieldsDefinitions.MaxLengthEmail)
            .WithMessage(x => $"{nameof(x.Email)} maximum length is {Constants.FieldsDefinitions.MaxLengthEmail} characters");
    }
}
