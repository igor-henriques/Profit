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
    private readonly IConfiguration _configuration;
    private TransactionScope _transaction;

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
        => _ingredientRepository ??= new RedisCachedIngredientRepository(
            _context, 
            _logger, 
            _cacheService, 
            _configuration);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IUserRepository UserRepository
        => _userRepository ??= new RedisCachedUserRepository(
            _context, 
            _logger, 
            _cacheService, 
            _configuration);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IProductRepository ProductRepository
        => _productRepository ??= new RedisCachedProductRepository(
            _context, 
            _logger, 
            _cacheService, 
            _configuration);
    
    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IRecipeRepository RecipeRepository
        => _recipeRepository ??= new RedisCachedRecipeRepository(
            _context,
            _logger, 
            _cacheService,
            _configuration);

    public UnitOfWork(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration)
    {
        _context = context;
        _logger = logger;
        _cacheService = cacheService;
        _configuration = configuration;
    }

    /// <summary>
    /// Commit all changes in the transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="DbUpdateConcurrencyException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    /// <returns></returns>
    public async ValueTask<int> Commit(CancellationToken cancellationToken = default)
    {
        _transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var changesCount = await _context.SaveChangesAsync(cancellationToken);
        _transaction.Complete();
        _logger.LogInformation("{changesCount} changes were saved", changesCount);
        return changesCount;
    }

    public async ValueTask DisposeAsync()
    {
        _transaction?.Dispose();
        await _context.DisposeAsync();
    }
}
