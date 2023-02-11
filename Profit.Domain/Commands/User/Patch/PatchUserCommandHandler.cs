namespace Profit.Domain.Commands.User.Patch;

public sealed class PatchUserCommandHandler : IRequestHandler<PatchUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatchUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PatchUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetUniqueAsync(request.Id, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException(request.Id, nameof(Entities.User));
        }

        user.Update(_mapper.Map<Entities.User>(request));

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.User));

        return Unit.Value;
    }
}
