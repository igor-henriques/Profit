namespace Profit.Domain.Queries.Order.GetPaginated;

public sealed class GetPaginatedOrdersQueryHandler : IRequestHandler<GetPaginatedOrdersQuery, EntityQueryResultPaginated<OrderDto>>
{
    private readonly IReadOnlyIngredientRepository _repo;
    private readonly IMapper _mapper;

    public GetPaginatedOrdersQueryHandler(
        IMapper mapper,
        IReadOnlyIngredientRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<EntityQueryResultPaginated<OrderDto>> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
    {
        var paginatedResult = await _repo.GetPaginatedAsync(request, cancellationToken);
        var paginatedResponse = paginatedResult.TransformToDto(paginatedResult.Data.Select(_mapper.Map<OrderDto>));
        return paginatedResponse;
    }
}
