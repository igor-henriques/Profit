namespace Profit.Domain.Commands.User.Create;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Entities.User>(request.User);
        await _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.SaveAsync(cancellationToken);

        return user.Guid;
    }
}
