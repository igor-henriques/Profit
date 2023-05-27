namespace Profit.Domain.Queries.Recipe.GetUnique;

public sealed class GetUniqueRecipeQueryHandler : IRequestHandler<GetUniqueRecipeQuery, RecipeDto>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public GetUniqueRecipeQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _recipeRepository = unitOfWork.RecipeRepository;
        _mapper = mapper;
    }

    public async Task<RecipeDto> Handle(GetUniqueRecipeQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var recipe = await _recipeRepository.GetUniqueAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(request.Id, nameof(Entities.Recipe));

        var recipeDto = _mapper.Map<RecipeDto>(recipe);
        return recipeDto;
    }
}
