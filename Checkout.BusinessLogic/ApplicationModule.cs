using Microsoft.Extensions.DependencyInjection;

namespace Checkout.BusinessLogic
{
    using Caching;
    using Cart;
    using Location;
    using Inventory;

    public static class ApplicationModule
    {
        /// <summary>
        /// Register the services from this project. 
        /// i.e. Services that implement ITransientService are registered dynamically as Transient.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddTransient<ICacheService, MemoryCacheService>()
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<ICartRepository, CartRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IProductRepository, ProductRepository>();
        }
    }
}