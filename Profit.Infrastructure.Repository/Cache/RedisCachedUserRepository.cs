namespace Profit.Infrastructure.Repository.Cache;

/// <summary>
/// This repository doesn't need to implement <see cref="TenantInfo"/>
/// Because it runs over [dbo] schema, so the tenant informations doesn't matter.
/// </summary>
internal sealed class RedisCachedUserRepository : IUserRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly UserRepository _repo;
    private const string REDIS_PREFIX = "dbo:profit:user:";
    private readonly long _cacheExpirationInSeconds;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IReadOnlyUserRepository _readOnlyRepo;

    public RedisCachedUserRepository(
        AuthDbContext context,
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        IReadOnlyUserRepository readOnlyRepo)
    {
        _cacheService = cacheService;
        _repo = new UserRepository(context, logger);
        _cacheExpirationInSeconds = cacheOptions.Value.SecondsDuration;
        _logger = logger;
        _readOnlyRepo = readOnlyRepo;
    }
    private static string GetRedisKey(Guid id)
    {
        return IRedisCacheService.GetCustomKey(
            REDIS_PREFIX,
            id.ToString());
    }
    private static string GetRedisKey(string key)
    {
        return IRedisCacheService.GetCustomKey(
            REDIS_PREFIX,
            key);
    }

    public async ValueTask Add(User entity, CancellationToken cancellationToken = default)
    {
        await _repo.Add(entity, cancellationToken);
    }

    public void BulkAdd(IEnumerable<User> ingredients)
    {
        _repo.BulkAdd(ingredients);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var specificRedisKey = $"{nameof(User)}:{nameof(CountAsync)}".ToLower();
        var count = await _cacheService.GetAsync<int>(specificRedisKey);

        if (count is 0)
        {
            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(specificRedisKey, count, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(CountAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return count;
    }

    public void Delete(User entity)
    {
        _repo.Delete(entity);
        _cacheService.Remove(entity.Id.ToString());
    }

    public async ValueTask<bool> ExistsAsync(User entity, CancellationToken cancellationToken = default)
    {
        var existsOnCache = _cacheService.Exists(entity.Id.ToString());

        if (!existsOnCache)
        {
            return await _repo.ExistsAsync(entity, cancellationToken);
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
               nameof(ExistsAsync),
               nameof(RedisCachedRecipeRepository));
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<User>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var response = await _cacheService.GetAllKeys<User>(REDIS_PREFIX);

        if (!response.Any())
        {
            response = await _repo.GetManyAsync(cancellationToken);

            foreach (var item in response)
            {
                await _cacheService.SetAsync(GetRedisKey(item.Id), item, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
            }
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetManyAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return response;
    }

    public async ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _cacheService.GetAsync<User>(GetRedisKey(id));

        if (user is null)
        {
            user = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(GetRedisKey(id), user, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetUniqueAsync),
                nameof(RedisCachedRecipeRepository));
        }

        return user;
    }

    public void Update(User entity)
    {
        _repo.Update(entity);
        _cacheService.SetAsync(GetRedisKey(entity.Id), entity, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
    }

    public async Task<User> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(username);
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            user = await _readOnlyRepo.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetByUsername),
                nameof(RedisCachedRecipeRepository));
        }

        return user;
    }

    public async Task<Guid> GetTenantIdByUsername(string username, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(username);
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            user = await _readOnlyRepo.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheExpirationInSeconds));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {methodName} on {sourceName}",
                nameof(GetByUsername),
                nameof(RedisCachedRecipeRepository));
        }

        return user.TenantId;
    }

    public async ValueTask<IEnumerable<User>> GetManyByAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetManyByAsync(predicate, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<User>> GetByPaginated(Expression<Func<User, bool>> predicate, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginated(predicate, page, pageSize, cancellationToken);

        int totalCount = await CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        result.TotalPages = totalPages;
        result.TotalCount = totalCount;

        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.CountByAsync(predicate, cancellationToken);
    }
}
