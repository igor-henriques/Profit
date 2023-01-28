namespace Profit.Domain.Commands.User.Create;

public sealed record CreateUserCommand : BaseCommand, IRequest<Guid>
{
    public UserDTO User { get; init; }
}