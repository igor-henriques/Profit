namespace Profit.Infrastructure.Service.Services;

public sealed class RedisCacheService : ICacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IServer _redisServer;
    private readonly JsonSerializerSettings _jsonSettings;
    private readonly ILogger<RedisCacheService> _logger;

    public RedisCacheService(
        IOptions<ConnectionStringsOptions> connectionStrings,
        ILogger<RedisCacheService> logger,
        JsonSerializerSettings jsonSettings = null)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(connectionStrings.Value.Redis, nameof(connectionStrings));
        _redis = ConnectionMultiplexer.Connect(connectionStrings.Value.Redis);
        _redisServer = _redis.GetServer(connectionStrings.Value.Redis);
        _logger = logger;
        _jsonSettings = jsonSettings ?? new()
        {
            ContractResolver = new PrivateResolver(),
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var database = _redis.GetDatabase();
        var keyValue = await database.StringGetAsync(key);

        if (keyValue.HasValue)
        {
            _logger.LogInformation("Redis cache hit for key: {key}", key);
        }

        return keyValue.HasValue
            ? JsonConvert.DeserializeObject<T>(keyValue.ToString(), _jsonSettings)
            : default;
    }

    public async Task<IEnumerable<T>> GetAllKeys<T>(string prefix)
    {
        var response = new List<T>();
        var database = _redis.GetDatabase();

        foreach (var key in _redisServer.Keys(pattern: $"{prefix}*").ToArray())
        {
            var keyValue = await database.StringGetAsync(key);

            if (keyValue.HasValue)
            {
                _logger.LogInformation("Redis cache hit for key: {key}", key);
                response.Add(JsonConvert.DeserializeObject<T>(keyValue.ToString(), _jsonSettings));
            }
        }

        return response;
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan expirationTime)
    {
        var database = _redis.GetDatabase();
        return await database.StringSetAsync(key, JsonConvert.SerializeObject(value, _jsonSettings), expirationTime);
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
