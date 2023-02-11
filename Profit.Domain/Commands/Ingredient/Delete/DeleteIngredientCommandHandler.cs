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
        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.IngredientId, cancellationToken);
        _unitOfWork.IngredientRepository.Delete(ingredient);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.IngredientId, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
