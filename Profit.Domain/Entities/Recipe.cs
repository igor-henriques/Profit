﻿namespace Profit.Domain.Entities;

public sealed record Recipe : Entity<Recipe>, IEntity
{
    public string Name { get; private set; }
    public decimal TotalCost { get; private set; }
    public string Description { get; private set; }
    public ICollection<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }
    public decimal SumRelationsCost => IngredientRecipeRelations?.Sum(x => x.RelationCost)
        ?? throw new ArgumentNullException($"{nameof(IngredientRecipeRelations)} has to be included in the query");

    public Recipe(
        string name,
        decimal totalCost,
        string description,
        ICollection<IngredientRecipeRelation> ingredientRecipeRelations = null)
    {
        Name = name;
        TotalCost = totalCost;
        Description = description;
        IngredientRecipeRelations = ingredientRecipeRelations;

        Validate();
    }

    public Recipe() { }

    public override void Validate()
    {
        ArgumentValidator.ThrowIfNullOrEmpty(Name, nameof(Name));
        ArgumentValidator.ThrowIfZeroOrNegative(TotalCost, nameof(TotalCost));
    }

    public override Recipe Update(Recipe recipe)
    {
        UpdateName(recipe.Name);
        UpdateTotalCost(recipe.TotalCost);
        UpdateDescription(recipe.Description);

        return this;
    }

    public Recipe UpdateName(string name)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(name);

        if (Name != name)
        {
            this.Name = name;
        }

        return this;
    }

    public Recipe UpdateDescription(string description)
    {
        if (Description != description)
        {
            this.Description = description;
        }

        return this;
    }
    public Recipe UpdateTotalCost(decimal price)
    {
        ArgumentValidator.ThrowIfNegative(price);

        if (TotalCost != price)
        {
            this.TotalCost = price;
        }

        return this;
    }
}
