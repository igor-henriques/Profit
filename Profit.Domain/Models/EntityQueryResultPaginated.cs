namespace Profit.Domain.Models;

public sealed class EntityQueryResultPaginated<TEntity>
{
    public List<TEntity> Data { get; init; }
    public int? TotalCount { get; set; }
    public int? TotalPages { get; set; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
