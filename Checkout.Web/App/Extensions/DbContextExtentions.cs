using System;

using Checkout.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Web.App.Extensions
{
    public static class DbContextExtentions
    {
        public static IServiceProvider AddDb(this IServiceCollection services)
        {
            services.AddDbContext<CheckoutContext>(options => options.UseInMemoryDatabase("CheckoutDatabaseContext"));

            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<CheckoutContext>();

            DbInitialiser.Initialize(context);

            return serviceProvider;
        }
    }
}