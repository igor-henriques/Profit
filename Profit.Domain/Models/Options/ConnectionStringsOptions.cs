namespace Profit.Domain.Models.Options;

public sealed record ConnectionStringsOptions
{
    public string ProfitConnection { get; init; }
    public string AuthConnection { get; init; }
    public string Redis { get; init; }
    public string AzureStorage { get; init; }
}
