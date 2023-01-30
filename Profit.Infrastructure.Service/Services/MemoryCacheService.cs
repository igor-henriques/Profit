namespace Profit.Infrastructure.Service.Services;

public sealed class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public T Get<T>(string key)
    {
        if (!_memoryCache.TryGetValue(key, out T value))
        {
            return default;
        }

        return value;
    }

    public void Set<T>(string key, T value, TimeSpan expirationTime)
    {
        _memoryCache.Set(key, value, expirationTime);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public bool Exists(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }
}
