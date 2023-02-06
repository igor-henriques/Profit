namespace Profit.Domain.Queries.User.GetUnique;

public sealed class GetUniqueUserQueryHandler : IRequestHandler<GetUniqueUserQuery, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IRedisCacheService _cache;

    public GetUniqueUserQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IRedisCacheService cache)
    {
        _cache = cache;
        _userRepository = unitOfWork.UserRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(GetUniqueUserQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var recipe = await _userRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (recipe is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.User));
        }

        var recipeDto = _mapper.Map<UserDTO>(recipe);
        return recipeDto;
    }
}
