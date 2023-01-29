namespace Profit.Domain.Commands.User.Create;

public sealed class CreateUserCommandHandler :
    BaseCommandHandler<CreateUserCommand>,
    IRequestHandler<CreateUserCommand, Guid>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ICommandBatchProcessorService<CreateUserCommand> commandBatchProcessor) : base(commandBatchProcessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask DisposeAsync()
    {
        await base.ProcessBatchAsync();
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        base.EnqueueCommandForStoraging(request);
        var user = _mapper.Map<Entities.User>(request.User);
        await _unitOfWork.UserRepository.Add(user, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return user.Guid;
    }
}
