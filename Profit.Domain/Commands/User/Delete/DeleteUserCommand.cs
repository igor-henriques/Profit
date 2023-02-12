namespace Profit.Domain.Commands.User.Delete;

public sealed class DeleteUserCommand : IRequest<Unit>
{
    public Guid UserId { get; init; }
}
                                                      