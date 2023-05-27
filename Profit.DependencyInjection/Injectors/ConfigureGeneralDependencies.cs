namespace Profit.DependencyInjection.Injectors;

public static class ConfigureGeneralDependencies
{
    public static IServiceCollection AddGeneralDependencies(this IServiceCollection services)
    {
        services.AddScoped<TenantInfo>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<SchemaInterceptor>();
        services.AddSingleton<ITokenGeneratorService, TokenGeneratorService>();
        services.AddSingleton<IStorageQueueService, StorageQueueService>();
        services.AddSingleton<IPasswordHashingService, PasswordHashingService>();
        services.AddSingleton(typeof(ICommandBatchProcessorService<>), typeof(CommandBatchProcessorService<>));
        services.AddHostedService<CommandBatchProcessorWorker<RequestCommandQueryLog>>();
        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        services.AddScoped<IMigratorApplication, MigratorApplication>();
        return services;
    }
}
