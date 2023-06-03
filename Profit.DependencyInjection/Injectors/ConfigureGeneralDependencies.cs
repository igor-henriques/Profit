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
        services.Decorate<IReadOnlyIngredientRepository, CachedReadonlyIngredientRepository>();

        services.AddScoped<IReadOnlyProductRepository, ReadOnlyProductRepository>();
        services.Decorate<IReadOnlyProductRepository, CachedReadonlyProductRepository>();

        services.AddScoped<IReadOnlyRecipeRepository, ReadOnlyRecipeRepository>();
        services.Decorate<IReadOnlyRecipeRepository, CachedReadonlyRecipeRepository>();

        services.AddScoped<IReadOnlyUserRepository, ReadOnlyUserRepository>();
        services.Decorate<IReadOnlyUserRepository, CachedReadonlyUserRepository>();

        services.AddScoped<IReadOnlyOrderRepository, ReadOnlyOrderRepository>();
        services.Decorate<IReadOnlyOrderRepository, CachedReadonlyOrderRepository>();

        return services;
    }
}
