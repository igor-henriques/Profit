namespace Profit.Infrastructure.Repository.Repositories;

/// <summary>
/// Provides a mechanism for working with the repository pattern, 
/// centralizing all the transactions in a single database context.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly ProfitDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IRedisCacheService _cacheService;

    private IIngredientRepository _ingredientRepository;
    private IUserRepository _userRepository;
    private IProductRepository _productRepository;
    private IRecipeRepository _recipeRepository;

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IIngredientRepository IngredientRepository
        => _ingredientRepository ??= new RedisCachedIngredientRepository(_context, _logger, _cacheService);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IUserRepository UserRepository
        => _userRepository ??= new RedisCachedUserRepository(_context, _logger, _cacheService);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IProductRepository ProductRepository
        => _productRepository ??= new RedisCachedProductRepository(_context, _logger, _cacheService);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IRecipeRepository RecipeRepository
        => _recipeRepository ??= new RedisCachedRecipeRepository(_context, _logger, _cacheService);

    public UnitOfWork(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService)
    {
        _context = context;
        _logger = logger;
        _cacheService = cacheService;        
    }

    /// <summary>
    /// Save all changes in the transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="DbUpdateConcurrencyException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    /// <returns></returns>
    public async ValueTask<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        var changesCount = await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation($"{changesCount} changes were saved");
        return changesCount;
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
