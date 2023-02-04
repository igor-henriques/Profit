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
        await base.ProcessBatchAsync();
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        base.EnqueueCommandForStoraging(request);

        var ingredient = await _unitOfWork.ProductRepository.GetUniqueAsync(request.ProductId, cancellationToken);
        _unitOfWork.ProductRepository.Delete(ingredient);

        if (await _unitOfWork.SaveAsync(cancellationToken) is 0)
            throw new EntityNotFoundException(request.ProductId, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
