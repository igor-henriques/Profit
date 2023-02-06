namespace Profit.Domain.Queries.User.GetUnique;

public readonly record struct GetUniqueUserQuery : IRequest<UserDTO>
{
    public Guid Id { get; }

    public GetUniqueUserQuery(Guid id)
    {
        Id = id;
    }
}
