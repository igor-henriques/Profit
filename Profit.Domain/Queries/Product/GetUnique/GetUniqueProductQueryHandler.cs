﻿namespace Profit.Domain.Queries.Product.GetUnique;

public sealed class GetUniqueProductQueryHandler : IRequestHandler<GetUniqueProductQuery, ProductDTO>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public GetUniqueProductQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _ingredientRepository = unitOfWork.IngredientRepository;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(GetUniqueProductQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var ingredient = await _ingredientRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Product));
        }

        var ingredientDto = _mapper.Map<ProductDTO>(ingredient);
        return ingredientDto;
    }
}