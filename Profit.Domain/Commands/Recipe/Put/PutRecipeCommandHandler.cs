namespace Profit.Domain.Commands.Recipe.Put;

public sealed class PutRecipeCommandHandler :
    BaseCommandHandler<PutRecipeCommand>,
    IRequestHandler<PutRecipeCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RecipeDTO> _validator;

    public PutRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<RecipeDTO> validator,
        ICommandBatchProcessorService<PutRecipeCommand> commandBatchProcessor,
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

    public async Task<Unit> Handle(PutRecipeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Recipe, cancellationToken);
        EnqueueCommandForStoraging(request);
        var recipe = _mapper.Map<Entities.Recipe>(request.Recipe);
        _unitOfWork.RecipeRepository.Update(recipe);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Recipe.Id, nameof(Entities.Recipe));

        return Unit.Value;
    }
}
