namespace Profit.Domain.Commands.Recipe.Delete;

public sealed class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecipeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.RecipeId, nameof(request.RecipeId));
        var recipe = await _unitOfWork.RecipeRepository.GetUniqueAsync(request.RecipeId, cancellationToken);
        ArgumentValidator.ThrowIfNullOrDefault(recipe, nameof(recipe));

        var productsAffected = await _unitOfWork.ProductRepository
            .GetPaginatedByAsync(x => x.RecipeId == recipe.Id, cancellationToken);

        if (productsAffected?.Any() ?? true)
        {
            var productsNameAffected = productsAffected.Select(x => x.Name).ToList();
            throw new InvalidEntityDeleteException(string.Join(",", productsNameAffected));
        }

        _unitOfWork.RecipeRepository.Delete(recipe);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
        {
            throw new EntityNotFoundException(request.RecipeId, nameof(Entities.Recipe));
        }

        return Unit.Value;
    }
}
