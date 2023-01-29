namespace Profit.Domain.Commands.Ingredient.Delete;

public sealed class DeleteIngredientCommandHandler :
    BaseCommandHandler<DeleteIngredientCommand>,
    IRequestHandler<DeleteIngredientCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        ICommandBatchProcessorService<DeleteIngredientCommand> commandBatchProcessor) : base(commandBatchProcessor)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask DisposeAsync()
    {
        await base.ProcessBatchAsync();
    }

    public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        base.EnqueueCommandForStoraging(request);
        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.IngredientGuid, cancellationToken);
        _unitOfWork.IngredientRepository.Delete(ingredient);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
