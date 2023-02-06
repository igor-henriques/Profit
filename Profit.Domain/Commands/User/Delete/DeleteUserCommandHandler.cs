namespace Profit.Domain.Commands.Recipe.Delete;

public sealed class DeleteUserCommandHandler :
    BaseCommandHandler<DeleteUserCommand>,
    IRequestHandler<DeleteUserCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(
        IUnitOfWork unitOfWork,
        ICommandBatchProcessorService<DeleteUserCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask DisposeAsync()
    {
        await ProcessBatchAsync();
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        EnqueueCommandForStoraging(request);

        var user = await _unitOfWork.UserRepository.GetUniqueAsync(request.UserId, cancellationToken);
        _unitOfWork.UserRepository.Delete(user);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.UserId, nameof(Entities.User));

        return Unit.Value;
    }
}
