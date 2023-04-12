namespace Profit.Domain.Queries.User.GetUnique;

public sealed class GetUniqueUserQueryHandler : IRequestHandler<GetUniqueUserQuery, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUniqueUserQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userRepository = unitOfWork.UserRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(GetUniqueUserQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var user = await _userRepository.GetUniqueAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(request.Id, nameof(Entities.User));

        var userDto = _mapper.Map<UserDTO>(user);
        return userDto;
    }
}
