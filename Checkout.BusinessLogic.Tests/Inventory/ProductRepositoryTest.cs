using Xunit;

namespace Checkout.BusinessLogic.Tests.Inventory
{
    using Checkout.Inventory;
    using System.Threading.Tasks;

    public class ProductRepositoryTest : BaseTest
    {
        private readonly IProductRepository repo;

        public ProductRepositoryTest()
        {
            MockContext();
            repo = new ProductRepository(context);
        }

        [Fact]
        public async Task ItGetsById()
        {
            var result = await repo.GetByIdAsync(1);
            Assert.NotNull(result);
            Assert.True(result.Id == 1);
        }
    }
}