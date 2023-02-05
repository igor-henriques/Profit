namespace Profit.Infrastructure.Service.Services;

public sealed class RedisCacheService : IRedisCacheService
{
    private readonly ConnectionMultiplexer _redis;

    public RedisCacheService(string connectionString)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(connectionString);
        _redis = ConnectionMultiplexer.Connect(connectionString);
    }

    public async Task<T> GetAsync<T>(string key)
    {        
        var database = _redis.GetDatabase();
        var keyValue = await database.StringGetAsync(key);

        return keyValue.HasValue
            ? JsonConvert.DeserializeObject<T>(keyValue)
            : default;
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan expirationTime)
    {
        var database = _redis.GetDatabase();
        return await database.StringSetAsync(key, JsonConvert.SerializeObject(value), expirationTime);
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
