using System;
using Checkout.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Checkout.BusinessLogic.Tests.Caching
{
    public class MemoryCacheServiceTest
    {
        private readonly ICacheService service;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger<MemoryCacheService> logger;

        public MemoryCacheServiceTest()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions());
            logger = Mock.Of<ILogger<MemoryCacheService>>();

            service = new MemoryCacheService(logger, memoryCache);
        }

        [Fact]
        public void ItStoresValueFromMaxDateTime()
        {
            var result = service.Get<string>("key", new Func<string>(() => "value"), null);

            Assert.Equal("value", result);
            Assert.Equal("value", memoryCache.Get("key"));
        }

        [Fact]
        public void ItStoresValuesForCustomDateTime()
        {

        }
    }
}
