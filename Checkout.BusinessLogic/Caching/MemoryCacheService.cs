using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Checkout.Caching
{
    using Interfaces;

    public class MemoryCacheService : ICacheService, ITransientService
    {
        private readonly ILogger<MemoryCacheService> logger;
        private readonly IMemoryCache memoryCache;

        public MemoryCacheService(ILogger<MemoryCacheService> logger, IMemoryCache memoryCache)
        {
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        public T Get<T>(string cacheKey, DateTime expireDate, Delegate cacheRetrieveMethod, params object[] methodParameters) where T : class
        {
            var key = CreateCleanKey(cacheKey);

            //If cached item found.
            var existing = memoryCache.Get(key);

            if (existing != null)
                return existing as T;

            //Currently not cached - store the method result.
            T data = RetrieveDelegateData<T>(cacheRetrieveMethod, methodParameters);

            if (data == null)
                throw new InvalidOperationException($"Memory cached failed for a Cache Key {cacheKey}");

            logger.LogDebug("Caching for a key: {0}", cacheKey);

            Set(key, data, expireDate);

            return data;
        }

        public T Get<T>(string cacheKey, Delegate cacheRetrieveMethod, params object[] methodParameters) where T : class
        {
            return Get<T>(cacheKey, DateTime.MaxValue, cacheRetrieveMethod, methodParameters);
        }

        public void Remove(string cacheKey)
        {
            memoryCache.Remove(CreateCleanKey(cacheKey));
        }

        public void Set<T>(string cacheKey, T data, DateTime expireDate) where T : class
        {
            logger.LogDebug("Caching for key: {0}", cacheKey);
            memoryCache.Set(CreateCleanKey(cacheKey), data, expireDate);
        }

        string CreateCleanKey(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
                throw new ArgumentException("Cachekey was not passed");

            return cacheKey.Replace(" ", "-");
        }

        T RetrieveDelegateData<T>(Delegate method, params object[] methodParameters) where T : class
        {
            return method.DynamicInvoke(methodParameters) as T;
        }
    }
}