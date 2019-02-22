using System;

namespace Checkout.Caching
{
    public interface ICacheService
    {
        /// <summary>
        /// Gets cached data for a given cache key for a given delegate.
        /// If not previously cached the delegate result is cached with custom expiration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        T Get<T>(string cacheKey, DateTime expireDate, Delegate cacheRetrieveMethod, params object[] methodParameters) where T : class;

        /// <summary>
        /// Gets cached data for a given cache key for a given delegate.
        /// If not previously cached the delegate result is cached with maximum expiration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        T Get<T>(string cacheKey, Delegate cacheRetrieveMethod, params object[] methodParameters) where T : class;

        /// <summary>
        /// Removes a cached item.
        /// </summary>
        /// <param name="cacheKey"></param>
        void Remove(string cacheKey);

        /// <summary>
        /// Sets data for a given cache key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Set<T>(string cacheKey, T data, DateTime expiryDate) where T : class;
    }
}