namespace Profit.Domain.Commands.Product.Patch;

public sealed class PatchProductCommandHandler :
    BaseCommandHandler<PatchProductCommand>,
    IRequestHandler<PatchProductCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDTO> _validator;

    public PatchProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<ProductDTO> validator,
        ICommandBatchProcessorService<PatchProductCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    public async ValueTask DisposeAsync()
    {
        await base.ProcessBatchAsync();
    }

    public async Task<Unit> Handle(PatchProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Product, cancellationToken);
        base.EnqueueCommandForStoraging(request);

        var product = await _unitOfWork.ProductRepository.GetUniqueAsync(request.Product.Id, cancellationToken);
        if (product is null)
        {
            throw new EntityNotFoundException(request.Product.Id, nameof(Entities.Product));
        }

        product.Update(_mapper.Map<Entities.Product>(request.Product));

        if (await _unitOfWork.SaveAsync(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Product.Id, nameof(Entities.Product));

        return Unit.Value;
    }
}
