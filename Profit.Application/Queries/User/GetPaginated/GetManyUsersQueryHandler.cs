namespace Profit.Application.Queries.User.GetPaginated;

public sealed class GetPaginatedUsersQueryHandler : IRequestHandler<GetPaginatedUsersQuery, EntityQueryResultPaginated<UserDto>>
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

    public async Task<EntityQueryResultPaginated<UserDto>> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
    {
        var paginatedResult = await _repo.GetPaginatedAsync(request, cancellationToken);
        var paginatedResponse = paginatedResult.MapToDto(paginatedResult.Data.Select(_mapper.Map<UserDto>));
        return paginatedResponse;
    }
}