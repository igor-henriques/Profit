﻿namespace Profit.Application.Queries.Product.GetUnique;

public sealed class GetUniqueProductQueryHandler : IRequestHandler<GetUniqueProductQuery, ProductDto>
{
    private readonly IReadOnlyProductRepository _repo;
    private readonly IMapper _mapper;

    public GetUniqueProductQueryHandler(
        IMapper mapper,
        IReadOnlyProductRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ProductDto> Handle(GetUniqueProductQuery request, CancellationToken cancellationToken)
    {
        ArgumentValidator.ThrowIfNullOrDefault(request.Id, nameof(request.Id));

        var ingredient = await _repo.GetUniqueAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(request.Id, nameof(Domain.Entities.Product));

        var ingredientDto = _mapper.Map<ProductDto>(ingredient);
        return ingredientDto;
    }
}
