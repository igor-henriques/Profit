namespace Profit.Domain.Commands.Product.CreateMany;

public sealed class CreateManyProductsCommandHandler :
    BaseCommandHandler<CreateManyProductsCommand>,
    IRequestHandler<CreateManyProductsCommand, IEnumerable<Guid>>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductDTO> _validator;

    public CreateManyProductsCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateProductDTO> validator,
        ICommandBatchProcessorService<CreateManyProductsCommand> commandBatchProcessor,
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

    public async Task<IEnumerable<Guid>> Handle(CreateManyProductsCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();
        var errors = new List<string>();

        foreach (var productDto in request.Products)
        {
            var validation = await _validator.ValidateAsync(productDto, cancellationToken);

            if (!validation.IsValid)
            {
                errors.AddRange(validation.Errors.Select(x => x.ErrorMessage));
                continue;
            }

            var ingredientEntity = _mapper.Map<Entities.Product>(productDto);
            await _unitOfWork.ProductRepository.Add(ingredientEntity, cancellationToken);
            response.Add(ingredientEntity.Id);
        }

        if (errors.Any())
        {
            throw new ValidationException(string.Join("\n", errors));
        }

        base.EnqueueCommandForStoraging(request);
        await _unitOfWork.SaveAsync(cancellationToken);
        return response;
    }
}
