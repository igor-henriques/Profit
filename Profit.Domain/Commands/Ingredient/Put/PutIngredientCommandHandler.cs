namespace Profit.Domain.Commands.Ingredient.Put;

public sealed class PutIngredientCommandHandler : IRequestHandler<PutIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PutIngredientCommand request, CancellationToken cancellationToken)
    {
        var mappedIngredient = _mapper.Map<Entities.Ingredient>(request);
        _unitOfWork.IngredientRepository.Update(mappedIngredient);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
