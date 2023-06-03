namespace Profit.Domain.Commands.Order.Put;

public sealed class PutOrderCommandHandler : IRequestHandler<PutOrderCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutOrderCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(PutOrderCommand request, CancellationToken cancellationToken)
    {
        return Unit.Value;
    }
}
