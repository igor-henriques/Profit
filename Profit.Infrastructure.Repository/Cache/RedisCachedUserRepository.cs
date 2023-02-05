namespace Profit.Infrastructure.Repository.Cache;

internal sealed class RedisCachedUserRepository : IUserRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly UserRepository _userRepository;

    public RedisCachedUserRepository(         
        ProfitDbContext context, 
        ILogger<UnitOfWork> logger,
        IRedisCacheService cacheService)
    {
        this._cacheService = cacheService;
        this._userRepository = new UserRepository(context, logger);
    }

    public async ValueTask Add(User entity, CancellationToken cancellationToken = default)
    {
        await _cacheService.SetAsync(entity.Id.ToString(), entity, TimeSpan.FromHours(1));
        await _userRepository.Add(entity, cancellationToken);
    }

    public async Task BulkAdd(IEnumerable<User> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            await _cacheService.SetAsync(ingredient.Id.ToString(), ingredient, TimeSpan.FromHours(1));
        }

        _userRepository.BulkAdd(ingredients);
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _userRepository.CountAsync(cancellationToken);
    }

    public void Delete(User entity)
    {
        _cacheService.Remove(entity.Id.ToString());
        _userRepository.Delete(entity);
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

    public ValueTask<IEnumerable<User>> GetManyAsync(CancellationToken cancellationToken = default)
    {
        return _userRepository.GetManyAsync(cancellationToken);
    }

    public async ValueTask<User> GetUniqueAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _cacheService.GetAsync<User>(id.ToString());

        if (user is null)
        {
            user = await _userRepository.GetUniqueAsync(id, cancellationToken);
            await _cacheService.SetAsync(id.ToString(), user, TimeSpan.FromHours(1));
        }

        return user;
    }

    public async ValueTask Update(User entity)
    {
        var user = await _cacheService.GetAsync<User>(entity.Id.ToString());

        if (user is not null)
        {
            await _cacheService.SetAsync(user.Id.ToString(), entity, TimeSpan.FromHours(1));
        }

        await _userRepository.Update(entity);
    }
}
