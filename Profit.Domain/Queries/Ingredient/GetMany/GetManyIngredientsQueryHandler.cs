namespace Profit.Domain.Queries.Ingredient.GetPaginated;

public sealed class GetPaginatedIngredientsQueryHandler : IRequestHandler<GetPaginatedIngredientsQuery, IEnumerable<IngredientDto>>
{                                    ]
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
        var paginatedResult = await _repo.GetPaginatedAsync(0, 0, cancellationToken);
        var ingredientsDto = ingredients.Select(_mapper.Map<IngredientDto>);
        return ingredientsDto;
    }
}
