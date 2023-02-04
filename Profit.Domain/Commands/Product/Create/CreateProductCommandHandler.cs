namespace Profit.Domain.Commands.Product.Create;

public sealed class CreateProductCommandHandler :
    BaseCommandHandler<CreateProductCommand>,
    IRequestHandler<CreateProductCommand, Guid>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductDTO> _validator;

    public CreateProductCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateProductDTO> validator,
        ICommandBatchProcessorService<CreateProductCommand> commandBatchProcessor,
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

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Product, cancellationToken);
        base.EnqueueCommandForStoraging(request);

        var ingredient = _mapper.Map<Entities.Product>(request.Product);

        await _unitOfWork.ProductRepository.Add(ingredient, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return ingredient.Id;
    }
}
