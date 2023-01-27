namespace Profit.Domain.Commands.Ingredient.Put;

public sealed class PutIngredientCommandHandler : IRequestHandler<PutIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;

    public PutIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Unit> Handle(PutIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);
        var mappedIngredient = _mapper.Map<Entities.Ingredient>(request.Ingredient);
        _unitOfWork.IngredientRepository.Update(mappedIngredient);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
