namespace Profit.Domain.Commands.Ingredient.CreateMany;

public sealed class CreateManyIngredientsCommandHandler : IRequestHandler<CreateManyIngredientsCommand, IEnumerable<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateManyIngredientsCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Guid>> Handle(CreateManyIngredientsCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();

        foreach (var ingredientDto in request.Ingredients)
        {
            var ingredientEntity = _mapper.Map<Entities.Ingredient>(ingredientDto);
            await _unitOfWork.IngredientRepository.Add(ingredientEntity, cancellationToken);
            response.Add(ingredientEntity.Id);
        }

        await _unitOfWork.Commit(cancellationToken);
        return response;
    }
}
