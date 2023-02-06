namespace Profit.Domain.Commands.User.CreateMany;

public sealed record CreateManyUsersCommand : BaseCommand, IRequest<IEnumerable<Guid>>
{
    public IEnumerable<CreateUserDTO> Users { get; init; }
}
