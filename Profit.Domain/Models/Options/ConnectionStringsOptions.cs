namespace Profit.Domain.Models.Options;

public sealed record ConnectionStringsOptions
{
    public string ProfitSqlServer { get; init; }
    public string AuthSqlServer { get; init; }
    public string Redis { get; init; }
    public string AzureStorage { get; init; }
}
