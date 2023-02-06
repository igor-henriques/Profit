namespace Profit.Domain.Commands.User.Put;

public sealed record PutUserCommand : BaseCommand, IRequest<Unit>
{
    public UserDTO User { get; init; }
}
