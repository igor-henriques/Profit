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
        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.IngredientGuid);
        _unitOfWork.IngredientRepository.Delete(ingredient);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
