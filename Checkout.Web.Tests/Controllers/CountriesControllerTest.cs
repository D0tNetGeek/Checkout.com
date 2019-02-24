using System.Collections.Generic;
using Xunit;

namespace Checkout.Web.Tests.Controllers
{
    using Location;
    using Web.Controllers.Api.v1;
    using Moq;
    using System.Threading.Tasks;

    public class CountriesControllerTest
    {
        private readonly Mock<ICountryService> service;
        private readonly CountriesController ctrl;

        public CountriesControllerTest()
        {
            service = new Mock<ICountryService>();
            ctrl = new CountriesController(service.Object);
        }

        [Fact]
        public void ItGetsCountries()
        {
            service.Setup(s => s.Get()).Returns(new List<Country>());
            var result = ctrl.Get();

            Assert.IsType<List<Country>>(result);
        }

        [Fact]
        public async Task ItGetsCountryById()
        {
            service.Setup(s => s.GetByIdAsync(It.IsAny<short>())).ReturnsAsync(new Country());
            var result = await ctrl.Get(1);

            Assert.IsType<Country>(result);
        }
    }
}