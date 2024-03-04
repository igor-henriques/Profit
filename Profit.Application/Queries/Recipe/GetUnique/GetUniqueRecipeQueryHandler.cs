namespace Profit.Application.Queries.Recipe.GetUnique;

public sealed class GetUniqueRecipeQueryHandler : IRequestHandler<GetUniqueRecipeQuery, RecipeDto>
{
    private readonly IReadOnlyRecipeRepository _repo;
    private readonly IMapper _mapper;

    public GetUniqueRecipeQueryHandler(
        IMapper mapper,
        IReadOnlyRecipeRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<RecipeDto> Handle(GetUniqueRecipeQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var recipe = await _repo.GetUniqueAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(request.Id, nameof(Domain.Entities.Recipe));

        var recipeDto = _mapper.Map<RecipeDto>(recipe);
        return recipeDto;
    }
}
