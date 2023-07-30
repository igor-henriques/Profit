namespace Profit.Domain.Queries.Recipe.GetPaginated;

public sealed class GetPaginatedRecipesQueryHandler : IRequestHandler<GetPaginatedRecipesQuery, EntityQueryResultPaginated<RecipeDto>>
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

    public async Task<EntityQueryResultPaginated<RecipeDto>> Handle(GetPaginatedRecipesQuery request, CancellationToken cancellationToken)
    {
        var paginatedResult = await _repo.GetPaginatedAsync(request, cancellationToken);
        var paginatedResponse = paginatedResult.TransformToDto(paginatedResult.Data.Select(_mapper.Map<RecipeDto>));
        return paginatedResponse;
    }
}