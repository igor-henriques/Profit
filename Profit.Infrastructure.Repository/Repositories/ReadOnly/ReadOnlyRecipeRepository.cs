namespace Profit.Infrastructure.Repository.Repositories.ReadOnly;

public sealed class ReadOnlyRecipeRepository : ReadOnlyBaseRepository<Recipe, ProfitDbContext>,
    IReadOnlyBaseRepository<Recipe>
{
    public ReadOnlyRecipeRepository(
        ProfitDbContext context,
        ILogger<ReadOnlyBaseRepository<Recipe, ProfitDbContext>> logger) : base(context, logger)
    {
    }
}
