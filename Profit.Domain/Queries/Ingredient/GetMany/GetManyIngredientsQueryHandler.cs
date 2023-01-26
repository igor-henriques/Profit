namespace Profit.Domain.Queries.Ingredient.GetMany;

public sealed class GetManyIngredientsQueryHandler : IRequestHandler<GetManyIngredientsQuery, IEnumerable<IngredientDTO>>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public GetManyIngredientsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _ingredientRepository = unitOfWork.IngredientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IngredientDTO>> Handle(GetManyIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await _ingredientRepository.GetManyAsync(cancellationToken);
        var ingredientDto = ingredient.Select(_mapper.Map<IngredientDTO>);
        return ingredientDto;
    }
}
