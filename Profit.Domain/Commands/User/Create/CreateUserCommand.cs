namespace Profit.Domain.Commands.User.Create;

public sealed record CreateUserCommand : BaseCommand, IRequest<Guid>
{
    public CreateUserDTO UserDTO { get; init; }
}
