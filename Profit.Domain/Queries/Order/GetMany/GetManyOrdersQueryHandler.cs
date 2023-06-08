namespace Profit.Domain.Queries.Order.GetPaginated;

public sealed class GetPaginatedOrdersQueryHandler : IRequestHandler<GetPaginatedOrdersQuery, IEnumerable<OrderDto>>
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

    public async Task<IEnumerable<OrderDto>> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repo.GetPaginatedAsync(cancellationToken);
        var ordersDto = orders.Select(_mapper.Map<OrderDto>);
        return ordersDto;
    }
}
