namespace Profit.Infrastructure.Service.Services;

public sealed class RedisCacheService : ICacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;
    private readonly JsonSerializerSettings _jsonSettings;

    public RedisCacheService(
        IOptions<ConnectionStringsOptions> connectionStrings,
        JsonSerializerSettings jsonSettings = null)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(connectionStrings.Value.Redis, nameof(connectionStrings));
        _redis = ConnectionMultiplexer.Connect(connectionStrings.Value.Redis);
        _database = _redis.GetDatabase();
        _jsonSettings = jsonSettings ?? new()
        {
            ContractResolver = new PrivateResolver(),
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }

    public async Task<T> GetAsync<T>(string key)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(key, nameof(key));

        var keyValue = await _database.StringGetAsync(key);

        return keyValue.HasValue
            ? JsonConvert.DeserializeObject<T>(keyValue.ToString(), _jsonSettings)
            : default;
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan expirationTime)
    {
        return await _database.StringSetAsync(key, JsonConvert.SerializeObject(value, _jsonSettings), expirationTime);
    }

    public void Remove(string key)
    {
        _database.KeyDelete(key);
    }

    public bool Exists(string key)
    {
        return _database.KeyExists(key);
    }
}
