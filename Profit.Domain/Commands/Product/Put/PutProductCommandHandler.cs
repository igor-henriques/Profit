namespace Profit.Domain.Commands.Product.Put;

public sealed class PutProductCommandHandler : IRequestHandler<PutProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PutProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Entities.Product>(request);
        _unitOfWork.ProductRepository.Update(product);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.Product));

        return Unit.Value;
    }
}
