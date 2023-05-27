namespace Profit.Infrastructure.Migrator;

internal sealed class MigratorApplication : IMigratorApplication
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

    public async Task RunMigrationsForAllTenantsAsync()
    {
        var tenants = await _authContext.Users
            .AsNoTracking()
            .Select(u => u.TenantId)
            .Distinct()
            .ToListAsync();

        _logger.LogInformation("{tenantsCount} TENANTS FOUND", tenants.Count());

        foreach (var tenant in tenants)
        {
            await RunMigrationsToSingleTenantAsync(tenant);
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
                     .UseSqlServer(_configuration.GetConnectionString("ProfitSqlServer"),
                         x => x.MigrationsHistoryTable("__EFMigrationsHistory", tenantInfo.FormattedTenantId))
                     .AddInterceptors(new SchemaInterceptor(tenantInfo))
                     .ReplaceService<IMigrationsAssembly, DbSchemaAwareMigrationAssembly>()
                     .Options;

            using var context = new ProfitDbContextOverride(contextOptions, tenantId);
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync(cancellationToken);

            if (pendingMigrations?.Any() ?? false)
            {
                await context.Database.MigrateAsync(cancellationToken);
                _logger.LogInformation("MIGRATION FOR TENANT {tenant} APPLIED", tenantId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("MIGRATION FOR TENANT {tenant} FAILED:\n{ex}", tenantId, ex.ToString());
            throw;
        }
    }
}
