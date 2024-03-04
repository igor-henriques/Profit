namespace Profit.Application.Queries.Ingredient.GetPaginated;

public sealed class GetPaginatedIngredientsQueryHandler : IRequestHandler<GetPaginatedIngredientsQuery, EntityQueryResultPaginated<IngredientDto>>
{
    private readonly IReadOnlyIngredientRepository _repo;
    private readonly IMapper _mapper;

    public GetPaginatedIngredientsQueryHandler(
        IMapper mapper,
        IReadOnlyIngredientRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<EntityQueryResultPaginated<IngredientDto>> Handle(GetPaginatedIngredientsQuery request, CancellationToken cancellationToken)
    {
        var paginatedResult = await _repo.GetPaginatedAsync(request, cancellationToken);
        var paginatedResponse = paginatedResult.MapToDto(paginatedResult.Data.Select(_mapper.Map<IngredientDto>));
        return paginatedResponse;
    }
}
