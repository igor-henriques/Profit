namespace Profit.Domain.Commands.Product.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadOnlyProductRepository _readOnlyRepo;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IReadOnlyProductRepository readOnlyRepo)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _readOnlyRepo = readOnlyRepo;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var ingredient = _mapper.Map<Entities.Product>(request);

        _ = await _readOnlyRepo.GetUniqueAsync(request.RecipeId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Recipe));

        await _unitOfWork.ProductRepository.Add(ingredient, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return ingredient.Id;
    }
}
