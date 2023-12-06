namespace Profit.Infrastructure.Repository.Cache;

/// <summary>
/// This repository doesn't need to implement <see cref="TenantInfo"/>
/// Because it runs over [dbo] schema, so the tenant informations doesn't matter.
/// </summary>
public sealed class CachedReadOnlyUserRepository : IReadOnlyUserRepository
{
    private readonly ICacheService _cacheService;
    private readonly IReadOnlyUserRepository _repo;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly ILogger<CachedReadOnlyUserRepository> _logger;

    public CachedReadOnlyUserRepository(
        ILogger<CachedReadOnlyUserRepository> logger,
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
                nameof(CachedReadOnlyUserRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(countRedisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                countRedisKey,
                nameof(CachedReadOnlyUserRepository));
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
               nameof(CachedReadOnlyUserRepository));
        }

        return existsOnCache;
    }

    public async ValueTask<EntityQueryResultPaginated<User>> GetPaginatedAsync(BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(
            nameof(GetPaginatedAsync),
            nameof(paginatedQuery.PageNumber),
            paginatedQuery.PageNumber.ToString(),
            nameof(paginatedQuery.ItemsPerPage),
            paginatedQuery.ItemsPerPage.ToString());

        var response = await _cacheService.GetAsync<EntityQueryResultPaginated<User>>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyUserRepository));

            response = await _repo.GetPaginatedAsync(paginatedQuery, cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyUserRepository));
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
                nameof(CachedReadOnlyUserRepository));

            user = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyUserRepository));
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
                nameof(CachedReadOnlyUserRepository));

            user = await _repo.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyUserRepository));
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
                nameof(CachedReadOnlyUserRepository));

            user = await _repo.GetByUsername(username, cancellationToken);
            await _cacheService.SetAsync(redisKey, user, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyUserRepository));
        }

        return user.TenantId;
    }

    public async ValueTask<EntityQueryResultPaginated<User>> GetByPaginatedAsync(Expression<Func<User, bool>> predicate, BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginatedAsync(predicate, paginatedQuery, cancellationToken);
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
