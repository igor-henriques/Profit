namespace Profit.Infrastructure.Service.Services;

public sealed class RedisCacheService : ICacheService
{
    private readonly ConnectionMultiplexer _redis;

    public RedisCacheService(string connectionString)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(connectionString);
        _redis = ConnectionMultiplexer.Connect(connectionString);
    }

    public T Get<T>(string key)
    {
        var database = _redis.GetDatabase();
        var keyValue = database.StringGet(key);

        return keyValue.HasValue
            ? JsonConvert.DeserializeObject<T>(keyValue)
            : default;
    }

    public void Set<T>(string key, T value, TimeSpan expirationTime)
    {
        var database = _redis.GetDatabase();
        database.StringSet(key, JsonConvert.SerializeObject(value), expirationTime);
    }

    public void Remove(string key)
    {
        var database = _redis.GetDatabase();
        database.KeyDelete(key);
    }

    public bool Exists(string key)
    {
        var database = _redis.GetDatabase();
        return database.KeyExists(key);
    }
}
