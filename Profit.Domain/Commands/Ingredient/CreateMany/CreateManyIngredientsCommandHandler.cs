namespace Profit.Domain.Commands.Ingredient.CreateMany;

public sealed class CreateManyIngredientsCommandHandler :
    BaseCommandHandler<CreateManyIngredientsCommand>,
    IRequestHandler<CreateManyIngredientsCommand, IEnumerable<Guid>>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateIngredientDTO> _validator;

    public CreateManyIngredientsCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateIngredientDTO> validator,
        ICommandBatchProcessorService<CreateManyIngredientsCommand> commandBatchProcessor,
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

    public async Task<IEnumerable<Guid>> Handle(CreateManyIngredientsCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();
        var errors = new List<string>();

        foreach (var ingredientDto in request.Ingredients)
        {
            var validation = await _validator.ValidateAsync(ingredientDto, cancellationToken);

            if (!validation.IsValid)
            {
                errors.AddRange(validation.Errors.Select(x => x.ErrorMessage));
                continue;
            }

            var ingredientEntity = _mapper.Map<Entities.Ingredient>(ingredientDto);
            await _unitOfWork.IngredientRepository.Add(ingredientEntity, cancellationToken);
            response.Add(ingredientEntity.Id);
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
