namespace Profit.Infrastructure.Repository.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;
    
    private IIngredientRepository _ingredientRepository;
    private IUserRepository _userRepository;

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// Is used only through UnitOfWork
    /// </summary>
    public IIngredientRepository IngredientRepository
        => _ingredientRepository ??= new IngredientRepository(_context, _logger);

    public IUserRepository UserRepository
        => _userRepository ??= new UserRepository(_context, _logger);

    public UnitOfWork(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Save all changes in the transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="DbUpdateConcurrencyException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    /// <returns></returns>
    public async ValueTask SaveAsync(CancellationToken cancellationToken = default)
    {
        var changesCount = await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation($"{changesCount} changes were saved");
    }    
}
