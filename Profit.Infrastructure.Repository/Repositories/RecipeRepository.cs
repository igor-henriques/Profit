namespace Profit.Infrastructure.Repository.Repositories;

internal sealed class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> logger;

    public RecipeRepository(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger) : base(context, logger)
    {
        this._context = context;
        this.logger = logger;
    }
}
