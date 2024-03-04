namespace Profit.Application.Queries.Order.GetUnique;

public sealed class GetUniqueOrderQueryHandler : IRequestHandler<GetUniqueOrderQuery, OrderDto>
{
    private readonly IReadOnlyIngredientRepository _repo;
    private readonly IMapper _mapper;

    public GetUniqueOrderQueryHandler(
        IMapper mapper,
        IReadOnlyIngredientRepository ingredientRepository)
    {
        _mapper = mapper;
        _repo = ingredientRepository;
    }

    public async Task<OrderDto> Handle(GetUniqueOrderQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Guid);

        var order = await _repo.GetUniqueAsync(request.Guid, cancellationToken)
            ?? throw new EntityNotFoundException(request.Guid, nameof(Domain.Entities.Ingredient));

        var orderDto = _mapper.Map<OrderDto>(order);
        return orderDto;
    }
}
