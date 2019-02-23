using System;
using AutoMapper;
using Checkout.EF;
using Microsoft.EntityFrameworkCore;

namespace Checkout.BusinessLogic.Tests
{
    public class BaseTest
    {
        public CheckoutContext context { get; set; }

        public void ConfigureMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });
        }

        public void MockContext()
        {
            var options = new DbContextOptionsBuilder<CheckoutContext>()
                                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                    .Options;

            context = new CheckoutContext(options);

            DbInitialiser.Initialize(context);
        }
    }
}