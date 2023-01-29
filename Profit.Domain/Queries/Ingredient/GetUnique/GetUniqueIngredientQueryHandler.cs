﻿namespace Profit.Domain.Queries.Ingredient.GetUnique;

public sealed class GetUniqueIngredientQueryHandler : IRequestHandler<GetUniqueIngredientQuery, IngredientDTO>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;

    public GetUniqueIngredientQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IServiceProvider serviceProvider)
    {
        _cache = serviceProvider.GetCacheService<ICacheService>(ECacheType.InMemory);
        _ingredientRepository = unitOfWork.IngredientRepository;
        _mapper = mapper;
    }

    public async Task<IngredientDTO> Handle(GetUniqueIngredientQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfDefault(request.Guid);

        var ingredient = await _ingredientRepository.GetUniqueAsync(request.Guid, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.Guid, nameof(Entities.Ingredient));
        }

        var ingredientDto = _mapper.Map<IngredientDTO>(ingredient);
        return ingredientDto;
    }
}