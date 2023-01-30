namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed class PatchIngredientCommandHandler :
    BaseCommandHandler<PatchIngredientCommand>,
    IRequestHandler<PatchIngredientCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;

    public PatchIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator,
        ICommandBatchProcessorService<PatchIngredientCommand> commandBatchProcessor,
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

    public async Task<Unit> Handle(PatchIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);

        base.EnqueueCommandForStoraging(request);

        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.IngredientGuid, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.IngredientGuid, nameof(Entities.Ingredient));
        }

        ingredient.Update(_mapper.Map<Entities.Ingredient>(request.Ingredient));

        if (await _unitOfWork.SaveAsync(cancellationToken) is 0)
            throw new EntityNotFoundException(request.IngredientGuid, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
