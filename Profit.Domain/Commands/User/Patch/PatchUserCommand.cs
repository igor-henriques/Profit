namespace Profit.Domain.Commands.User.Patch;

public sealed record PatchUserCommand : BaseCommand, IRequest<Unit>
{
    public UserDTO User { get; init; }
}
