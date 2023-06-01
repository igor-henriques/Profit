namespace Profit.Infrastructure.Repository.Cache;

/// <summary>
/// This repository doesn't need to implement <see cref="TenantInfo"/>
/// Because it runs over [dbo] schema, so the tenant informations doesn't matter.
/// </summary>
public sealed class CachedReadonlyUserRepository : IReadOnlyUserRepository
{
    private readonly ICacheService _cacheService;
    private readonly IReadOnlyUserRepository _repo;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly ILogger<UnitOfWork> _logger;

    public CachedReadonlyUserRepository(
        ILogger<UnitOfWork> logger,
        ICacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        IReadOnlyUserRepository readOnlyRepo)
    {
        _cacheService = cacheService;
        _cacheOptions = cacheOptions;
        _repo = readOnlyRepo;
        _logger = logger;
    }
    private static string GetRedisKey(params string[] keys)
    {
        return $"{ICacheService.GetCustomKey("dbo", nameof(User))}:{ICacheService.GetCustomKey(keys)}";
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var countRedisKey = GetRedisKey(nameof(CountAsync));
        var count = await _cacheService.GetAsync<int>(countRedisKey);

        if (count is 0)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                countRedisKey,
                nameof(CachedReadonlyUserRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(countRedisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                countRedisKey,
                nameof(CachedReadonlyUserRepository));
        }

        return count;
    }

    public async ValueTask<bool> ExistsAsync(User entity, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(entity.Id.ToString());
        var existsOnCache = _cacheService.Exists(redisKey);

        if (!existsOnCache)
        {
            return await _repo.ExistsAsync(entity, cancellationToken);
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
               redisKey,
               nameof(CachedReadonlyUserRepository));
        }

        return existsOnCache;
    }

    public async ValueTask<IEnumerable<User>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(GetManyAsync));
        var response = await _cacheService.GetAsync<IEnumerable<User>>(redisKey);

        if (!response?.Any() ?? true)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));

            response = await _repo.GetManyAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));
        }

        return response;
    }

    public async ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(id.ToString());
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));

            user = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));
        }

        return user;
    }

    public async Task<User> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(GetByUsername), username);
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));

            user = await _repo.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));
        }

        return user;
    }

    public async Task<Guid> GetTenantIdByUsername(string username, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(username);
        var user = await _cacheService.GetAsync<User>(redisKey);

        if (user is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));

            user = await _repo.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadonlyUserRepository));
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

    public async ValueTask<User> GetUniqueByAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetUniqueByAsync(predicate, cancellationToken);
    }
}
