namespace Profit.Domain.Commands.Order.Create;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Entities.Order>(request);

        await _unitOfWork.OrderRepository.Add(order, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return order.Id;
    }
}
