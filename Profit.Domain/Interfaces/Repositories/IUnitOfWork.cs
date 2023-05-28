namespace Profit.Domain.Interfaces.Repositories;

/// <summary>
/// Provides a mechanism for working with the repository pattern, 
/// centralizing all the transactions in a single database context.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>
    /// Readonly access to <see cref="IIngredientRepository"/>
    /// </summary>
    IIngredientRepository IngredientRepository { get; }

    /// <summary>
    /// Readonly access to <see cref="IIngredientRepository"/>
    /// </summary>
    IUserRepository UserRepository { get; }

    /// <summary>
    /// Readonly access to <see cref="IProductRepository"/>
    /// </summary>
    IProductRepository ProductRepository { get; }

    /// <summary>
    /// Readonly access to <see cref="IRecipeRepository"/>
    /// </summary>
    IRecipeRepository RecipeRepository { get; }

    /// <summary>
    /// Commit all changes in the transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <exception cref="Core.Exceptions.DbUpdateException"></exception>
    /// <exception cref="Core.Exceptions.DbUpdateConcurrencyException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    /// <returns>Returns the change count</returns>
    ValueTask<int> Commit(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a schema for the database
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateSchema(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Drops a schema and its tables from the database
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DropTablesAndSchema(Guid tenantId, CancellationToken cancellationToken = default);
}