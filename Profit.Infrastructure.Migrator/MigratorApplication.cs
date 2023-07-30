namespace Profit.Infrastructure.Migrator;

internal sealed class MigratorApplication : IMigratorApplication
{
    private readonly AuthDbContext _authContext;
    private readonly IOptions<ConnectionStringsOptions> _options;
    private readonly ILogger<MigratorApplication> _logger;

    public MigratorApplication(
        IOptions<ConnectionStringsOptions> options,
        ILogger<MigratorApplication> logger,
        AuthDbContext authContext)
    {
        _options = options;
        _logger = logger;
        _authContext = authContext;
    }

    public async Task RunMigrationsForAllTenantsAsync()
    {
        await Console.Out.WriteLineAsync($"INITIALIZING SERVICE {nameof(MigratorApplication)}");

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
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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
                     .UseSqlServer(_options.Value.ProfitConnection,
                         x => x.MigrationsHistoryTable("__EFMigrationsHistory", tenantInfo.FormattedTenantId).MigrationsAssembly("Profit.Infrastructure.Migrator"))
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
