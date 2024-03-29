﻿namespace Profit.Infrastructure.Repository.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByRecipeId(Guid recipeId, CancellationToken cancellationToken = default);
}