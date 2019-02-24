using System;
using Xunit;

namespace Checkout.Web.Tests.Controllers
{
    using Cart;
    using Exceptions;
    using Web.Controllers.Api.v1;
    using Moq;
    using System.Threading.Tasks;

    public class CartControllerTest
    {
        private readonly Mock<ICartService> service;
        private readonly CartController ctrl;

        public CartControllerTest()
        {
            service = new Mock<ICartService>();
            ctrl = new CartController(service.Object);
        }

        [Fact]
        public async Task ItGetsACart()
        {
            service.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Cart());
            var result = await ctrl.Get(Guid.NewGuid());

            Assert.IsType<Cart>(result);
        }

        [Fact]
        public async Task ItGetsACartEmpyGuidAndThrowsException()
        {
            bool errorCaught = false;

            try
            {
                var result = await ctrl.Get(Guid.Empty);
            }
            catch (CartException ex)
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }

        [Fact]
        public async Task ItGetsACartAndThrowsException()
        {
            bool errorCaught = false;
            service.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).Throws(new CartException("test"));

            try
            {
                var result = await ctrl.Get(Guid.Empty);
            }
            catch (CartException ex)
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }

        [Fact]
        public async Task ItSavesAnItem()
        {
            service.Setup(s => s.SaveAsync(It.IsAny<CartItem>())).ReturnsAsync(new CartProduct());

            var result = await ctrl.Save(new CartItem());

            Assert.IsType<CartProduct>(result);
        }

        [Fact]
        public async Task ItRemovesACart()
        {
            // TODO: what does this actually test?
            await ctrl.Remove(Guid.NewGuid());
        }

        [Fact]
        public async Task ItRemovesACartEmpyGuidAndThrowsException()
        {
            bool errorCaught = false;

            try
            {
                await ctrl.Remove(Guid.Empty);
            }
            catch (CartException ex)
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }


        [Fact]
        public async Task ItRemovesACartProduct()
        {
            // TODO: what does this actually test?
            await ctrl.Remove(Guid.NewGuid(), 1);
        }

        [Fact]
        public async Task ItRemovesACartProductEmpyGuidAndThrowsException()
        {
            bool errorCaught = false;

            try
            {
                await ctrl.Remove(Guid.Empty, 1);
            }
            catch (CartException ex)
            {
                errorCaught = true;
            }

            Assert.True(errorCaught);
        }
    }
}