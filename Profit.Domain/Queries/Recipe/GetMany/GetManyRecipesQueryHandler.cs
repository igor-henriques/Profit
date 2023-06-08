namespace Profit.Domain.Queries.Recipe.GetPaginated;

public sealed class GetPaginatedRecipesQueryHandler : IRequestHandler<GetPaginatedRecipesQuery, IEnumerable<RecipeDto>>
{
    private readonly IReadOnlyRecipeRepository _repo;
    private readonly IMapper _mapper;

    public GetPaginatedRecipesQueryHandler(
        IMapper mapper,
        IReadOnlyRecipeRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<IEnumerable<RecipeDto>> Handle(GetPaginatedRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _repo.GetPaginatedAsync(cancellationToken);
        var recipesDto = recipes.Select(_mapper.Map<RecipeDto>);
        return recipesDto;
    }
}