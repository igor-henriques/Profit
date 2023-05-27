namespace Profit.Domain.Commands.Recipe.Create;

public sealed class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = _mapper.Map<Entities.Recipe>(request);

        decimal recipeTotalCost = 0;

        foreach (var relation in recipe.IngredientRecipeRelations)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(relation.IngredientId, cancellationToken);
            ArgumentValidator.ThrowIfNullOrDefault(ingredient, nameof(ingredient));
            recipeTotalCost += ingredient.UnitPrice * relation.IngredientCount;
        }

        recipe.UpdateTotalCost(recipeTotalCost);

        await _unitOfWork.RecipeRepository.Add(recipe, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return recipe.Id;
    }
}
