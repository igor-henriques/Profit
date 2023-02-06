namespace Profit.Domain.Commands.Product.Delete;

public sealed class DeleteProductCommandHandler :
    BaseCommandHandler<DeleteProductCommand>,
    IRequestHandler<DeleteProductCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(
        IUnitOfWork unitOfWork,
        ICommandBatchProcessorService<DeleteProductCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask DisposeAsync()
    {
        await ProcessBatchAsync();
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        EnqueueCommandForStoraging(request);

        var product = await _unitOfWork.ProductRepository.GetUniqueAsync(request.ProductId, cancellationToken);
        _unitOfWork.ProductRepository.Delete(product);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.ProductId, nameof(Entities.Product));

        return Unit.Value;
    }
}
