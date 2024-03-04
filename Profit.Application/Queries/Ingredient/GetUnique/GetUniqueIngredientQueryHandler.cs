namespace Profit.Application.Queries.Ingredient.GetUnique;

public sealed class GetUniqueIngredientQueryHandler : IRequestHandler<GetUniqueIngredientQuery, IngredientDto>
{
    private readonly IReadOnlyIngredientRepository _repo;
    private readonly IMapper _mapper;

    public GetUniqueIngredientQueryHandler(
        IMapper mapper,
        IReadOnlyIngredientRepository ingredientRepository)
    {
        _mapper = mapper;
        _repo = ingredientRepository;
    }

    public async Task<IngredientDto> Handle(GetUniqueIngredientQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Guid);

        var ingredient = await _repo.GetUniqueAsync(request.Guid, cancellationToken)
            ?? throw new EntityNotFoundException(request.Guid, nameof(Domain.Entities.Ingredient));

        var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
        return ingredientDto;
    }
}
