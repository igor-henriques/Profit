using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Profit.Infrastructure.Migrator.Data;

namespace Profit.Infrastructure.Migrator;

public sealed class MigratorApplication : IMigratorApplication
{
    private readonly AuthDbContext _authContext;
    private readonly IConfiguration _configuration;
    private readonly ILogger<MigratorApplication> _logger;

    public MigratorApplication(IConfiguration configuration, ILogger<MigratorApplication> logger, AuthDbContext authContext)
    {
        _configuration = configuration;
        _logger = logger;
        _authContext = authContext;
    }

    internal async Task RunMigrationsForAllTenantsAsync()
    {
        var tenants = await _authContext.Users
            .AsNoTracking()
            .Select(u => u.TenantId)
            .Distinct()
            .ToListAsync();

        _logger.LogInformation("{tenantsCount} TENANTS FOUND", tenants.Count);

        foreach (var tenant in tenants)
        {
            try
            {
                await RunMigrationsToSingleTenantAsync(tenant);
            }
            catch (Exception)
            {
                //Ignore exception to be able to try running to the next tenant
            }
        }
    }

    public async Task RunMigrationsToSingleTenantAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("APPLYING MIGRATION FOR TENANT {tenant}", tenantId);

            var tenantInfo = new TenantInfo();
            tenantInfo.SetTenantId(tenantId);

            var contextOptions = new DbContextOptionsBuilder<ProfitDbContext>()
                     .UseSqlServer(_configuration.GetConnectionString("ProfitConnection"),
                         x => x.MigrationsHistoryTable("__EFMigrationsHistory", tenantInfo.FormattedTenantId))
                     .ReplaceService<IMigrationsAssembly, DbSchemaAwareMigrationAssembly>()
                     .Options;

            using var context = new ProfitDbContextOverride(contextOptions, tenantId);
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync(cancellationToken);

            if (pendingMigrations?.Any() ?? false)
            {
                await context.Database.MigrateAsync(cancellationToken);
                _logger.LogInformation("MIGRATION FOR TENANT {tenant} APPLIED", tenantId);
            }
            else
            {
                _logger.LogInformation("NO MIGRATIONS PENDING FOR TENANT {tenant}", tenantId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("MIGRATION FOR TENANT {tenant} FAILED:\n{ex}", tenantId, ex.ToString());
            throw;
        }
    }
}
