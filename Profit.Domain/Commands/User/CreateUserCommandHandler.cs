namespace Profit.Domain.Commands.User;

public sealed class CreateUserCommandHandler :
    BaseCommandHandler<CreateUserCommand>,
    IRequestHandler<CreateUserCommand, Guid>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly IValidator<CreateUserDTO> _validator;

    public CreateUserCommandHandler(ICommandBatchProcessorService<CreateUserCommand> commandBatchProcessor,
                                    IConfiguration configuration,
                                    IUnitOfWork unitOfWork,
                                    IMapper mapper,
                                    IPasswordHashingService passwordHashingService,
                                    IValidator<CreateUserDTO> validator) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHashingService = passwordHashingService;
        _validator = validator;
    }

    public async ValueTask DisposeAsync()
    {
        await base.ProcessBatchAsync();
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.UserDTO, cancellationToken);

        EnqueueCommandForStoraging(request);

        var user = _mapper.Map<Entities.User>(new CreateUserDTO
        {
            Email = request.UserDTO.Email,
            Password = _passwordHashingService.HashPassword(request.UserDTO.Password),
            Username = request.UserDTO.Username,
        });

        await _unitOfWork.UserRepository.Add(user, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        return user.Id;
    }
}
