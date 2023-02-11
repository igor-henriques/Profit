namespace Profit.Domain.Commands.Recipe.Create;

public sealed class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = _mapper.Map<Entities.Recipe>(request);

        await _unitOfWork.RecipeRepository.Add(recipe, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return recipe.Id;
    }
}
