namespace Profit.Domain.Queries.Product.GetMany;

public sealed class GetManyProductsQueryHandler : IRequestHandler<GetManyProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IReadOnlyProductRepository _repo;
    private readonly IMapper _mapper;

    public GetManyProductsQueryHandler(
        IMapper mapper,
        IReadOnlyProductRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetManyProductsQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await _repo.GetManyAsync(cancellationToken);
        var ingredientDto = ingredient.Select(_mapper.Map<ProductDto>);
        return ingredientDto;
    }
}