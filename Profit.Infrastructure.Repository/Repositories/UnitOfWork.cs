namespace Profit.Infrastructure.Repository.Repositories;

/// <summary>
/// Provides a mechanism for working with the repository pattern, 
/// centralizing all the transactions in a single database context.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly ProfitDbContext _profitContext;
    private readonly AuthDbContext _authContext;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IMigratorApplication _migratorApplication;

    private IIngredientRepository _ingredientRepository;
    private IUserRepository _userRepository;
    private IProductRepository _productRepository;
    private IRecipeRepository _recipeRepository;
    private IOrderRepository _orderRepository;

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IIngredientRepository IngredientRepository
        => _ingredientRepository ??= new IngredientRepository(
            _profitContext,
            _logger);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IUserRepository UserRepository
        => _userRepository ??= new UserRepository(
            _authContext,
            _logger);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IProductRepository ProductRepository
        => _productRepository ??= new ProductRepository(
            _profitContext,
            _logger);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IRecipeRepository RecipeRepository
        => _recipeRepository ??= new RecipeRepository(
            _profitContext,
            _logger);

    /// <summary>
    /// Instead of delegating the object management to the IoC container
    /// It's being provided by UoW to ensure the repositories
    /// are used only through UnitOfWork
    /// </summary>
    public IOrderRepository OrderRepository
        => _orderRepository ??= new OrderRepository(
            _profitContext,
            _logger);

    public UnitOfWork(
        ProfitDbContext context,
        ILogger<UnitOfWork> logger,
        AuthDbContext authContext,
        IMigratorApplication migratorApplication)
    {
        _profitContext = context;
        _logger = logger;
        _authContext = authContext;
        _migratorApplication = migratorApplication;
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
        var changesCount = await _profitContext.SaveChangesAsync(cancellationToken);
        changesCount += await _authContext.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("{changesCount} changes were commited", changesCount);
        return changesCount;
    }

    public async Task CreateSchema(Guid tenantId, CancellationToken cancellationToken = default)
    {
        var connection = _profitContext.Database.GetDbConnection();
        if (connection.State is not ConnectionState.Open)
        {
            await connection.OpenAsync(cancellationToken);
        }

        using var command = connection.CreateCommand();

        command.CommandText = $"CREATE SCHEMA {tenantId.FormatTenantToSchema()}";
        _logger.LogInformation("{information}", command.CommandText);

        await command.ExecuteNonQueryAsync(cancellationToken);
        await _migratorApplication.RunMigrationsToSingleTenantAsync(tenantId, cancellationToken);
        await connection.CloseAsync();
    }

    public async Task DropTablesAndSchema(Guid tenantId, CancellationToken cancellationToken = default)
    {
        using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

        var connection = _profitContext.Database.GetDbConnection();
        if (connection.State is not ConnectionState.Open)
        {
            await connection.OpenAsync(cancellationToken);
        }

        await RunQuery(
            connection,
            TablesDDLQueries.GetDropTableQuery(Constants.TableNames.IngredientRecipeRelation, tenantId.FormatTenantToSchema()),
            cancellationToken);

        await RunQuery(
            connection,
            TablesDDLQueries.GetDropTableQuery(Constants.TableNames.Ingredient, tenantId.FormatTenantToSchema()),
            cancellationToken);

        await RunQuery(
            connection,
            TablesDDLQueries.GetDropTableQuery(Constants.TableNames.Product, tenantId.FormatTenantToSchema()),
            cancellationToken);

        await RunQuery(
            connection,
            TablesDDLQueries.GetDropTableQuery(Constants.TableNames.Recipe, tenantId.FormatTenantToSchema()),
            cancellationToken);

        await RunQuery(
            connection,
            TablesDDLQueries.GetDropTableQuery(Constants.TableNames.MigrationsHistory, tenantId.FormatTenantToSchema()),
            cancellationToken);

        await RunQuery(
            connection,
            $"DROP SCHEMA {tenantId.FormatTenantToSchema()}",
            cancellationToken);

        await connection.CloseAsync();
        transaction.Complete();
    }

    private async Task RunQuery(DbConnection dbConnection, string query, CancellationToken cancellationToken = default)
    {
        using var command = dbConnection.CreateCommand();
        command.CommandText = query;
        _logger.LogInformation("{query}", command.CommandText);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await _profitContext.DisposeAsync();
    }
}