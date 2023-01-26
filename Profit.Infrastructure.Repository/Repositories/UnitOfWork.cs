namespace Profit.Infrastructure.Repository.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;
    private IIngredientRepository _ingredientRepository;

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// Is used only through UnitOfWork
    /// </summary>
    public IIngredientRepository IngredientRepository
        => _ingredientRepository ??= new IngredientRepository(_context, _logger);

    public UnitOfWork(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        this._context = context;
        this._logger = logger;
    }

    public async ValueTask Save(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
