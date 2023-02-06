namespace Profit.Domain.Commands.User.Put;

public sealed class PutUserCommandHandler :
    BaseCommandHandler<PutUserCommand>,
    IRequestHandler<PutUserCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UserDTO> _validator;

    public PutUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<UserDTO> validator,
        ICommandBatchProcessorService<PutUserCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async ValueTask DisposeAsync()
    {
        await ProcessBatchAsync();
    }

    public async Task<Unit> Handle(PutUserCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.User, cancellationToken);
        EnqueueCommandForStoraging(request);
        var user = _mapper.Map<Entities.User>(request.User);
        _unitOfWork.UserRepository.Update(user);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.User.Id, nameof(Entities.User));

        return Unit.Value;
    }
}
