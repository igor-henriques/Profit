namespace Profit.Domain.Queries.Product.GetPaginated;

public sealed class GetPaginatedProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IReadOnlyProductRepository _repo;
    private readonly IMapper _mapper;

    public GetPaginatedProductsQueryHandler(
        IMapper mapper,
        IReadOnlyProductRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await _repo.GetPaginatedAsync(cancellationToken);
        var ingredientDto = ingredient.Select(_mapper.Map<ProductDto>);
        return ingredientDto;
    }
}