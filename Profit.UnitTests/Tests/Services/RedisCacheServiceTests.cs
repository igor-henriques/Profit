using Profit.Infrastructure.Service.Services;

namespace Profit.UnitTests.Tests.Services;

public class RedisCacheServiceTests
{
    private readonly IRedisCacheService _cacheService;
    private readonly string _redisConnectionString;

    public RedisCacheServiceTests()
    {
        _redisConnectionString = "localhost:6379";
        _cacheService = new RedisCacheService(_redisConnectionString);
    }


}