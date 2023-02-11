namespace Profit.Domain.Commands.Product.CreateMany;

public sealed class CreateManyProductsCommandHandler : IRequestHandler<CreateManyProductsCommand, IEnumerable<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateManyProductsCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Guid>> Handle(CreateManyProductsCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();
        var errors = new List<string>();

        foreach (var productDto in request.Products)
        {
            var ingredientEntity = _mapper.Map<Entities.Product>(productDto);
            await _unitOfWork.ProductRepository.Add(ingredientEntity, cancellationToken);
            response.Add(ingredientEntity.Id);
        }

        if (errors.Any())
        {
            throw new ValidationException(string.Join("\n", errors));
        }

        await _unitOfWork.Commit(cancellationToken);
        return response;
    }
}
