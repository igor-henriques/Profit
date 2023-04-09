namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class IngredientRepository : BaseRepository<Ingredient, ProfitDbContext>, IIngredientRepository
{
    public IngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
    }
}
