namespace Profit.Domain.Commands.User;

public sealed class CreateUserCommandHandler : 
    BaseCommandHandler<CreateUserCommand>, 
    IRequestHandler<CreateUserCommand, Guid>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHashingService _passwordHashingService;

    public CreateUserCommandHandler(ICommandBatchProcessorService<CreateUserCommand> commandBatchProcessor,
                                    IConfiguration configuration,
                                    IUnitOfWork unitOfWork,
                                    IMapper mapper,
                                    IPasswordHashingService passwordHashingService) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHashingService = passwordHashingService;
    }

    public async ValueTask DisposeAsync()
    {
        await base.ProcessBatchAsync();
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Entities.User>(new UserDTO
        { 
            Email = request.UserDTO.Email,
            HashedPassword = _passwordHashingService.HashPassword(request.UserDTO.HashedPassword),
            Username = request.UserDTO.Username,
        });
        
        await _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.SaveAsync(cancellationToken);
        return user.Guid;
    }
}
                  