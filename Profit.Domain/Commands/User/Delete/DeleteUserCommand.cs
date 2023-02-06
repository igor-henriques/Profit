namespace Profit.Domain.Commands.User.Delete;

public sealed record DeleteUserCommand : BaseCommand, IRequest<Unit>
{
    public Guid UserId { get; init; }
}
