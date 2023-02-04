namespace Profit.Domain.Queries.Product.GetUnique;

public sealed class GetUniqueProductQueryHandler : IRequestHandler<GetUniqueProductQuery, CreateProductDTO>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;
    private readonly IRedisCacheService _cache;

    public GetUniqueProductQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IRedisCacheService cache)
    {
        _cache = cache;
        _ingredientRepository = unitOfWork.IngredientRepository;
        _mapper = mapper;
    }

    public async Task<CreateProductDTO> Handle(GetUniqueProductQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var ingredient = await _ingredientRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Product));
        }

        var ingredientDto = _mapper.Map<CreateProductDTO>(ingredient);
        return ingredientDto;
    }
}
