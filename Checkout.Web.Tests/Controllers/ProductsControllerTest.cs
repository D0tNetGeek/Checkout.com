using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.Web.Tests.Controllers
{
    using Inventory;
    using Web.Controllers.Api.v1;
    using Moq;

    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> service;
        private readonly ProductsController ctrl;

        public ProductsControllerTest()
        {
            service = new Mock<IProductService>();
            ctrl = new ProductsController(service.Object);
        }

        [Fact]
        public async Task ItGetsProducts()
        {
            service.Setup(s => s.GetAsync(It.IsAny<short>())).ReturnsAsync(new List<Product>());

            var result = await ctrl.Get(1);

            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public async Task ItGetsProductById()
        {
            service.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Product());
            Product result = await ctrl.GetProduct(1);

            Assert.IsType<Product>(result);
        }
    }
}