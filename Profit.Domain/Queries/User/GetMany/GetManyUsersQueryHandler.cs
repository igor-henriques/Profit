namespace Profit.Domain.Queries.User.GetMany;

public sealed class GetManyUsersQueryHandler : IRequestHandler<GetManyUsersQuery, IEnumerable<UserDto>>
{
    private readonly IReadOnlyUserRepository _repo;
    private readonly IMapper _mapper;

    public GetManyUsersQueryHandler(
        IMapper mapper,
        IReadOnlyUserRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetManyUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repo.GetManyAsync(cancellationToken);
        var usersDto = users.Select(_mapper.Map<UserDto>);
        return usersDto;
    }
}