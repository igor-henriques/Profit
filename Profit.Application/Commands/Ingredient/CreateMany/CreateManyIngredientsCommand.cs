﻿namespace Profit.Application.Commands.Ingredient.CreateMany;

public sealed record CreateManyIngredientsCommand : IRequest<IEnumerable<Guid>>
{
    public IEnumerable<CreateIngredientCommand> Ingredients { get; init; }
}
