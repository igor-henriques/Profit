namespace Profit.Domain.Commands.Product.Patch;

public sealed class PatchProductCommandHandler : IRequestHandler<PatchProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatchProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(PatchProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Product));
        }

        product.Update(_mapper.Map<Entities.Product>(request));

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.Product));

        return Unit.Value;
    }
}
