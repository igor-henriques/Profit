namespace Profit.Domain.Interfaces.Repositories;

/// <summary>
/// Provides a mechanism for working with the repository pattern, 
/// centralizing all the transactions in a single database context.
/// </summary>
public interface IUnitOfWork
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
    /// Save all changes in the transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <exception cref="Core.Exceptions.DbUpdateException"></exception>
    /// <exception cref="Core.Exceptions.DbUpdateConcurrencyException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    /// <returns>Returns the change count</returns>
    ValueTask<int> SaveAsync(CancellationToken cancellationToken = default);
}