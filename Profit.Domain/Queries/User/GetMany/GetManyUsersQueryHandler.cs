namespace Profit.Domain.Queries.User.GetMany;

public sealed class GetManyUsersQueryHandler : IRequestHandler<GetManyUsersQuery, IEnumerable<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetManyUsersQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userRepository = unitOfWork.UserRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetManyUsersQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _userRepository.GetManyAsync(cancellationToken);
        var recipesDto = recipes.Select(_mapper.Map<UserDTO>);
        return recipesDto;
    }
}