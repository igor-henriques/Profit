namespace Profit.Domain.Commands.Product.CreateMany;

public sealed class CreateManyProductsCommandHandler : IRequestHandler<CreateManyProductsCommand, IEnumerable<Guid>>
{
    private readonly IMediator _mediator;

    public CreateManyProductsCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<Guid>> Handle(CreateManyProductsCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();

        foreach (var productDto in request.Products)
        {
            var productId = await _mediator.Send(productDto, cancellationToken);
            response.Add(productId);
        }

        return response;
    }
}
