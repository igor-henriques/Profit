namespace Profit.Application.Commands.Ingredient.Create;

public sealed class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = _mapper.Map<Domain.Entities.Ingredient>(request);

        await _unitOfWork.IngredientRepository.Add(ingredient, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return ingredient.Id;
    }
}
