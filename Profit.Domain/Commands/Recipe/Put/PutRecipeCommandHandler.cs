namespace Profit.Domain.Commands.Recipe.Put;

public sealed class PutRecipeCommandHandler : IRequestHandler<PutRecipeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PutRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = _mapper.Map<Entities.Recipe>(request);
        _unitOfWork.RecipeRepository.Update(recipe);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.Recipe));

        return Unit.Value;
    }
}
