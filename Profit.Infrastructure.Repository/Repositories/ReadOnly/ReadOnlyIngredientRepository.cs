namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyIngredientRepository : ReadOnlyBaseRepository<Ingredient, ProfitDbContext>, 
    IReadOnlyBaseRepository<Ingredient>    
{
    public ReadOnlyIngredientRepository(
        ProfitDbContext context,
        ILogger<ReadOnlyBaseRepository<Ingredient, ProfitDbContext>> logger) : base(context, logger)
    {
    }
}