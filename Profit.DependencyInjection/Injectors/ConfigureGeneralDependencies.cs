using Profit.Infrastructure.Repository.Repositories.Base;

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
        services.AddScoped(typeof(IReadOnlyIngredientRepository), typeof(ReadOnlyIngredientRepository));
        services.AddScoped(typeof(IReadOnlyProductRepository), typeof(ReadOnlyProductRepository));
        services.AddScoped(typeof(IReadOnlyRecipeRepository), typeof(ReadOnlyRecipeRepository));
        services.AddScoped(typeof(IReadOnlyUserRepository), typeof(ReadOnlyUserRepository));
        return services;
    }
}
