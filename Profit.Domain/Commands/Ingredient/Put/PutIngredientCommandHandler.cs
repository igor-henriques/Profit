namespace Profit.Domain.Commands.Ingredient.Put;

public sealed class PutIngredientCommandHandler :
    BaseCommandHandler<PutIngredientCommand>,
    IRequestHandler<PutIngredientCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;

    public PutIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator,
        ICommandBatchProcessorService<PutIngredientCommand> commandBatchProcessor,
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

    public async Task<Unit> Handle(PutIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);
        EnqueueCommandForStoraging(request);
        var mappedIngredient = _mapper.Map<Entities.Ingredient>(request.Ingredient);
        _unitOfWork.IngredientRepository.Update(mappedIngredient);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Ingredient.Id, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
