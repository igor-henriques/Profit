namespace Profit.Domain.Entities;

public sealed record User : Entity<User>, IEntity
{
    public Guid TenantId { get; init; } = Guid.NewGuid();
    public string Username { get; private set; }
    public string HashedPassword { get; private set; }
    public string Email { get; private set; }
    public bool IsEmailVerified { get; private set; }

    public User(Guid tenantId, string username, string hashedPassword, string email, bool isEmailVerified)
    {
        TenantId = tenantId;
        Username = username;
        HashedPassword = hashedPassword;
        Email = email;
        IsEmailVerified = isEmailVerified;

        Validate();
    }

    public User() { }

    public ICollection<UserClaim> UserClaims { get; } = new List<UserClaim>();

    public override User Update(User entity)
    {
        UpdateUsername(entity.Username);
        UpdateEmail(entity.Email);
        UpdateIsEmailVerified(entity.IsEmailVerified);
        UpdateHashedPassword(entity.HashedPassword);

        return this;
    }

    public override void Validate()
    {
        ArgumentValidator.ThrowIfNullOrEmpty(Username, nameof(Username));
        ArgumentValidator.ThrowIfNullOrEmpty(Email, nameof(Email));
        ArgumentValidator.ThrowIfNullOrEmpty(HashedPassword, nameof(HashedPassword));
    }

    public User UpdateUsername(string username)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(username, nameof(username));

        if (Username != username)
        {
            this.Username = username;
        }

        return this;
    }

    public User UpdateEmail(string email)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(email, nameof(email));

        if (Email != email)
        {
            this.Email = email;
        }

        return this;
    }

    public User UpdateHashedPassword(string hashedPassword)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(hashedPassword, nameof(hashedPassword));

        if (HashedPassword != hashedPassword)
        {
            this.HashedPassword = hashedPassword;
        }

        return this;
    }

    public User UpdateIsEmailVerified(bool isEmailVerified)
    {
        if (IsEmailVerified != isEmailVerified)
        {
            this.IsEmailVerified = isEmailVerified;
        }

        return this;
    }
}
