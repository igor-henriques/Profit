namespace Profit.Domain.Queries.Product.GetPaginated;

public sealed class GetPaginatedProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, EntityQueryResultPaginated<ProductDto>>
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

    public async Task<EntityQueryResultPaginated<ProductDto>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
    {
        var paginatedResult = await _repo.GetPaginatedAsync(request, cancellationToken);
        var paginatedResponse = paginatedResult.MapToDto(paginatedResult.Data.Select(_mapper.Map<ProductDto>));
        return paginatedResponse;
    }
}