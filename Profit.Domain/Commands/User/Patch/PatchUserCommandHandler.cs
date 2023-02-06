namespace Profit.Domain.Commands.User.Patch;

public sealed class PatchUserCommandHandler :
    BaseCommandHandler<PatchUserCommand>,
    IRequestHandler<PatchUserCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UserDTO> _validator;

    public PatchUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<UserDTO> validator,
        ICommandBatchProcessorService<PatchUserCommand> commandBatchProcessor,
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

    public async Task<Unit> Handle(PatchUserCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.User, cancellationToken);
        EnqueueCommandForStoraging(request);

        var user = await _unitOfWork.UserRepository.GetUniqueAsync(request.User.Id, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException(request.User.Id, nameof(Entities.User));
        }

        user.Update(_mapper.Map<Entities.User>(request.User));

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.User.Id, nameof(Entities.User));

        return Unit.Value;
    }
}
