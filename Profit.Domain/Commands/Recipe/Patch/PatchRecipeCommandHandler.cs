namespace Profit.Domain.Commands.Recipe.Patch;

public sealed class PatchRecipeCommandHandler :
    BaseCommandHandler<PatchRecipeCommand>,
    IRequestHandler<PatchRecipeCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RecipeDTO> _validator;

    public PatchRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<RecipeDTO> validator,
        ICommandBatchProcessorService<PatchRecipeCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    public async ValueTask DisposeAsync()
    {
        await ProcessBatchAsync();
    }

    public async Task<Unit> Handle(PatchRecipeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Recipe, cancellationToken);
        EnqueueCommandForStoraging(request);

        var recipe = await _unitOfWork.RecipeRepository.GetUniqueAsync(request.Recipe.Id, cancellationToken);
        if (recipe is null)
        {
            throw new EntityNotFoundException(request.Recipe.Id, nameof(Entities.Recipe));
        }

        recipe.Update(_mapper.Map<Entities.Recipe>(request.Recipe));

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Recipe.Id, nameof(Entities.Recipe));

        return Unit.Value;
    }
}
