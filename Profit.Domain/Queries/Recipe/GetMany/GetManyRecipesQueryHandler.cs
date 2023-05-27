namespace Profit.Domain.Queries.Recipe.GetMany;

public sealed class GetManyRecipesQueryHandler : IRequestHandler<GetManyRecipesQuery, IEnumerable<RecipeDto>>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public GetManyRecipesQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _recipeRepository = unitOfWork.RecipeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RecipeDto>> Handle(GetManyRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetManyAsync(cancellationToken);
        var recipesDto = recipes.Select(_mapper.Map<RecipeDto>);
        return recipesDto;
    }
}