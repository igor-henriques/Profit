namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed class PatchIngredientCommandHandler : IRequestHandler<PatchIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> validator;

    public PatchIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        this.validator = validator;
    }
    public async Task<Unit> Handle(PatchIngredientCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);

        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.Guid, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.Guid, nameof(Entities.Ingredient));
        }

        _unitOfWork.IngredientRepository.Update(ingredient);
        await _unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}
