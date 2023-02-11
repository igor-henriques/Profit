namespace Profit.Domain.Commands.User.Put;

public sealed class PutUserCommandHandler : IRequestHandler<PutUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(PutUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Entities.User>(request);
        _unitOfWork.UserRepository.Update(user);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.Id, nameof(Entities.User));

        return Unit.Value;
    }
}
