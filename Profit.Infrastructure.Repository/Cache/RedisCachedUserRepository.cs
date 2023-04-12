namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedUserRepository : IUserRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly UserRepository _userRepository;
    private const string REDIS_USER_PREFIX = "profit:user:";
    private readonly long _cacheExpirationInSeconds;

    public RedisCachedUserRepository(
        AuthDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IConfiguration configuration)
    {
        this._cacheService = cacheService;
        this._userRepository = new UserRepository(context, logger);
        this._cacheExpirationInSeconds = configuration.GetValue<long>("CacheSecondsDuration");
    }
    private static string GetRedisKey(Guid id)
    {
        return $"{REDIS_USER_PREFIX}{id}";
    }
    private static string GetRedisKey(string key)
    {
        return $"{REDIS_USER_PREFIX}{key}";
    }

    public async ValueTask Add(User entity, CancellationToken cancellationToken = default)
    {
        await _userRepository.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<User> ingredients)
    {
        _userRepository.BulkAdd(ingredients);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _userRepository.CountAsync(cancellationToken);
    }

    public void Delete(User entity)
    {        
        _userRepository.Delete(entity);
        _cacheService.Remove(entity.Id.ToString());
    }

    public async ValueTask<bool> Exists(User entity, CancellationToken cancellationToken = default)
    {
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _userRepository.Exists(entity, cancellationToken);
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<User>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<User>(REDIS_USER_PREFIX);

        if (!response.Any())
        {
            response = await _userRepository.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }

        return response;
    }

    public async ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _cacheService.GetAsync<User>(GetRedisKey(id));

        if (user is null)
        {
            user = await _userRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), user, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return user;
    }

    public void Update(User entity)
    {
        _userRepository.Update(entity);
    }

    public async Task<User> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(username);
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            user = await _userRepository.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return user;
    }

    public async Task<Guid> GetTenantIdByUsername(string username, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(username);
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            user = await _userRepository.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }

        return user.TenantId;
    }
}
