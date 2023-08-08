namespace Profit.Domain.Commands.Ingredient.Delete;

public sealed class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIngredientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.IngredientId, nameof(request.IngredientId));

        var recipesAffected = await _unitOfWork.RecipeRepository.GetRecipesAndRelationsByIngredientId(
                       request.IngredientId,
                       cancellationToken);

        if (recipesAffected.Any())
        {
            var recipesNameAffected = string.Join(",", recipesAffected.Select(x => x.Name).ToList());
            var errorMessage = $"Ingredient can't be deleted because it is being used in recipes: {recipesNameAffected}";
            throw new InvalidEntityDeleteException(errorMessage);
        }

        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.IngredientId, cancellationToken);
        _unitOfWork.IngredientRepository.Delete(ingredient);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
        {
            throw new EntityNotFoundException(request.IngredientId, nameof(Entities.Ingredient));
        }

        return Unit.Value;
    }
}
