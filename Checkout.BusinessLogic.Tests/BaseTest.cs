namespace Checkout.BusinessLogic.Tests
{
    public class BaseTest
    {
        public CheckoutContext context { get; set; }

        public void ConfigureMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(ConfigureMapper =>
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