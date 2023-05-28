namespace Profit.DependencyInjection.Injectors;

public static class ConfigureOptions
{
    public static IServiceCollection AddOptionsConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CommandBatchProcessingOptions>(configuration.GetSection("CommandBatchStoraging"));
        services.Configure<ConnectionStringsOptions>(configuration.GetSection("ConnectionStrings"));
        services.Configure<JwtAuthenticationOptions>(configuration.GetSection("JwtAuthentication"));
        services.Configure<CacheOptions>(configuration.GetSection("Cache"));

        return services;
    }
}
