namespace Profit.Domain.Models;

public sealed record EntityQueryResultPaginated<TEntity>
{
    public List<TEntity> Data { get; init; } = [];
    public int? TotalCount { get; set; }
    public int? TotalPages { get; set; }
    public int PageNumber { get; init; }
    public int ItemsPerPage { get; init; }

    public EntityQueryResultPaginated<TDtoData> MapToDto<TDtoData>(IEnumerable<TDtoData> dtoData)
    {
        return new EntityQueryResultPaginated<TDtoData>()
        {
            Data = dtoData?.ToList() ?? [],
            ItemsPerPage = ItemsPerPage,
            PageNumber = PageNumber,
            TotalCount = TotalCount,
            TotalPages = TotalPages
        };
    }
}
