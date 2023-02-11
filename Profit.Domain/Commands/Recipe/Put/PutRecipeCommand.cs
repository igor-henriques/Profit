﻿namespace Profit.Domain.Commands.Recipe.Put;

public sealed record PutRecipeCommand : IRequest<Unit>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal TotalCost { get; init; }
    public string Description { get; init; }
    public ICollection<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
}