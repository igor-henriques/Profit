namespace Profit.Domain.Commands.Recipe.Delete;

public sealed class DeleteRecipeCommandHandler :
    BaseCommandHandler<DeleteRecipeCommand>,
    IRequestHandler<DeleteRecipeCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        ICommandBatchProcessorService<DeleteRecipeCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask DisposeAsync()
    {
        await ProcessBatchAsync();
    }

    public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        EnqueueCommandForStoraging(request);

        var recipe = await _unitOfWork.RecipeRepository.GetUniqueAsync(request.RecipeId, cancellationToken);
        _unitOfWork.RecipeRepository.Delete(recipe);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.RecipeId, nameof(Entities.Recipe));

        return Unit.Value;
    }
}
