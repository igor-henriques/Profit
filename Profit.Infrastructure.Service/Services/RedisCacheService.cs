using Profit.Core.JsonResolvers;

namespace Profit.Infrastructure.Service.Services;

public sealed class RedisCacheService : IRedisCacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IServer _redisServer;
    private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings()
    {
        ContractResolver = new PrivateResolver(),
        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
    };
    
    public RedisCacheService(string connectionString)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(connectionString);
        _redis = ConnectionMultiplexer.Connect(connectionString);
        _redisServer = _redis.GetServer(connectionString);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var database = _redis.GetDatabase();
        var keyValue = await database.StringGetAsync(key);

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
                response.Add(JsonConvert.DeserializeObject<T>(keyValue.ToString(), _jsonSettings));
            }
        }

        return response;
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
