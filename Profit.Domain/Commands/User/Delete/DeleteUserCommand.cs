namespace Profit.Domain.Commands.User.Delete;

public sealed record DeleteUserCommand : IRequest<Unit>
{
    public Guid UserId { get; init; }
}
