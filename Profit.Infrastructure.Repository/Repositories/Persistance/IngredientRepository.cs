namespace Profit.Infrastructure.Repository.Repositories.Persistance;

internal sealed class IngredientRepository : BaseRepository<Ingredient, ProfitDbContext>, IIngredientRepository
{
    public IngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
    }
}
