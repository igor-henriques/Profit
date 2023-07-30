namespace Profit.Infrastructure.Repository.Cache;

public sealed class CachedReadOnlyCustomerRepository : IReadOnlyCustomerRepository
{
    private readonly ITenantInfo _tenant;
    private readonly ICacheService _cacheService;
    private readonly IOptions<CacheOptions> _cacheOptions;
    private readonly IReadOnlyCustomerRepository _repo;
    private readonly ILogger<UnitOfWork> _logger;

    public CachedReadOnlyCustomerRepository(
        ILogger<UnitOfWork> logger,
        ICacheService cacheService,
        IOptions<CacheOptions> cacheOptions,
        ITenantInfo tenant,
        IReadOnlyCustomerRepository readOnlyCustomerRepo)
    {
        _repo = readOnlyCustomerRepo;
        _tenant = tenant;
        _cacheService = cacheService;
        _cacheOptions = cacheOptions;
        _logger = logger;
    }

    private string GetRedisKey(params string[] keys)
    {
        return $"{ICacheService.GetCustomKey(
            _tenant.TenantId.ToString(),
            nameof(Customer))}:{ICacheService.GetCustomKey(keys)}";
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(CountAsync));

        var count = await _cacheService.GetAsync<int>(redisKey);

        if (count is 0)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
               redisKey,
               nameof(CachedReadOnlyCustomerRepository));

            count = await _repo.CountAsync(cancellationToken);
            await _cacheService.SetAsync(redisKey, count, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyCustomerRepository));
        }

        return count;
    }

    public async ValueTask<bool> ExistsAsync(Customer entity, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(entity.Id.ToString());
        var response = _cacheService.GetAsync<Customer>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyCustomerRepository));

            return true;
        }

        return await _repo.ExistsAsync(entity, cancellationToken);
    }

    public async ValueTask<EntityQueryResultPaginated<Customer>> GetPaginatedAsync(BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(nameof(GetPaginatedAsync));
        var response = await _cacheService.GetAsync<EntityQueryResultPaginated<Customer>>(redisKey);

        if (response is not null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyCustomerRepository));

            response = await _repo.GetPaginatedAsync(paginatedQuery, cancellationToken);
            await _cacheService.SetAsync(redisKey, response, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyCustomerRepository));
        }

        return response;
    }

    public async ValueTask<Customer> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var redisKey = GetRedisKey(id.ToString());
        var Customer = await _cacheService.GetAsync<Customer>(redisKey);

        if (Customer is null)
        {
            _logger.LogInformation("Cache was not hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyCustomerRepository));

            Customer = await _repo.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(redisKey, Customer, TimeSpan.FromSeconds(_cacheOptions.Value.SecondsDuration));
        }
        else
        {
            _logger.LogInformation("Cache was hit for {redisKey} on {sourceName}",
                redisKey,
                nameof(CachedReadOnlyCustomerRepository));
        }

        return Customer;
    }

    public async ValueTask<EntityQueryResultPaginated<Customer>> GetByPaginatedAsync(Expression<Func<Customer, bool>> predicate, BasePaginatedQuery paginatedQuery, CancellationToken cancellationToken = default)
    {
        var result = await _repo.GetByPaginatedAsync(predicate, paginatedQuery, cancellationToken);

        int totalCount = await CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)paginatedQuery.ItemsPerPage);

        result.TotalPages = totalPages;
        result.TotalCount = totalCount;

        return result;
    }

    public async ValueTask<int> CountByAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.CountByAsync(predicate, cancellationToken);
    }

    public async ValueTask<Customer> GetUniqueByAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _repo.GetUniqueByAsync(predicate, cancellationToken);
    }
}
