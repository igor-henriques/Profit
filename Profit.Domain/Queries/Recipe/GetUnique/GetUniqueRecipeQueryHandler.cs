namespace Profit.Domain.Queries.Recipe.GetUnique;

public sealed class GetUniqueRecipeQueryHandler : IRequestHandler<GetUniqueRecipeQuery, RecipeDTO>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;
    private readonly IRedisCacheService _cache;

    public GetUniqueRecipeQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IRedisCacheService cache)
    {
        _cache = cache;
        _recipeRepository = unitOfWork.RecipeRepository;
        _mapper = mapper;
    }

    public async Task<RecipeDTO> Handle(GetUniqueRecipeQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var recipe = await _recipeRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (recipe is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Recipe));
        }

        var recipeDto = _mapper.Map<RecipeDTO>(recipe);
        return recipeDto;
    }
}
