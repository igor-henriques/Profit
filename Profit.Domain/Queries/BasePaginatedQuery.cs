namespace Profit.Domain.Queries;

public sealed record BasePaginatedQuery<T> : IQuery<EntityQueryResultPaginated<T>>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
