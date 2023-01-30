namespace Profit.Domain.Commands.Ingredient.Create;

public sealed class CreateIngredientCommandHandler :
    BaseCommandHandler<CreateIngredientCommand>,
    IRequestHandler<CreateIngredientCommand, Guid>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;

    public CreateIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator,
        ICommandBatchProcessorService<CreateIngredientCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async ValueTask DisposeAsync()
    {
        await base.ProcessBatchAsync();
    }

    public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);
        base.EnqueueCommandForStoraging(request);

        var ingredient = _mapper.Map<Entities.Ingredient>(request.Ingredient);

        await _unitOfWork.IngredientRepository.Add(ingredient, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return ingredient.Guid;
    }
}
