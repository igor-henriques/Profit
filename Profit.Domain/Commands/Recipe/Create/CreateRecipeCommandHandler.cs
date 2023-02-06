namespace Profit.Domain.Commands.Recipe.Create;

public sealed class CreateRecipeCommandHandler :
    BaseCommandHandler<CreateRecipeCommand>,
    IRequestHandler<CreateRecipeCommand, Guid>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateRecipeDTO> _validator;

    public CreateRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateRecipeDTO> validator,
        ICommandBatchProcessorService<CreateRecipeCommand> commandBatchProcessor,
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

    public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Recipe, cancellationToken);
        EnqueueCommandForStoraging(request);

        var recipe = _mapper.Map<Entities.Recipe>(request.Recipe);

        await _unitOfWork.RecipeRepository.Add(recipe, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return recipe.Id;
    }
}
