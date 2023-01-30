namespace Profit.Domain.Commands.Ingredient.Delete;

public sealed class DeleteIngredientCommandHandler :
    BaseCommandHandler<DeleteIngredientCommand>,
    IRequestHandler<DeleteIngredientCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        ICommandBatchProcessorService<DeleteIngredientCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
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

        if (await _unitOfWork.SaveAsync(cancellationToken) is 0)
            throw new EntityNotFoundException(request.IngredientGuid, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
