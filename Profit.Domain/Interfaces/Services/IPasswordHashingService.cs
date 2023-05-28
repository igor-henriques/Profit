namespace Profit.Domain.Interfaces.Services;

public interface IPasswordHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string providedPassword, string hashedPassword);
}