namespace Profit.Domain.Commands.Recipe.Delete;

public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.UserId, nameof(request.UserId));

        var user = await _unitOfWork.UserRepository.GetUniqueAsync(request.UserId, cancellationToken);

        _unitOfWork.UserRepository.Delete(user);

        if (await _unitOfWork.Commit(cancellationToken) is 0)
            throw new EntityNotFoundException(request.UserId, nameof(Entities.User));

        await _unitOfWork.DropTablesAndSchema(user.TenantId, cancellationToken);

        return Unit.Value;
    }
}
