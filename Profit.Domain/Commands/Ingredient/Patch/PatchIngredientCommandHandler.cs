namespace Profit.Domain.Commands.Ingredient.Patch;

public sealed class PatchIngredientCommandHandler : IRequestHandler<PatchIngredientCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatchIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PatchIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = await _unitOfWork.IngredientRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (ingredient is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Ingredient));
        }

        ingredient.Update(_mapper.Map<Entities.Ingredient>(request));

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.Ingredient));

        return Unit.Value;
    }
}
