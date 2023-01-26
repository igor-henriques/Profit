namespace Profit.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IIngredientRepository IngredientRepository { get; }
    ValueTask Save(CancellationToken cancellationToken = default);
}
