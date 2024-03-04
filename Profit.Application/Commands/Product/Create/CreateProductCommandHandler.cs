namespace Profit.Application.Commands.Product.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var ingredient = _mapper.Map<Domain.Entities.Product>(request);

        await _unitOfWork.ProductRepository.Add(ingredient, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return ingredient.Id;
    }
}
