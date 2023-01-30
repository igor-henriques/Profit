namespace Profit.Infrastructure.Service.Services;

public sealed class PasswordHashingService : IPasswordHashingService
{
    public string HashPassword(string password)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(password);

        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
}
