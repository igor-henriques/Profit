namespace Profit.Domain.Commands.Ingredient.Put;

public sealed class PutIngredientCommandHandler : IRequestHandler<PutIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PutIngredientCommand request, CancellationToken cancellationToken)
    {
        var incomingIngredient = _mapper.Map<Entities.Ingredient>(request);

        _unitOfWork.IngredientRepository.Update(incomingIngredient);

        var recipesAffected = await _unitOfWork.RecipeRepository.GetRecipesAndRelationsByIngredientId(
            incomingIngredient.Id,
            cancellationToken);

        foreach (var recipe in recipesAffected)
        {
            foreach (var relation in recipe.IngredientRecipeRelations)
            {
                if (relation.IngredientId != incomingIngredient.Id)
                {
                    continue;
                }

                relation.UpdateMeasurementUnit(incomingIngredient.MeasurementUnit);
                relation.UpdateIngredientCount(incomingIngredient.Quantity);
            }
        }

        var productsAffected = await _unitOfWork.ProductRepository.GetProductsByRecipeId(request.Id, cancellationToken);

        foreach (var product in productsAffected)
        {

        }

        if (await _unitOfWork.Commit(cancellationToken) is 0)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Ingredient));
        }

        return Unit.Value;
    }
}
