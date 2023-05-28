namespace Profit.Domain.Queries.Product.GetUnique;

public sealed class GetUniqueProductQueryHandler : IRequestHandler<GetUniqueProductQuery, ProductDto>
{
    private readonly IReadOnlyBaseRepository<Entities.Product> _repo;
    private readonly IMapper _mapper;

    public GetUniqueProductQueryHandler(
        IMapper mapper,
        IReadOnlyBaseRepository<Entities.Product> repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ProductDto> Handle(GetUniqueProductQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var ingredient = await _repo.GetUniqueAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(request.Id, nameof(Entities.Product));

        var ingredientDto = _mapper.Map<ProductDto>(ingredient);
        return ingredientDto;
    }
}
