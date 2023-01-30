namespace Profit.DependencyInjection.Injectors;

public static class ConfigureCacheServices
{
    public static IServiceCollection AddCacheServices(
        this IServiceCollection services,
        string redisConnectionString)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(redisConnectionString);

        services.AddScoped<IMemoryCacheService, MemoryCacheService>();
        services.AddScoped<IRedisCacheService, RedisCacheService>(_ => new RedisCacheService(redisConnectionString));

        return services;
    }
}
