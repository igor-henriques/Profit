using Microsoft.AspNetCore.Identity;
using Profit.Domain.Entities;

namespace Profit.Infrastructure.Service.Services;

public sealed class PasswordHashingService : IPasswordHashingService, IPasswordHasher<User>
{
    public string HashPassword(string password)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(password, nameof(password));

        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public string HashPassword(User _, string password)
    {
        return HashPassword(password);
    }

    public PasswordVerificationResult VerifyHashedPassword(User _, string hashedPassword, string providedPassword)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(hashedPassword, nameof(hashedPassword));
        ArgumentValidator.ThrowIfNullOrEmpty(providedPassword, nameof(providedPassword));

        var validationResult = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

        return validationResult ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    }
}
