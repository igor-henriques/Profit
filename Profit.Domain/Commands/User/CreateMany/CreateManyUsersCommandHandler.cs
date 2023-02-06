namespace Profit.Domain.Commands.User.CreateMany;

public sealed class CreateManyUsersCommandHandler :
    BaseCommandHandler<CreateManyUsersCommand>,
    IRequestHandler<CreateManyUsersCommand, IEnumerable<Guid>>,
    IAsyncDisposable
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserDTO> _validator;

    public CreateManyUsersCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreateUserDTO> validator,
        ICommandBatchProcessorService<CreateManyUsersCommand> commandBatchProcessor,
        IConfiguration configuration) : base(commandBatchProcessor, configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async ValueTask DisposeAsync()
    {
        await ProcessBatchAsync();
    }

    public async Task<IEnumerable<Guid>> Handle(CreateManyUsersCommand request, CancellationToken cancellationToken)
    {
        var response = new List<Guid>();
        var errors = new List<string>();

        foreach (var userDto in request.Users)
        {
            var validation = await _validator.ValidateAsync(userDto, cancellationToken);

            if (!validation.IsValid)
            {
                errors.AddRange(validation.Errors.Select(x => x.ErrorMessage));
                continue;
            }

            var recipe = _mapper.Map<Entities.Recipe>(userDto);
            await _unitOfWork.RecipeRepository.Add(recipe, cancellationToken);
            response.Add(recipe.Id);
        }

        if (errors.Any())
        {
            throw new ValidationException(string.Join("\n", errors));
        }

        EnqueueCommandForStoraging(request);
        await _unitOfWork.Commit(cancellationToken);
        return response;
    }
}
