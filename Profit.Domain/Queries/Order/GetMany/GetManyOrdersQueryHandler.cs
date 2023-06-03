namespace Profit.Domain.Queries.Order.GetMany;

public sealed class GetManyOrdersQueryHandler : IRequestHandler<GetManyOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IReadOnlyIngredientRepository _repo;
    private readonly IMapper _mapper;

    public GetManyOrdersQueryHandler(
        IMapper mapper,
        IReadOnlyIngredientRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetManyOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repo.GetManyAsync(cancellationToken);
        var ordersDto = orders.Select(_mapper.Map<OrderDto>);
        return ordersDto;
    }
}
