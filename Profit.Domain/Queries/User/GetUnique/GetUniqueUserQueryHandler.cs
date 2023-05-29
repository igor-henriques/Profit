namespace Profit.Domain.Queries.User.GetUnique;

public sealed class GetUniqueUserQueryHandler : IRequestHandler<GetUniqueUserQuery, UserDto>
{
    private readonly IReadOnlyUserRepository _repo;
    private readonly IMapper _mapper;

    public GetUniqueUserQueryHandler(
        IMapper mapper,
        IReadOnlyUserRepository repo)
    {        
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<UserDto> Handle(GetUniqueUserQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var user = await _repo.GetUniqueAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(request.Id, nameof(Entities.User));

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}
