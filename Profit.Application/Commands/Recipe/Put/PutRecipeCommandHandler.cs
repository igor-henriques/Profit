namespace Profit.Application.Commands.Recipe.Put;

public sealed class PutRecipeCommandHandler : IRequestHandler<PutRecipeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PutRecipeCommand request, CancellationToken cancellationToken)
    {
        var incomingRecipe = _mapper.Map<Domain.Entities.Recipe>(request);
        var recipe = await _unitOfWork.RecipeRepository.GetUniqueAsync(incomingRecipe.Id, cancellationToken);

        ArgumentValidator.ThrowIfNullOrDefault(recipe, nameof(recipe));

        recipe.UpdateName(incomingRecipe.Name);
        recipe.UpdateDescription(incomingRecipe.Description);

        foreach (IngredientRecipeRelation relation in recipe.IngredientRecipeRelations)
        {
            IngredientRecipeRelation incomingRelation = incomingRecipe.IngredientRecipeRelations
                .FirstOrDefault(x => x.IngredientId == relation.IngredientId);

            relation.UpdateMeasurementUnit(incomingRelation.MeasurementUnit);
            relation.UpdateIngredientCount(incomingRelation.IngredientCount);
            relation.UpdateRelationCost(
                    (relation.Ingredient.Price * relation.IngredientCount) / relation.Ingredient.Quantity);
        }

        if (await _unitOfWork.Commit(cancellationToken) is 0)
        {
            throw new EntityNotFoundException(request.Id, nameof(Domain.Entities.Recipe));
        }

        return Unit.Value;
    }
}
