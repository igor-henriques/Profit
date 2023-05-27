namespace Profit.Domain.Queries.User.GetUnique;

public readonly record struct GetUniqueUserQuery : IQuery<UserDto>
{
    public Guid Id { get; }

    public GetUniqueUserQuery(Guid id)
    {
        Id = id;
    }
}
