namespace Profit.Domain.Commands.User;

public sealed record CreateUserCommand : BaseCommand, IRequest<Guid>
{
    public UserDTO UserDTO { get; init; }
}
