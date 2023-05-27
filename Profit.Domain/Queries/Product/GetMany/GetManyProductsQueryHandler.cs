namespace Profit.Domain.Queries.Product.GetMany;

public sealed class GetManyProductsQueryHandler : IRequestHandler<GetManyProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetManyProductsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _productRepository = unitOfWork.ProductRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetManyProductsQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await _productRepository.GetManyAsync(cancellationToken);
        var ingredientDto = ingredient.Select(_mapper.Map<ProductDto>);
        return ingredientDto;
    }
}