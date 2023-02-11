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
        var recipe = await _unitOfWork.RecipeRepository.GetUniqueAsync(request.RecipeId, cancellationToken);
        _unitOfWork.RecipeRepository.Delete(recipe);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.RecipeId, nameof(Entities.Recipe));

        return Unit.Value;
    }
}
