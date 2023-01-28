using Profit.Core.Enum;

namespace Profit.Core.Shared
{
    public static class CacheServiceSelector
    {
        public static TInterface GetCacheService<TInterface>(
            this IServiceProvider serviceProvider, 
            ECacheType cacheType) where TInterface : class
        {
            var cacheServices = serviceProvider.GetServices<TInterface>();
            
            foreach (var cacheService in cacheServices)
            {
                if (cacheService.GetType().Name
                    .Replace(Constants.CACHE_SERVICE_TEXT, string.Empty)
                    .Equals(cacheType.ToString()))
                {
                    return cacheService;
                }
                       
            }

            throw new Exception("Cache service not found");
        }
    }
}
