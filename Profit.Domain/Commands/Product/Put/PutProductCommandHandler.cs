namespace Profit.Domain.Commands.Product.Put;

public sealed class PutProductCommandHandler :
    BaseCommandHandler<PutProductCommand>,
    IRequestHandler<PutProductCommand, Unit>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDTO> _validator;

    public PutProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<ProductDTO> validator,
        ICommandBatchProcessorService<PutProductCommand> commandBatchProcessor,
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

    public async Task<Unit> Handle(PutProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Product, cancellationToken);
        base.EnqueueCommandForStoraging(request);
        var product = _mapper.Map<Entities.Product>(request.Product);
        _unitOfWork.ProductRepository.Update(product);

        if (await _unitOfWork.SaveAsync(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Product.Id, nameof(Entities.Product));

        return Unit.Value;
    }
}
