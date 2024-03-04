namespace Profit.Application.Commands.Recipe.CreateMany;

public sealed class CreateManyRecipesCommandHandler : IRequestHandler<CreateManyRecipesCommand, IEnumerable<Guid>>
{
    private readonly IMediator _mediator;

    public CreateManyRecipesCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<Guid>> Handle(CreateManyRecipesCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();

        foreach (var recipeDto in request.Recipes)
        {
            var recipeId = await _mediator.Send(recipeDto, cancellationToken);
            response.Add(recipeId);
        }

        return response;
    }
}
