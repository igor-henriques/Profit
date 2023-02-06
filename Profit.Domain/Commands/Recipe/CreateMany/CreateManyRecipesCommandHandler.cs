namespace Profit.Domain.Commands.Recipe.CreateMany;

public sealed class CreateManyRecipesCommandHandler :
    BaseCommandHandler<CreateManyRecipesCommand>,
    IRequestHandler<CreateManyRecipesCommand, IEnumerable<Guid>>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateRecipeDTO> _validator;

    public CreateManyRecipesCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateRecipeDTO> validator,
        ICommandBatchProcessorService<CreateManyRecipesCommand> commandBatchProcessor,
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

    public async Task<IEnumerable<Guid>> Handle(CreateManyRecipesCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();
        var errors = new List<string>();

        foreach (var recipeDto in request.Recipes)
        {
            var validation = await _validator.ValidateAsync(recipeDto, cancellationToken);

            if (!validation.IsValid)
            {
                errors.AddRange(validation.Errors.Select(x => x.ErrorMessage));
                continue;
            }

            var recipe = _mapper.Map<Entities.Recipe>(recipeDto);
            await _unitOfWork.RecipeRepository.Add(recipe, cancellationToken);
            response.Add(recipe.Id);
        }

        if (errors.Any())
        {
            throw new ValidationException(string.Join("\n", errors));
        }

        EnqueueCommandForStoraging(request);
        await _unitOfWork.Commit(cancellationToken);
        return response;
    }
}
