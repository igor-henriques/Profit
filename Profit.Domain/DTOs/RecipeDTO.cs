namespace Profit.Domain.DTOs;

public readonly record struct RecipeDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal TotalCost { get; init; }
    public string Description { get; init; }
}