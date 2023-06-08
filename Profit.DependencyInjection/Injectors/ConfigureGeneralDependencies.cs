using Profit.Infrastructure.Migrator;

namespace Profit.DependencyInjection.Injectors;

public static class ConfigureGeneralDependencies
{
    public static IServiceCollection AddGeneralDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITenantInfo, TenantInfo>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<SchemaInterceptor>();
        services.AddSingleton<ITokenGeneratorService, TokenGeneratorService>();
        services.AddSingleton<IStorageQueueService, StorageQueueService>();
        services.AddSingleton<IPasswordHashingService, PasswordHashingService>();
        services.AddSingleton(typeof(ICommandBatchProcessorService<>), typeof(CommandBatchProcessorService<>));
        services.AddHostedService<CommandBatchProcessorWorker<RequestCommandQueryLog>>();
        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        services.AddScoped<IMigratorApplication, MigratorApplication>();

        services.AddScoped<IReadOnlyIngredientRepository, ReadOnlyIngredientRepository>();
        services.Decorate<IReadOnlyIngredientRepository, CachedReadOnlyIngredientRepository>();

        services.AddScoped<IReadOnlyProductRepository, ReadOnlyProductRepository>();
        services.Decorate<IReadOnlyProductRepository, CachedReadOnlyProductRepository>();

        services.AddScoped<IReadOnlyRecipeRepository, ReadOnlyRecipeRepository>();
        services.Decorate<IReadOnlyRecipeRepository, CachedReadOnlyRecipeRepository>();

        services.AddScoped<IReadOnlyUserRepository, ReadOnlyUserRepository>();
        services.Decorate<IReadOnlyUserRepository, CachedReadOnlyUserRepository>();

        services.AddScoped<IReadOnlyOrderRepository, ReadOnlyOrderRepository>();
        services.Decorate<IReadOnlyOrderRepository, CachedReadOnlyOrderRepository>();

        return services;
    }
}
