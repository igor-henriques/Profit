namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed class PatchIngredientCommandHandler : IRequestHandler<PatchIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;

    public PatchIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<Unit> Handle(PatchIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);

        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.Ingredient.Guid, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.Ingredient.Guid, nameof(Entities.Ingredient));
        }

        ingredient.Update(_mapper.Map<Entities.Ingredient>(request.Ingredient));

        await _unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}
