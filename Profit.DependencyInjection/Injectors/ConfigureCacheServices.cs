namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCacheServices
{
    public static IServiceCollection AddCacheServices(
        this IServiceCollection services,
        string redisConnectionString)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(redisConnectionString);

        services.AddScoped<ICacheService, InMemoryCacheService>();
        services.AddScoped<ICacheService, RedisCacheService>(_ => new RedisCacheService(redisConnectionString));

        return services;
    }
}
