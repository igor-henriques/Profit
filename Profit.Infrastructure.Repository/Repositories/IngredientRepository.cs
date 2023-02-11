namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class IngredientRepository : BaseRepository<Ingredient, ProfitDbContext>, IIngredientRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public IngredientRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
        this._context = context;
        this.logger = logger;
    }
}
