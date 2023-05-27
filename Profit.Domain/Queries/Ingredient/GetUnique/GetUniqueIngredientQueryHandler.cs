namespace Profit.Domain.Queries.Ingredient.GetUnique;

public sealed class GetUniqueIngredientQueryHandler : IRequestHandler<GetUniqueIngredientQuery, IngredientDto>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;
    private readonly IRedisCacheService _cache;

    public GetUniqueIngredientQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IRedisCacheService cache)
    {
        _cache = cache;
        _ingredientRepository = unitOfWork.IngredientRepository;
        _mapper = mapper;
    }

    public async Task<IngredientDto> Handle(GetUniqueIngredientQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Guid);

        var ingredient = await _ingredientRepository.GetUniqueAsync(request.Guid, cancellationToken)
            ?? throw new EntityNotFoundException(request.Guid, nameof(Entities.Ingredient));

        var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
        return ingredientDto;
    }
}
