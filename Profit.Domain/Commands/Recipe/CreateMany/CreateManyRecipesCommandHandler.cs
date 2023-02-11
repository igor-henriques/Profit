namespace Profit.Domain.Commands.Recipe.CreateMany;

public sealed class CreateManyRecipesCommandHandler : IRequestHandler<CreateManyRecipesCommand, IEnumerable<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateManyRecipesCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Guid>> Handle(CreateManyRecipesCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();

        foreach (var recipeDto in request.Recipes)
        {

            var recipe = _mapper.Map<Entities.Recipe>(recipeDto);
            await _unitOfWork.RecipeRepository.Add(recipe, cancellationToken);
            response.Add(recipe.Id);
        }

        await _unitOfWork.Commit(cancellationToken);
        return response;
    }
}
