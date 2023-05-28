namespace Profit.Domain.Queries.Ingredient.GetMany;

public sealed class GetManyIngredientsQueryHandler : IRequestHandler<GetManyIngredientsQuery, IEnumerable<IngredientDto>>
{
    private readonly IReadOnlyBaseRepository<Entities.Ingredient> _repo;
    private readonly IMapper _mapper;

    public GetManyIngredientsQueryHandler(
        IMapper mapper, 
        IReadOnlyBaseRepository<Entities.Ingredient> repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<IngredientDto>> Handle(GetManyIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await _repo.GetManyAsync(cancellationToken);
        var ingredientsDto = ingredients.Select(_mapper.Map<IngredientDto>);
        return ingredientsDto;
    }
}
