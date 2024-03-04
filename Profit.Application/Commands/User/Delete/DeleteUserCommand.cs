namespace Profit.Application.Commands.User.Delete;

public sealed class DeleteUserCommand : IRequest<Unit>
{
    public Guid UserId { get; init; }
}
