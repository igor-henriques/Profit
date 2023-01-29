namespace Profit.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IIngredientRepository IngredientRepository { get; }
    IUserRepository UserRepository { get; }

    /// <summary>
    /// Save all changes in the transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <exception cref="Core.Exceptions.DbUpdateException"></exception>
    /// <exception cref="Core.Exceptions.DbUpdateConcurrencyException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    /// <returns></returns>
    ValueTask<int> SaveAsync(CancellationToken cancellationToken = default);
}