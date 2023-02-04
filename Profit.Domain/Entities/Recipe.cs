namespace Profit.Domain.Entities;

public sealed record Recipe : Entity
{
    public string Name { get; init; }
    public decimal TotalCost { get; init; }
    public string Description { get; private set; }
    public ICollection<IngredientRecipeRelation> IngredientRecipeRelations { get; init; }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
