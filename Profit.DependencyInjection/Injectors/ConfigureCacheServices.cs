namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCacheServices
{
    public static IServiceCollection AddCacheServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICacheService, RedisCacheService>();

        return services;
    }
}
