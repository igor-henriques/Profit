namespace Profit.Domain.Queries.User.GetPaginated;

public sealed class GetPaginatedUsersQueryHandler : IRequestHandler<GetPaginatedUsersQuery, IEnumerable<UserDto>>
{
    private readonly IReadOnlyUserRepository _repo;
    private readonly IMapper _mapper;

    public GetPaginatedUsersQueryHandler(
        IMapper mapper,
        IReadOnlyUserRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repo.GetPaginatedAsync(cancellationToken);
        var usersDto = users.Select(_mapper.Map<UserDto>);
        return usersDto;
    }
}