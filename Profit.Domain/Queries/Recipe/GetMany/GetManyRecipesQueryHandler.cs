namespace Profit.Domain.Queries.Recipe.GetMany;

public sealed class GetManyRecipesQueryHandler : IRequestHandler<GetManyRecipesQuery, IEnumerable<RecipeDto>>
{
    private readonly IReadOnlyRecipeRepository _repo;
    private readonly IMapper _mapper;

    public GetManyRecipesQueryHandler(
        IMapper mapper,
        IReadOnlyRecipeRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<RecipeDto>> Handle(GetManyRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _repo.GetManyAsync(cancellationToken);
        var recipesDto = recipes.Select(_mapper.Map<RecipeDto>);
        return recipesDto;
    }
}