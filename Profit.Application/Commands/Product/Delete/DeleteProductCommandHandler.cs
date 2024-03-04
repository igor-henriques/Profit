namespace Profit.Application.Commands.Product.Delete;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.ProductId, nameof(request.ProductId));

        var product = await _unitOfWork.ProductRepository.GetUniqueAsync(request.ProductId, cancellationToken);
        _unitOfWork.ProductRepository.Delete(product);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.ProductId, nameof(Domain.Entities.Product));

        return Unit.Value;
    }
}
