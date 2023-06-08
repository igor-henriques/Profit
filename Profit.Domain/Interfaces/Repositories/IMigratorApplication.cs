namespace Profit.Domain.Interfaces.Repositories;

public interface IMigratorApplication
{
    Task RunMigrationsToSingleTenantAsync(Guid tenantId, CancellationToken cancellationToken = default);
    Task RunMigrationsForAllTenantsAsync();
}
