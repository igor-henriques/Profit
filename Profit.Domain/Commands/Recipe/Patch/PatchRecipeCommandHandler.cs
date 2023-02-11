namespace Profit.Domain.Commands.Recipe.Patch;

public sealed class PatchRecipeCommandHandler : IRequestHandler<PatchRecipeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatchRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PatchRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _unitOfWork.RecipeRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (recipe is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.Recipe));
        }

        recipe.Update(_mapper.Map<Entities.Recipe>(request));

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.Recipe));

        return Unit.Value;
    }
}
