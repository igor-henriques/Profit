namespace Profit.Application.Commands.User.Create;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHashingService _passwordHashingService;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork,
                                    IMapper mapper,
                                    IPasswordHashingService passwordHashingService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHashingService = passwordHashingService;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);

        user.UpdateHashedPassword(_passwordHashingService.HashPassword(request.Password));

        await _unitOfWork.UserRepository.Add(user, cancellationToken);

        if (await _unitOfWork.Commit(cancellationToken) > 0)
        {
            await _unitOfWork.CreateSchema(user.TenantId, cancellationToken);
        }

        return user.Id;
    }
}
